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
using System.IO;

namespace StephSoft
{
    public partial class frmDepositosRetirosCaja : Form
    {

        #region Declaración de variables

        int TipoForm = 0;

        #endregion

        #region Constructor

        public frmDepositosRetirosCaja(int op)
        {
            try
            {
                InitializeComponent();
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");
                TipoForm = op;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDepositosRetirosCaja ~ frmDepositosRetirosCaja(int op)");
                this.DialogResult = DialogResult.Abort;
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.TipoFormDatos();
                this.ActiveControl = this.txtMontoRetiro;
                this.txtMontoRetiro.Text = string.Format("{0:F2}", 0);
                this.txtMontoRetiro.Focus();
                this.txtMontoRetiro.SelectAll();
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

        private void TipoFormDatos()
        {
            try
            {
                switch (TipoForm)
                {
                    case 1:
                        this.Text = Comun.Sistema + " - Depósito";
                        panelDeposito.Title = "Depósito de Efectivo a Caja";
                        break;
                    case 2:
                        this.Text = Comun.Sistema + " - Retiro";
                        panelDeposito.Title = "Retiro de Efectivo";
                        //this.txtConcepto.ReadOnly = true;
                        //this.txtConcepto.Text = "Retiro por caja llena";
                        break;
                }
                this.txtMontoRetiro.Text = string.Format("{0:F2}", 0);
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

        private DepositoRetiro ObtenerDatos()
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtMontoRetiro.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                DepositoRetiro DatosAux = new DepositoRetiro();
                DatosAux.IDCaja = Comun.IDCaja;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.IDDepositoRetiro = string.Empty;
                DatosAux.Opcion = 1;
                DatosAux.IDTipoDepositoRetiro = this.TipoForm;
                DatosAux.Monto = Monto;
                DatosAux.Motivo = this.txtConcepto.Text.Trim();
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
                if (string.IsNullOrEmpty(this.txtMontoRetiro.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un monto", ControlSender = this.txtMontoRetiro });
                if (string.IsNullOrEmpty(this.txtConcepto.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el concepto del movimiento.", ControlSender = this.txtConcepto });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtConcepto.Text.Trim()))
                        ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un concepto de movimiento válido.", ControlSender = this.txtConcepto });
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
                    DepositoRetiro Datos = this.ObtenerDatos();
                    Caja_Negocio CN = new Caja_Negocio();
                    switch (TipoForm)
                    {
                        case 1: //deposito
                            CN.AgregarDeposito(Datos);
                            break;
                        case 2: //retiro caja llena
                            Datos.IDTipoDepositoRetiro = 1;
                            CN.AgregarRetiro(Datos);
                            break;
                    }
                    if (Datos.Validador)
                    {
                        MessageBox.Show("Se ha agregado correctamento el movimiento. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el movimiento. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDepositosRetirosCaja ~ btnGuardar_Click");
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
                LogError.AddExcFileTxt(ex, "frmDepositosRetirosCaja ~ btn_Cancelar_Click");
            }
        }

        private void frmDepositosRetirosCaja_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDepositosRetirosCaja ~ frmDepositosRetirosCaja_Load");
            }
        }

        private void frmDepositosRetirosCaja_KeyPress(object sender, KeyPressEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmDepositosRetirosCaja ~ frmDepositosRetirosCaja_KeyPress");
            }
        }

        private void frmDepositosRetirosCaja_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Aux = 0;
                decimal.TryParse(this.txtMontoRetiro.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Aux);
                this.txtMontoRetiro.Text = string.Format("{0:c}", Aux);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDepositosRetirosCaja ~ frmDepositosRetirosCaja_Validating");
            }
        }

        #endregion




    }
}
