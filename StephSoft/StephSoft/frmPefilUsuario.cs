using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft.ClasesAux;
using System.Configuration;
using System.Globalization;
using System.Threading;
using CreativaSL.Dll.Validaciones;
using System.Drawing.Printing;
using System.IO;

namespace StephSoft
{
    public partial class frmPefilUsuario : Form
    {

        Usuario usuario = new Usuario();
        #region Constructor

        public frmPefilUsuario()
        {
            try
            {
                InitializeComponent();
                usuario.IDUsuario = Comun.IDUsuario;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmPefilUsuario ~ frmPefilUsuario()");
                this.DialogResult = DialogResult.Abort;
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.llenarDatosUsuario();
               
                this.ActiveControl = this.txtNombre;
                this.txtNombre.Focus();
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

        private void llenarDatosUsuario()
        {
            try
            {
                if (!string.IsNullOrEmpty(usuario.IDUsuario))
                {
                    usuario.Conexion = Comun.Conexion;
                    Usuario_Negocio un = new Usuario_Negocio();
                    usuario = un.ObtenerUsuarioXID(usuario);
                    if (!string.IsNullOrEmpty(usuario.IDUsuario))
                    {
                        this.txtNombre.Text = usuario.Nombre;
                        this.txtApePat.Text = usuario.ApellidoPat;
                        this.txtApeMat.Text = usuario.ApellidoMat;
                        this.txtCalleDir.Text = usuario.DirCalle;
                        this.txtColoniaDir.Text = usuario.DirColonia;
                        this.txtNumDir.Text = usuario.DirNumero;
                        this.txtPassword.Text = "";
                        usuario.changePassword = false;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmPefilUsuario ~ llenarDatosUsuario()");
            }
        }       

        private void MostrarMensajeError(List<Error> Errores)
        {
            try
            {
                string CadenaErrores = string.Empty;
                CadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                foreach (Error item in Errores)
                {
                    CadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                this.txtMensajeError.Visible = true;
                this.txtMensajeError.Text = CadenaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void obtenerDatos()
        {
            try
            {
                usuario.Conexion = Comun.Conexion;
                usuario.Opcion = 1;
                usuario.IDSucursalActual = Comun.IDUsuario;
                usuario.Nombre = this.txtNombre.Text;
                usuario.ApellidoPat = this.txtApePat.Text;
                usuario.ApellidoMat = this.txtApeMat.Text;
                usuario.DirCalle = this.txtCalleDir.Text;
                usuario.DirColonia = this.txtColoniaDir.Text;
                usuario.DirNumero = this.txtNumDir.Text;
                if (string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    usuario.changePassword = false;
                }
                else
                {
                    usuario.changePassword = true;
                    usuario.Password = this.txtPassword.Text;
                }
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
                List<Error> ListaErrores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtNombre.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el nombre.", ControlSender = this.txtNombre });
                else
                {
                    if (!Validar.IsValidName(this.txtNombre.Text.Trim()))
                        ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un nombre valido.", ControlSender = this.txtNombre });
                }
                if (string.IsNullOrEmpty(this.txtApePat.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar su apellido paterno.", ControlSender = this.txtApePat });
                else
                {
                    if (!Validar.IsValidName(this.txtApePat.Text.Trim()))
                        ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un apellido paterno valido.", ControlSender = this.txtApePat });
                }
                if (string.IsNullOrEmpty(this.txtApeMat.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar su apellido materno.", ControlSender = this.txtApeMat });
                else
                {
                    if (!Validar.IsValidName(this.txtApeMat.Text.Trim()))
                        ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar su apellido materno valido.", ControlSender = this.txtApeMat });
                }
                return ListaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                   this.obtenerDatos();
                    Usuario_Negocio CN = new Usuario_Negocio();
                    CN.ActualizarDatosUsuario(usuario);
                    if (usuario.Completado)
                    {
                        MessageBox.Show("Los datos se actualizaron correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("No se puedo realizar los cambios. Intente mas tarde.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmConfiguracionLocal ~ btnGuardar_Click");
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
                LogError.AddExcFileTxt(ex, "frmConfiguracionLocal ~ btn_Cancelar_Click");
            }
        }

      

        #endregion


        private void frmPefilUsuario_Load(object sender, EventArgs e)
        {
            try
            {
               this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmPefilUsuario ~ frmPefilUsuario_Load");
            }
        }
    }
}
