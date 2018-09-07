using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephSoft
{
    public partial class frmAutorizacion : Form
    {
        private string _IDUsuario;
        public string IDUsuario
        {
            get { return _IDUsuario; }
        }
        
        private int TipoValidacion = 0;

        #region Constructor

        public frmAutorizacion(int _TipoValidacion)
        {
            try
            {
                InitializeComponent();
                TipoValidacion = _TipoValidacion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ frmAutorizacion(int _TipoValidacion)");
            }
        }

        #endregion

        #region Eventos

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatosEntrada();
                if (Errores.Count == 0)
                {
                    Login_Negocio LogNeg = new Login_Negocio();
                    Usuario Datos = this.ObtenerDatosUsuario();
                    Datos = LogNeg.Autorizacion(Comun.Conexion, Datos.CuentaUsuario, Datos.Password, TipoValidacion);
                    if(Datos.Resultado == 1)
                    {
                        _IDUsuario = Datos.IDUsuario;
                        this.txtMensajeError.Visible = true;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.txtMensajeError.Text = "Acceso incorrecto. Código "  + Datos.Resultado;
                        this.txtMensajeError.Visible = true;
                    }
                }
                else
                {
                    this.MostrarMensajeError(Errores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ btnAceptar_Click");
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
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ btnCancelar_Click");
            }
        }

        private void frmAutorizacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ frmAutorizacion_KeyUp");
            }
        }

        private void frmAutorizacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ frmAutorizacion_Load");
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            try
            {
                TextBox Aux = (TextBox)sender;
                Aux.SelectAll();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ txt_Enter");
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox Aux = (TextBox)sender;
                if (e.KeyChar == 13)
                {
                    switch (Aux.Name)
                    {
                        case "txtUsuario":
                            this.txtContraseña.Focus();
                            break;
                        case "txtContraseña":
                            this.btnLogin_Click(sender, e);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ txt_KeyPress");
            }
        }

        #endregion

        #region Metodos
        
        private void DatosIncorrectos(int opcion)
        {
            try
            {
                switch (opcion)
                {
                    case -1:
                        this.Mensaje("Su cuenta está bloqueada. Comuníquese con un Administrador.");
                        break;
                    case -2:
                        this.Mensaje("El usuario no está registrado para ésta Sucursal.");
                        break;
                    case -3:
                        this.Mensaje("El usuario no tiene permisos para acceder a éste proyecto.");
                        break;
                    case -4:
                        this.Mensaje("El proyecto no está registrado. Contacte a Soporte Técnico.");
                        break;
                    case -5:
                        this.Mensaje("Ha excedido el número de intentos. Su cuenta fue bloqueada. Comuníquese con un Administrador.");
                        break;
                    case -6:
                        this.Mensaje("Contraseña incorrecta. Intente nuevamente.");
                        break;
                    case -7:
                        this.Mensaje("No existe la cuenta.");
                        break;
                    case -8:
                        this.Mensaje("No fue localizada la caja. Asigne una caja.");
                        break;
                    case 10:
                        this.Mensaje("No se pudo obtener la configuración del Equipo. El sistema debe cerrarse");
                        break;
                    case 15:
                        this.Mensaje("No se pudo conectar al servidor.");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Datos incorrectos" + ex.Message);
            }
        }
        
        private void IniciarForm()
        {
            try
            {
                this.ActiveControl = this.txtUsuario;
                this.txtUsuario.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Ingresar(Usuario Datos)
        {
            try
            {
                Login_Negocio LN = new Login_Negocio();
                //LN.ValidarUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Mensaje(string msj)
        {
            try
            {
                this.txtMensajeError.Text = msj;
                this.txtMensajeError.Visible = true;
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

        private Usuario ObtenerDatosUsuario()
        {
            try
            {
                Usuario DatosAux = new Usuario();
                DatosAux.CuentaUsuario = this.txtUsuario.Text.Trim();
                DatosAux.Password = this.txtContraseña.Text.Trim();
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarDatosEntrada()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                if (string.IsNullOrEmpty(this.txtUsuario.Text.Trim()))
                    Errores.Add(new Error { Numero = 1, Descripcion = "Debe ingresar un usuario.", ControlSender = this.txtUsuario });
                if (string.IsNullOrEmpty(this.txtContraseña.Text.Trim()))
                    Errores.Add(new Error { Numero = 2, Descripcion = "Debe ingresar una contraseña.", ControlSender = this.txtContraseña });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
