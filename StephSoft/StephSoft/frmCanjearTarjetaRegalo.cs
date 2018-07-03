using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephSoft
{
    public partial class frmCanjearTarjetaRegalo : Form
    {
        #region Propiedades / Variables

        string IDCliente = string.Empty;
        string IDTarjeta = string.Empty;
        private TarjetaMonedero _DatosAux;
        public TarjetaMonedero DatosAux
        {
            get { return _DatosAux; }
            set { _DatosAux = value; }
        }

        #endregion

        #region Constructor

        public frmCanjearTarjetaRegalo(Cliente Datos)
        {
            try
            {
                InitializeComponent();
                this.IDTarjeta = Datos.IDTarjeta;
                this.IDCliente = Datos.IDCliente;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCanjearTarjetaRegalo ~ frmCanjearTarjetaRegalo()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.ActiveControl = this.txtDescripcion;
                this.txtDescripcion.Focus();
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

        private TarjetaMonedero ObtenerDatos()
        {
            try
            {
                TarjetaMonedero DatosAux = new TarjetaMonedero();
                DatosAux.IDTarjeta = this.IDTarjeta;
                DatosAux.IDCliente = this.IDCliente;
                DatosAux.Folio = this.txtDescripcion.Text.Trim();
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
                int aux = 0;
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese el código de la tarjeta de regalo.", ControlSender = this.txtDescripcion });
                return Errores;
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
                LogError.AddExcFileTxt(ex, "frmCanjearTarjetaRegalo ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    TarjetaMonedero Datos = this.ObtenerDatos();
                    Cliente_Negocio CN = new Cliente_Negocio();
                    CN.ActivarTarjetaRegalo(Datos);
                    if (Datos.Completado)
                    {
                        this.DatosAux = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado == -1)
                        {
                            this.txtMensajeError.Visible = true;
                            this.txtMensajeError.Text = "La tarjeta ya ha sido canjeada anteriormente.";
                        }
                        else if (Datos.Resultado == -2)
                        {
                            this.txtMensajeError.Visible = true;
                            this.txtMensajeError.Text = "La tarjeta no ha sido vendida.";
                        }
                        else if (Datos.Resultado == -3)
                        {
                            this.txtMensajeError.Visible = true;
                            this.txtMensajeError.Text = "El código de activación es incorrecto.";
                        }
                        //else if (Datos.Opcion == -4)
                        //{
                        //    this.txtMensajeError.Visible = true;
                        //    this.txtMensajeError.Text = "La tarjeta de monedero no existe.";
                        //}
                        else
                            MessageBox.Show(Comun.MensajeError + "Código del error: " + Datos.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCanjearTarjetaRegalo ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                    this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCanjearTarjetaRegalo ~ txtDescripcion_KeyPress");
            }
        }

        private void frmCanjearTarjetaRegalo_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCanjearTarjetaRegalo ~ frmCanjearTarjetaRegalo_Load");
            }
        }

        #endregion

    }
}
