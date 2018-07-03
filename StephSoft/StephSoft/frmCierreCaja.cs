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
using System.IO;

namespace StephSoft
{
    public partial class frmCierreCaja : Form
    {

        #region Constructor

        public frmCierreCaja()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.txtMontoCierre.Text = string.Format("{0:c}", 0);
                this.ActiveControl = this.txtMontoCierre;
                this.txtMontoCierre.Focus();
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
                decimal MontoCierre = 0;
                decimal.TryParse(this.txtMontoCierre.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out MontoCierre);
                Caja DatosAux = new Caja();
                DatosAux.IDCaja = Comun.IDCaja;
                DatosAux.IDCajaCat = Comun.IDCajaCat;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.Cierre = MontoCierre;
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
                if (string.IsNullOrEmpty(this.txtMontoCierre.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un monto de Cierre.", ControlSender = this.txtMontoCierre });
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
                    CN.GuardarCierreCaja(Datos);
                    if (Datos.Completado)
                    {
                        Comun.CajaAbierta = false;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado == -1)
                        {
                            MessageBox.Show("La caja ya está cerrada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (Datos.Resultado == -2)
                        {
                            MessageBox.Show("No se puede cerrar la caja. Usted tiene ventas pendientes.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show("Ocurrió un error en el preceso de cierre de caja.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCierreCaja ~ btnGuardar_Click");
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
                LogError.AddExcFileTxt(ex, "frmCierreCaja ~ btn_Cancelar_Click");
            }
        }

        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCierreCaja ~ frmCierreCaja_Load");
            }
        }

        private void txtMontoCierre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.btnGuardar.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCierreCaja ~ txtMontoCierre_KeyPress");
            }
        }

        private void txtMontoCierre_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Aux = 0;
                decimal.TryParse(this.txtMontoCierre.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Aux);
                this.txtMontoCierre.Text = string.Format("{0:c}", Aux);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCierreCaja ~ txtMontoCierre_Validating");
            }
        }

        #endregion

    }
}
