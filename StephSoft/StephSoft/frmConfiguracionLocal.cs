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
    public partial class frmConfiguracionLocal : Form
    {

       
        #region Constructor

        public frmConfiguracionLocal()
        {
            try
            {
                InitializeComponent();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmConfiguracionLocal ~ frmConfiguracionLocal()");
                this.DialogResult = DialogResult.Abort;
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.llenarDatos();
               
                this.ActiveControl = this.txtNombreCaja;
                this.txtNombreCaja.Focus();
                this.txtNombreCaja.SelectAll();
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

        private void llenarDatos()
        {
            try
            {
                Caja aux = new Caja();
                Caja_Negocio cn = new Caja_Negocio();
                aux.Conexion = Comun.Conexion;
                aux.Mac = Comun.MACAddress;
                aux = cn.obtenerDatosConfiguracionLocal(aux);
                this.txtNombreCaja.Text = aux.NombreCaja;
                this.txtImpresora.Text = aux.NombreImpresora;
                this.txtMac.Text = aux.Mac;
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

        private Caja ObtenerDatos()
        {
            try
            {
               
                Caja DatosAux = new Caja();
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.Mac = this.txtMac.Text;
                DatosAux.NombreImpresora = this.txtImpresora.Text;
                DatosAux.NombreCaja = this.txtNombreCaja.Text;
                DatosAux.Opcion = 1;
                DatosAux.Conexion = Comun.Conexion;
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
                List<Error> ListaErrores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtNombreCaja.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el nombre de la caja.", ControlSender = this.txtNombreCaja });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtNombreCaja.Text.Trim()))
                        ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un nombre valido de caja.", ControlSender = this.txtNombreCaja });
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
                    Caja Datos = this.ObtenerDatos();
                    Caja_Negocio CN = new Caja_Negocio();
                    CN.ActualizaConfiguracionLocal(Datos);
                    if (Datos.Completado)
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

        private void btnBuscarImpresora_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog1 = new PrintDialog();
                printDialog1.AllowCurrentPage = false;
                printDialog1.AllowPrintToFile = false;
                printDialog1.AllowSelection = false;
                printDialog1.AllowSomePages = false;
                printDialog1.ShowHelp = false;
                printDialog1.ShowNetwork = false;
                printDialog1.PrintToFile = false;
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PrinterSettings ps = printDialog1.PrinterSettings;
                    this.txtImpresora.Text = ps.PrinterName;
                }
                else
                {
                    this.txtImpresora.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmConfiguracionLocal ~ btnGuardar_Click");
            }
        }

        private void frmConfiguracionLocal_Load(object sender, EventArgs e)
        {
            try
            {
               this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmConfiguracionLocal ~ frmConfiguracionLocal_Load");
            }
        }
        
    }
}
