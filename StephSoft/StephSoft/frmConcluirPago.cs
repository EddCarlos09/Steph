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
    public partial class frmConcluirPago : Form
    {
        #region Variables

        private Cobro _Datos;
        public Cobro Datos
        {
            get { return _Datos; }
            set { _Datos = value; }
        }
        public FormaPago PagoTC = new FormaPago();
        public FormaPago PagoTD = new FormaPago();

        #endregion

        #region Constructor

        public frmConcluirPago(Cobro DatosCobro)
        {
            try
            {
                InitializeComponent();
                this._Datos = DatosCobro;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConcluirPago ~ frmConcluirPago()");
            }
        }

        #endregion

        #region Métodos

        private decimal CalcularTotalPago()
        {
            try
            {
                decimal PagoEfectivo = 0, PagoMonedero = 0, PagoTC = 0, PagoTD = 0, PagoTotal = 0;
                decimal.TryParse(this.txtPagoEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PagoEfectivo);
                decimal.TryParse(this.txtPagoMonedero.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PagoMonedero);
                PagoTC = this.PagoTC.MontoTotal;
                PagoTD = this.PagoTD.MontoTotal;
                PagoTotal = PagoEfectivo + PagoMonedero + PagoTC + PagoTD;
                return PagoTotal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal CalcularPagoReal()
        {
            try
            {
                decimal PagoEfectivo = 0, PagoMonedero = 0, PagoTC = 0, PagoTD = 0, PagoTotal = 0;
                decimal.TryParse(this.txtPagoEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PagoEfectivo);
                decimal.TryParse(this.txtPagoMonedero.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PagoMonedero);
                PagoTC = this.PagoTC.MontoAPagar;
                PagoTD = this.PagoTD.MontoAPagar;
                PagoTotal = PagoEfectivo + PagoMonedero + PagoTC + PagoTD;
                return PagoTotal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal CalcularCambio(decimal PagoTotal, decimal TotalAPagar)
        {
            try
            {
                decimal Cambio = 0;
                if (PagoTotal > TotalAPagar)
                    Cambio = PagoTotal - TotalAPagar;
                return Cambio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal CalcularComision()
        {
            try
            {
                decimal Comision = 0;
                if (!string.IsNullOrEmpty(this.PagoTD.Autorizacion))
                {
                    Comision += this.PagoTD.Comision;
                }
                if (!string.IsNullOrEmpty(this.PagoTC.Autorizacion))
                {
                    Comision += this.PagoTC.Comision;
                }
                return Comision;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DibujarTotales()
        {
            try
            {
                decimal TotalPago = this.CalcularTotalPago();
                decimal Comision = this.CalcularComision();
                decimal Cambio = this.CalcularCambio(TotalPago, this.Datos.TotalAPagar + Comision);
                this.txtPagoTotal.Text = string.Format("{0:c}", TotalPago);
                this.txtCambio.Text = string.Format("{0:c}", Cambio);
                this.txtComision.Text = string.Format("{0:c}", Comision);
                this.txtTotalAPagar.Text = string.Format("{0:c}", this._Datos.TotalAPagar + Comision);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaFormasPago()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDFormaPago", typeof(int));
                Tabla.Columns.Add("Monto", typeof(decimal));
                Tabla.Columns.Add("Comision", typeof(decimal));
                Tabla.Columns.Add("Total", typeof(decimal));
                Tabla.Columns.Add("Autorizacion", typeof(string));
                Tabla.Columns.Add("IDTipoIdentificacion", typeof(int));
                Tabla.Columns.Add("DNI", typeof(string));
                Tabla.Columns.Add("NumTarjeta", typeof(string));
                Tabla.Columns.Add("IDBanco", typeof(int));
                decimal PagoEfectivo = this.ObtenerPagoEfectivo();
                decimal TotalPago = this.CalcularPagoReal();
                decimal Cambio = this.CalcularCambio(TotalPago, this.Datos.TotalAPagar);

                if (PagoEfectivo > 0)
                {
                    object[] Fila = { 1, PagoEfectivo - Cambio, 0.0M, PagoEfectivo - Cambio, string.Empty, 0, string.Empty, string.Empty, 0 };
                    Tabla.Rows.Add(Fila);
                }
                decimal PagoMonedero = this.ObtenerPagoMonedero();
                if (PagoMonedero > 0)
                {
                    object[] Fila = { 2, PagoMonedero, 0.0M, PagoMonedero, string.Empty, 0, string.Empty, string.Empty, 0 };
                    Tabla.Rows.Add(Fila);
                }
                if (!string.IsNullOrEmpty(this.PagoTD.Autorizacion))
                {
                    object[] Fila = { this.PagoTD.IDFormaPago, this.PagoTD.MontoAPagar, this.PagoTD.Comision, this.PagoTD.MontoTotal,
                                        this.PagoTD.Autorizacion, this.PagoTD.IDTipoIdentificacion, this.PagoTD.FolioDNI, this.PagoTD.NumTarjeta, 
                                        this.PagoTD.IDBanco };
                    Tabla.Rows.Add(Fila);
                }
                if (!string.IsNullOrEmpty(this.PagoTC.Autorizacion))
                {
                    object[] Fila = { this.PagoTC.IDFormaPago, this.PagoTC.MontoAPagar, this.PagoTC.Comision, this.PagoTC.MontoTotal,
                                        this.PagoTC.Autorizacion, this.PagoTC.IDTipoIdentificacion, this.PagoTC.FolioDNI, this.PagoTC.NumTarjeta, 
                                        this.PagoTC.IDBanco };
                    Tabla.Rows.Add(Fila);
                }

                return Tabla;
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
                this.ActiveControl = this.txtPagoEfectivo;
                this.txtPagoEfectivo.Focus();
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

        private void IniciarDatos()
        {
            try
            {
                this.txtTotalVenta.Text = string.Format("{0:c}", Datos.TotalAPagar);
                this.txtComision.Text = string.Format("{0:c}", Datos.Comision);
                this.txtTotalAPagar.Text = string.Format("{0:c}", Datos.TotalAPagar + Datos.Comision);
                this.txtPagoEfectivo.Text = string.Format("{0:c}", 0);
                this.txtPagoMonedero.Text = string.Format("{0:c}", 0);
                this.txtPagoTarjetaCred.Text = string.Format("{0:c}", 0);
                this.txtPagoTarjetaDeb.Text = string.Format("{0:c}", 0);
                this.txtPagoTotal.Text = string.Format("{0:c}", 0);
                this.txtCambio.Text = string.Format("{0:c}", 0);
                //this.txtSaldoMonedero.Text = string.Format("{0:c}", Datos.Saldo);
                this.txtSaldoMonedero.Text = string.Format("{0:c}", Math.Truncate(this.Datos.Saldo * 10) / 10);
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

        private Cobro ObtenerDatos()
        {
            try
            {
                Cobro DatosAux = new Cobro();
                DatosAux.IDVenta = this._Datos.IDVenta;
                DatosAux.IDCaja = Comun.IDCaja;
                DatosAux.IDCajero = Comun.IDUsuario;
                DatosAux.TotalAPagar = this._Datos.TotalAPagar;
                DatosAux.Comision = this.CalcularComision();
                DatosAux.Pago = this.CalcularTotalPago();
                DatosAux.Cambio = this.CalcularCambio(DatosAux.Pago, DatosAux.TotalAPagar + DatosAux.Comision);
                DatosAux.RequiereFactura = false;
                DatosAux.PuntosVenta = this.Datos.PuntosVenta;
                DatosAux.TablaDatos = this.GenerarTablaFormasPago();
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.Conexion = Comun.Conexion;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerPagoMonedero()
        {
            try
            {
                decimal Monedero = 0;
                decimal.TryParse(this.txtPagoMonedero.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monedero);
                return Monedero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerPagoEfectivo()
        {
            try
            {
                decimal Efectivo = 0;
                decimal.TryParse(this.txtPagoEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Efectivo);
                return Efectivo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerMontoTextBox(TextBox Aux)
        {
            try
            {
                decimal Pago = 0;
                decimal.TryParse(Aux.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Pago);
                return Pago;
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
                decimal TotalPago = this.CalcularTotalPago();
                decimal Comision = this.CalcularComision();

                if (TotalPago < this._Datos.TotalAPagar + Comision)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El pago no cubre el total.", ControlSender = this.txtPagoEfectivo });
                if (!ValidarFormasPago(this._Datos.TotalAPagar))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El pago no efectivo no puede ser mayor al total.", ControlSender = this.txtPagoEfectivo });
                decimal TotalPagoMonedr = this.ObtenerPagoMonedero();
                if (TotalPagoMonedr > this._Datos.Saldo)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "No cuenta con suficiente saldo en monedero.", ControlSender = this.txtPagoEfectivo });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarFormasPago(decimal TotalAPagar)
        {
            try
            {
                bool Band = true;
                decimal PagoNoEfectivo = this.PagoTC.MontoAPagar + this.PagoTD.MontoAPagar + this.ObtenerPagoMonedero();
                if (PagoNoEfectivo > TotalAPagar)
                {
                    Band = false;
                }
                return Band;
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
                LogError.AddExcFileTxt(ex, "frmConcluirPago ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Lista = this.ValidarDatos();
                if (Lista.Count == 0)
                {
                    Cobro DatosAux = this.ObtenerDatos();
                    //*****************************
                    this.DialogResult = DialogResult.OK;
                    this._Datos = DatosAux;

                    //*****************************
                    //Venta_Negocio VN = new Venta_Negocio();
                    //VN.CobroVentaServicios(DatosAux);
                    //if (DatosAux.Completado)
                    //{
                    //    this.DialogResult = DialogResult.OK;
                    //    //Imprimir Ticket 
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Ocurrió un error al guardar los datos. Código el error: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    Exception AuxEx = new Exception("Ocurrió un error al guardar los datos. código del Error: " + DatosAux.Resultado);
                    //    LogError.AddExcFileTxt(AuxEx, "frmConcluirCobro ~ btnCobrar_Click");
                    //}
                }
                else
                    this.MostrarMensajeError(Lista);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConcluirCobro ~ btnCobrar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPagoTarjetaDebito_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkPagoTarjetaDebito.Checked)
                {
                    frmDatosTarjeta DatosTarjeta = new frmDatosTarjeta(4);
                    DatosTarjeta.ShowDialog();
                    if (DatosTarjeta.DialogResult == DialogResult.OK)
                    {
                        FormaPago Datos = DatosTarjeta.PagoTarjeta;
                        this.txtPagoTarjetaDeb.Text = string.Format("{0:c}", Datos.MontoTotal);
                        this.PagoTD = Datos;
                    }
                    else
                    {
                        this.chkPagoTarjetaDebito.Checked = false;
                        this.PagoTD = new FormaPago();
                    }
                    DatosTarjeta.Dispose();
                    this.DibujarTotales();
                }
                else
                {
                    this.txtPagoTarjetaDeb.Text = string.Format("{0:c}", 0);
                    this.PagoTD = new FormaPago();
                    this.DibujarTotales();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConcluirCobro ~ chkPagoTarjetaDebito_CheckedChanged");
            }
        }

        private void chkPagoTarjetaCredito_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkPagoTarjetaCredito.Checked)
                {
                    frmDatosTarjeta DatosTarjeta = new frmDatosTarjeta(3);
                    DatosTarjeta.ShowDialog();
                    if (DatosTarjeta.DialogResult == DialogResult.OK)
                    {
                        FormaPago Datos = DatosTarjeta.PagoTarjeta;
                        this.txtPagoTarjetaCred.Text = string.Format("{0:c}", Datos.MontoTotal);
                        this.PagoTC = Datos;
                    }
                    else
                    {
                        this.chkPagoTarjetaCredito.Checked = false;
                        this.PagoTC = new FormaPago();
                    }
                    DatosTarjeta.Dispose();
                    this.DibujarTotales();
                }
                else
                {
                    this.txtPagoTarjetaCred.Text = string.Format("{0:c}", 0);
                    this.PagoTC = new FormaPago();
                    this.DibujarTotales();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConcluirCobro ~ chkPagoTarjetaDebito_CheckedChanged");
            }
        }

        private void frmConcluirCobro_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConcluirCobro ~ frmConcluirCobro_Load");
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox TxtPago = (TextBox)sender;
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    this.btnCobrar.Focus();
                }
                Validaciones.PermitirSoloNumerosDecimales(e, TxtPago.Text);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCobro ~ txt_KeyPress");
            }
        }

        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.DibujarTotales();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCobro ~ txt_KeyUp");
            }
        }

        private void txt_Validated(object sender, EventArgs e)
        {
            try
            {
                this.DibujarTotales();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox TxtPago = (TextBox)sender;
                decimal Monto = this.ObtenerMontoTextBox(TxtPago);
                TxtPago.Text = string.Format("{0:c}", Monto);
                if (TxtPago.Name == this.txtPagoMonedero.Name)
                {
                    if (Monto > this.Datos.Saldo)
                        
                        TxtPago.Text = string.Format("{0:c}", Math.Truncate(this.Datos.Saldo * 10) / 10);
                }

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCobro ~ txt_Validating");
            }
        }

        #endregion

        private void btnAplicarTarjetaRegalo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this._Datos.IDCliente))
                {
                    Cliente Aux = new Cliente { IDCliente = this._Datos.IDCliente, IDTarjeta = this._Datos.IDTarjeta };
                    frmCanjearTarjetaRegalo ActivarTarjeta = new frmCanjearTarjetaRegalo(Aux);
                    ActivarTarjeta.ShowDialog();
                    ActivarTarjeta.Dispose();
                    if (ActivarTarjeta.DialogResult == DialogResult.OK)
                    {
                        this._Datos.Saldo = ActivarTarjeta.DatosAux.Saldo;
                        this.txtSaldoMonedero.Text = string.Format("{0:c}", this._Datos.Saldo);
                    }
                }
                else
                    MessageBox.Show("La venta debe tener un cliente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConcluirPago ~ btnAplicarTarjetaRegalo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
