using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using CreativaSL.Dll.Validaciones;
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
    public partial class frmDatosTarjeta : Form
    {
        #region Variables

        private int IDTipoTarjeta = 0; // 3: Débito; 4: Crédito.
        private FormaPago _PagoTarjeta;
        public FormaPago PagoTarjeta
        {
            get { return _PagoTarjeta; }
            set { _PagoTarjeta = value; }
        }
        
        #endregion

        #region Constructor

        public frmDatosTarjeta(int ID)
        {
            try
            {
                InitializeComponent();
                this.IDTipoTarjeta = ID;
                //Comun.PorcentajeComisionTC = 1.45M;
                //Comun.PorcentajeComisionTD = 1.23M;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ frmDatosTarjeta()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarDatos()
        {
            try
            {
                this.LlenarComboBancos();
                this.LlenarComboIdentificacion();
                this.txtNumAutorizacion.Text = string.Empty;
                this.txtDNI.Text = string.Empty;
                this.txtNumTarjeta.Text = string.Empty;
                this.txtMonto.Text = string.Format("{0:c}", 0);
                this.txtComision.Text = string.Format("{0:c}", 0);
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
                this.IniciarDatos();
                this.ActiveControl = this.txtNumAutorizacion;
                this.txtNumAutorizacion.Focus();
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

        private void LlenarComboBancos()
        {
            try
            {
                Banco Datos = new Banco { Conexion = Comun.Conexion, IncluirSelect = true };
                Catalogo_Negocio CN = new Catalogo_Negocio();
                this.cmbBancos.DataSource = CN.ObtenerComboBancos(Datos);
                this.cmbBancos.DisplayMember = "Descripcion";
                this.cmbBancos.ValueMember = "IDBanco";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void LlenarComboIdentificacion()
        {
            try
            {
                TipoIdentificacion Datos = new TipoIdentificacion { Conexion = Comun.Conexion, IncluirSelect = true };
                Catalogo_Negocio CN = new Catalogo_Negocio();
                this.cmbDocumento.DataSource = CN.ObtenerComboTipoIdentificacion(Datos);
                this.cmbDocumento.DisplayMember = "Descripcion";
                this.cmbDocumento.ValueMember = "IDTipoIdentificacion";
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

        private decimal ObtenerComision(decimal Monto)
        {
            try
            {
                decimal Porcentaje = 0, Comision = 0;
                switch (IDTipoTarjeta)
                {
                    case 3: Porcentaje = Comun.PorcentajeComisionTD;
                        break;
                    case 4: Porcentaje = Comun.PorcentajeComisionTC;
                        break;
                    default: break;

                }
                Comision = Monto * (Porcentaje / 100);
                return Comision;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private FormaPago ObtenerDatos()
        {
            try
            {
                FormaPago DatosTarjeta = new FormaPago();
                TipoIdentificacion TIAux = this.ObtenerTipoIdentificacion();
                Banco BancoAux = this.ObtenerBancoCombo();
                DatosTarjeta.IDFormaPago = this.IDTipoTarjeta;
                DatosTarjeta.Autorizacion = this.txtNumAutorizacion.Text.Trim();
                DatosTarjeta.IDTipoIdentificacion = TIAux.IDTipoIdentificacion;
                DatosTarjeta.FolioDNI = this.txtDNI.Text.Trim();
                DatosTarjeta.NumTarjeta = this.txtNumTarjeta.Text.Trim();
                DatosTarjeta.IDBanco = BancoAux.IDBanco;
                DatosTarjeta.MontoAPagar = this.ObtenerMonto();
                DatosTarjeta.Comision = this.ObtenerComision(DatosTarjeta.MontoAPagar);
                DatosTarjeta.MontoTotal = DatosTarjeta.MontoAPagar + DatosTarjeta.Comision;
                return DatosTarjeta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoIdentificacion ObtenerTipoIdentificacion()
        {
            try
            {
                TipoIdentificacion TipoID = new TipoIdentificacion();
                if(this.cmbDocumento.Items.Count > 0)
                    if(this.cmbDocumento.SelectedIndex != -1)
                    TipoID = (TipoIdentificacion)this.cmbDocumento.SelectedItem;
                return TipoID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal ObtenerMonto()
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtMonto.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                return Monto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Banco ObtenerBancoCombo()
        {
            try
            {
                Banco TipoID = new Banco();
                if (this.cmbBancos.Items.Count > 0)
                    if (this.cmbBancos.SelectedIndex != -1)
                        TipoID = (Banco)this.cmbBancos.SelectedItem;
                return TipoID;
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
                if (string.IsNullOrEmpty(this.txtNumAutorizacion.Text))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el número de autorización.", ControlSender = this.txtNumAutorizacion }); 
                
                if (this.ObtenerTipoIdentificacion().IDTipoIdentificacion == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un tipo de identificación.", ControlSender = this.cmbDocumento });     
                
                if (string.IsNullOrEmpty(this.txtDNI.Text) || string.IsNullOrWhiteSpace(this.txtDNI.Text))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un número de identificación.", ControlSender = this.txtDNI}); 
                
                //if (string.IsNullOrEmpty(this.txtNumTarjeta.Text) || string.IsNullOrWhiteSpace(this.txtNumTarjeta.Text))
                //    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el número de tarjeta.", ControlSender = this.txtNumTarjeta }); 
                //else
                //{
                //    if(!Validar.IsValidCreditCard(this.txtNumTarjeta.Text))
                //        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un número de tarjeta válido.", ControlSender = this.txtNumTarjeta }); 
                //}

                if (this.ObtenerBancoCombo().IDBanco == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un banco.", ControlSender = this.cmbBancos }); 

                if (this.ObtenerMonto() <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un monto válido mayor a 0. ", ControlSender = this.txtMonto }); 
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
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ btnCancelar_Click");
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
                    this._PagoTarjeta = this.ObtenerDatos();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDatosTarjeta_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ frmDatosTarjeta_Load");
            }
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Monto = this.ObtenerMonto();
                this.txtMonto.Text = string.Format("{0:c}", Monto);
                this.txtComision.Text = string.Format("{0:c}", this.ObtenerComision(Monto));
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ txt_Validating");
            }
        }

        #endregion

    }
}
