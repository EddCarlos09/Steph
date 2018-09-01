using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephSoft
{
    public partial class frmNuevaClaveProduccion : Form
    {
        bool EsEmpleado = false;
        Usuario DatosEmpleado = new Usuario();
        private Producto Actual = new Producto();

        public frmNuevaClaveProduccion(Usuario _Empleado)
        {
            try
            {
                InitializeComponent();
                DatosEmpleado = _Empleado;
                EsEmpleado = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaClaveProduccion ~ frmNuevaClaveProduccion(Usuario _Empleado)");
            }
        }

        public frmNuevaClaveProduccion()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaClaveProduccion ~ frmNuevaClaveProduccion()");
            }
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaClaveProduccion ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(7);
                ElegirProducto.Location = this.txtProducto.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    Producto Aux = ElegirProducto.Datos;
                    Actual = Aux;
                    this.txtProducto.Text = Aux.NombreProducto;
                    this.txtCantidad.Focus();
                }
                else
                {
                    this.Actual = new Producto();
                    this.txtProducto.Text = string.Empty;

                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaClaveProduccion ~ btnElegirProducto_Click");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Producto_Negocio ProdNeg = new Producto_Negocio();
                    int Result = ProdNeg.GenerarNuevaClaveProduccion(Comun.Conexion, EsEmpleado, DatosEmpleado != null ? DatosEmpleado.IDEmpleado : string.Empty, Actual.IDProducto, this.ObtenerCantidad(), Comun.IDSucursalCaja, Comun.IDUsuario);
                    if(Result == 1)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        string Message = string.Empty;
                        switch (Result)
                        {
                            case -2:
                                Message = "No hay existencias suficientes para generar las claves.";
                                break;
                            default:
                                Message = "Error al guardar los datos. Intente nuevamente. ";
                                break;
                        }
                        MessageBox.Show(Message, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaClaveProduccion ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaClaveProduccion_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaClaveProduccion ~ frmNuevaClaveProduccion_Load");
            }
        }
        

        private void IniciarForm()
        {
            try
            {
                this.txtProducto.Text = string.Empty;
                this.Actual = new Producto();
                this.txtCantidad.Text = string.Format("{0:F0}", 1);
                this.ActiveControl = this.btnElegirProducto;
                this.btnElegirProducto.Focus();
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MostrarMensajeError(List<Error> Errores)
        {
            try
            {
                string cadenaErrores = string.Empty;
                cadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                foreach (Error item in Errores)
                {
                    cadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                this.txtMensajeError.Visible = true;
                this.txtMensajeError.Text = cadenaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerCantidad()
        {
            try
            {
                decimal Cantidad = 0;
                decimal.TryParse(this.txtCantidad.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Cantidad);
                return Cantidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.Actual.IDProducto))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un producto.", ControlSender = this.btnElegirProducto });
                if (this.ObtenerCantidad() <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad debe ser mayor que 0.", ControlSender = this.txtCantidad });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
