using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft;
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
    public partial class frmNuevoPedidoProducto : Form
    {
        private PedidoDetalle _Datos;
        public PedidoDetalle Datos
        {
            get { return _Datos; }
            set { _Datos = value; }
        }
        private Producto Actual = new Producto();

        public frmNuevoPedidoProducto()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ frmNuevoPedidoProducto()");
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
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario Empl = this.ObtenerEmpleado();
                int TipoForm = 0;
                if (string.IsNullOrEmpty(Empl.IDEmpleado))
                    TipoForm = 7;
                else
                    TipoForm = 6;
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(TipoForm);
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
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ btnElegirProducto_Click");
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
                    this._Datos = this.ObtenerDatos();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoPedidoProducto_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ frmNuevoPedidoProducto_Load");
            }
        }

        private void CargarComboEmpleados()
        {
            try
            {
                Usuario DatosAux = new Usuario { IncluirSelect = true, Conexion = Comun.Conexion, IDSucursalActual = Comun.IDSucursalCaja };
                Usuario_Negocio UN = new Usuario_Negocio();
                this.cmbEmpleados.DisplayMember = "Nombre";
                this.cmbEmpleados.ValueMember = "IDEmpleado";
                this.cmbEmpleados.DataSource = UN.LlenarComboCatEmpleadosPedidos(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.CargarComboEmpleados();
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

        private PedidoDetalle ObtenerDatos()
        {
            try
            {
                PedidoDetalle Datos = new PedidoDetalle();
                Datos.IDProducto = Actual.IDProducto;
                Datos.NombreProducto = Actual.NombreProducto;
                Datos.ClaveProducto = Actual.Clave;
                Usuario DatosEmpleado = this.ObtenerEmpleado();
                if (!string.IsNullOrEmpty(DatosEmpleado.IDEmpleado))
                {
                    Datos.IDEmpleado = DatosEmpleado.IDEmpleado;
                    Datos.NombreEmpleado = DatosEmpleado.Nombre;
                }
                else
                {
                    Datos.IDEmpleado = string.Empty;
                    Datos.NombreEmpleado = "SUCURSAL";
                }
                Datos.IDAsignacion = string.Empty;
                Datos.ClaveProduccion = string.Empty;
                Datos.Cantidad = this.ObtenerCantidad();
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario ObtenerEmpleado()
        {
            try
            {
                Usuario Datos = new Usuario();
                if (this.cmbEmpleados.SelectedIndex != -1)
                {
                    Datos = (Usuario)this.cmbEmpleados.SelectedItem;
                }
                return Datos;
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
                if (this.cmbEmpleados.SelectedIndex == -1)
                {
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un empleado.", ControlSender = this.cmbEmpleados });
                }
                if (this.ObtenerCantidad() <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad debe ser mayor que 0.", ControlSender = this.txtCantidad });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Actual = new Producto();
                this.txtProducto.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ cmbEmpleados_SelectedIndexChanged");
            }
        }

        private void cmbEmpleados_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbEmpleados.SelectedIndex == -1)
                {
                    this.Actual = new Producto();
                    this.txtProducto.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ cmbEmpleados_Validating");
            }
        }

    }
}
