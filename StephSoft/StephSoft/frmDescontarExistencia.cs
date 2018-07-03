using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreativaSL.Dll.Validaciones;
using System.Globalization;

namespace StephSoft
{
    public partial class frmDescontarExistencia : Form
    {
        #region Propiedades / Variables

        private bool NuevoRegistro = true;
        private Producto _DatosProductos;

        public Producto DatosProcutos
        {
            get { return _DatosProductos; }
            set { _DatosProductos = value; }
        }
        

        private Producto CatalogoActual = new Producto();
        #endregion

        #region Constructor

        public frmDescontarExistencia()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDescontarExistencia ~ frmDescontarExistencia()");
            }
        }
       
        #endregion

        #region Métodos

       

        private void IniciarForm()
        {
            try
            {
                if (NuevoRegistro)
                    this.InicializarCampos();
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

        private void InicializarCampos()
        {
            try
            {
                this.txtExistencia.Text = string.Empty;
                this.txtCantidadDisminuir.Text = string.Empty;
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

        private Producto ObtenerDatos()
        {
            try
            {
                decimal ExistenciaActual = 0;
                decimal.TryParse(this.txtCantidadDisminuir.Text.Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out ExistenciaActual); 
                Producto DatosAux = new Producto();
                DatosAux.IDProducto = this.CatalogoActual.IDProducto;
                DatosAux.Existencia = ExistenciaActual;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
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
                decimal CantidadADisminuir;
                if (!decimal.TryParse(this.txtCantidadDisminuir.Text.Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadADisminuir))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingreser una cantidad a disminuir", ControlSender = this.txtCantidadDisminuir });
                if (this.ObtenerCantidadDesminuir() <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad a disminuir tiene que se mayor a cero", ControlSender = this.txtCantidadDisminuir });
                if (this.ObtenerCantidadExistencia() < this.ObtenerCantidadDesminuir())
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "No tiene suficiente existencia", ControlSender = this.txtExistencia });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerCantidadDesminuir()
        {
            try
            {
                decimal CantidadDisminuir = 0;
                decimal.TryParse(this.txtCantidadDisminuir.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadDisminuir);
                return CantidadDisminuir;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerCantidadExistencia()
        {
            try
            {
                decimal CantidadExistencia = 0;
                decimal.TryParse(this.txtExistencia.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadExistencia);
                return CantidadExistencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDescontarExistencia ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Producto Datos = this.ObtenerDatos();
                    Producto_Negocio PN = new Producto_Negocio();
                    PN.ActualizarExistenciaProductoXSucusal(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDescontarExistencia ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidadDisminuir_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox TextPrecio = (TextBox)sender;
                decimal CantidadDisminuir = 0;
                decimal.TryParse(TextPrecio.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadDisminuir);
                TextPrecio.Text = CantidadDisminuir.ToString();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProductoServicio ~ txtPrecio_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmDescontarExistencia_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDescontarExistencia ~ frmDescontarExistencia_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(9);
                ElegirProducto.Location = this.txtProducto.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    Producto Aux = ElegirProducto.Datos;
                    this.CatalogoActual = Aux;
                    this.txtProducto.Text = Aux.NombreProducto;
                    this.ExistenciasProducto(Comun.IDSucursalCaja, Aux.IDProducto);
                    this.txtExistencia.Text = string.Format("{0:F0}", this._DatosProductos.Existencia);
                    this.txtCantidadDisminuir.Focus();
                }
                else
                {
                    this.CatalogoActual = new Producto();
                    this.txtProducto.Text = string.Empty;

                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDescontarExistencia ~ btnElegirProducto_Click");
            }
        }

        private void ExistenciasProducto(string IDSucursal, string IDProductos)
        {
            try
            {
                Producto DatosAux = new Producto { Conexion = Comun.Conexion, IDSucursal = IDSucursal, IDProducto = IDProductos };
                Producto_Negocio MN = new Producto_Negocio();
                this._DatosProductos = MN.ObtenerExistentes(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
