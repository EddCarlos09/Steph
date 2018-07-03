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
    public partial class frmCobro : Form
    {
        private string IDVenta = string.Empty;
        private Vales Vale = new Vales();
        private Cobro DatosCobro = new Cobro();
        public bool BandCambios = false;

        public frmCobro(string ID)
        {
            try
            {
                InitializeComponent();
                IDVenta = ID;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCobro ~ frmCobro()");             
            }
        }

        #region Métodos 

        private void IniciarForm()
        {
            try
            {
                DatosCobro = this.ObtenerDatosAPagarXIDVenta();
                this.DibujarDatos(DatosCobro);
                this.ActiveControl = this.txtVale;
                this.txtVale.Focus();
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

        private void DibujarDatos(Cobro DatosAux)
        {
            try
            {
                this.txtNombreCliente.Text = DatosAux.Cliente;
                this.txtMonedero.Text = string.Format("{0:c}", DatosAux.Saldo);
                this.txtPuntosObtenidos.Text = string.Format("{0:c}", DatosAux.PuntosVenta);
                this.txtNumTarjeta.Text = DatosAux.NumTarjeta;

                this.txtSubtotal.Text = string.Format("{0:c}", DatosAux.Subtotal);
                this.txtDescuento.Text = string.Format("{0:c}", DatosAux.Descuento);
                this.txtTotal.Text = string.Format("{0:c}", DatosAux.TotalAPagar);

                //this.txtPagoMonedero.Text = string.Format("{0:c}", 0);
                //this.txtPagoEfectivo.Text = string.Format("{0:c}", 0);
                //this.txtPagoTarjetaCred.Text = string.Format("{0:c}", 0);
                //this.txtPagoTarjetaDeb.Text = string.Format("{0:c}", 0);

                //this.txtPagoTotal.Text = string.Format("{0:c}", 0);
                //this.txtCambio.Text = string.Format("{0:c}", 0);

                this.txtValeAplicado.Text = DatosAux.FolioVale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Cobro ObtenerDatosAPagarXIDVenta()
        {
            try
            {
                Cobro DatosAux = new Cobro { Conexion = Comun.Conexion, IDVenta = this.IDVenta };
                Venta_Negocio VN = new Venta_Negocio();
                VN.ObtenerDatosCobroXIDVenta(DatosAux);
                if (DatosAux.Completado)
                    return DatosAux;
                else
                    return new Cobro();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MensajeErrorVale(int Error)
        {
            try
            {
                this.txtErrorVale.Visible = true;
                switch (Error)
                {
                    case -1: this.txtErrorVale.Text = "Código de vale incorrecto."; //Vale no existe
                        break;
                    case -2: this.txtErrorVale.Text = "Código de vale duplicado. Contacte a su administrador."; //Folio de vale duplicado
                        break;
                    case -3: this.txtErrorVale.Text = "El vale no está activo."; //Vale no activo
                        break;
                    case -4: this.txtErrorVale.Text = "El vale alcanzó la cantidad límite."; //alcanzó cantidad limite
                        break;
                    case -5: this.txtErrorVale.Text = "El vale no está vigente.";//Verificar la vigencia del vale
                        break;
                    case -6: this.txtErrorVale.Text = "Verifique los días de la semana de vigencia del vale.";//Verificar los días de vigencia deñ vale
                        break;
                    case -7: this.txtErrorVale.Text = "Cliente no válido.";//Cliente no válido
                        break;
                    case -8: this.txtErrorVale.Text = "Tipo de vale no válido.";//Tipo de vale no válido
                        break;
                    case -9: this.txtErrorVale.Text = "No se encontraron reglas del vale NXN.";//No se ecnontraron reglas NXN
                        break;
                    case -10: this.txtErrorVale.Text = "No se cumplen las reglas del vale."; //No cumple las reglas NXN
                        break;
                    case -11: this.txtErrorVale.Text = "No se encontraron reglas del vale NXM."; // No se ecnontraron reglas NXM
                        break;
                    case -12: this.txtErrorVale.Text = "No se cumplen las reglas del vale.";//No cumple las reglas NXM
                        break;
                    case -13: this.txtErrorVale.Text = "Solo se admite un vale por venta.";// Ya hay un vale aplicado en la venta
                        break;
                    default: this.txtErrorVale.Text = "Ocurrió un error. Código del error: " + Error;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnAplicarVale_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtErrorVale.Visible = false;
                Vales Datos = new Vales { IDVenta = this.IDVenta, IDCliente = (DatosCobro != null ? DatosCobro.IDCliente : string.Empty), 
                                          Folio = this.txtVale.Text.Trim(), IDUsuario = Comun.IDUsuario, Conexion = Comun.Conexion };
                Venta_Negocio VN = new Venta_Negocio();
                Cobro DatosAux = VN.AplicarVale(Datos);
                if (DatosAux.Completado)
                {
                    BandCambios = true;
                    DatosCobro = DatosAux;
                    this.Vale = new Vales { IDVale = DatosCobro.IDVale, Folio = DatosAux.FolioVale };
                    this.DibujarDatos(DatosCobro);
                    this.txtValeAplicado.Text = Datos.Folio;
                    this.ActiveControl = this.btnCobrar;
                    this.btnCobrar.Focus();
                }
                else
                {
                    this.MensajeErrorVale(DatosAux.Resultado);
                    this.ActiveControl = this.txtVale;
                    this.txtVale.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCobro ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmCobro ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                frmConcluirPago Cobrar = new frmConcluirPago(new Cobro());
                this.Visible = false;
                Cobrar.ShowDialog();
                this.Visible = true;
                Cobrar.Dispose();
                if (Cobrar.DialogResult == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCobro ~ btnCobrar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCobro_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCobro ~ frmCobro_Load");                
            }
        }

        private void txtVale_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    this.btnAplicarVale_Click(this.btnAplicarVale, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCobro ~ txtVale_KeyPress");
            }
        }

        #endregion

        //private void txt_Validating(object sender, CancelEventArgs e)
        //{
        //    try
        //    {
        //        TextBox TxtPago = (TextBox)sender;
        //        decimal Monto = this.ObtenerMontoTextBox(TxtPago);
        //        TxtPago.Text = string.Format("{0:c}", Monto);
        //        if (TxtPago.Name == this.txtMonedero.Name)
        //        {
        //            if(Monto > this.DatosCobro.Saldo)
        //                TxtPago.Text = string.Format("{0:c}", DatosCobro.Saldo);
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.AddExcFileTxt(ex, "frmCobro ~ txt_Validating");
        //    }
        //}

        //private void txt_Validated(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.DibujarTotales();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private void txt_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        TextBox TxtPago = (TextBox)sender;
        //        Validaciones.PermitirSoloNumerosDecimales(e, TxtPago.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.AddExcFileTxt(ex, "frmCobro ~ txt_KeyPress");
        //    }
        //}
        
        //private void txt_KeyUp(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        this.DibujarTotales();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.AddExcFileTxt(ex, "frmCobro ~ txt_KeyUp");
        //    }
        //}

        //private decimal CalcularTotalPago()
        //{
        //    try
        //    {
        //        decimal PagoEfectivo = 0, PagoMonedero = 0, PagoTC = 0, PagoTD = 0, PagoTotal = 0;
        //        decimal.TryParse(this.txtPagoEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PagoEfectivo);
        //        decimal.TryParse(this.txtPagoMonedero.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PagoMonedero);
        //        decimal.TryParse(this.txtPagoTarjetaCred.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PagoTC);
        //        decimal.TryParse(this.txtPagoTarjetaDeb.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PagoTD);
        //        PagoTotal = PagoEfectivo + PagoMonedero + PagoTC + PagoTD;
        //        return PagoTotal;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private decimal CalcularCambio(decimal PagoTotal, decimal TotalAPagar)
        //{
        //    try
        //    {
        //        decimal Cambio = 0;
        //        if (PagoTotal > TotalAPagar)
        //            Cambio = PagoTotal - TotalAPagar;
        //        return Cambio;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private void DibujarTotales()
        //{
        //    try
        //    {
        //        decimal TotalPago = this.CalcularTotalPago();
        //        decimal Cambio = this.CalcularCambio(TotalPago, this.DatosCobro.TotalAPagar);
        //        this.txtPagoTotal.Text = string.Format("{0:c}", TotalPago);
        //        this.txtCambio.Text = string.Format("{0:c}", Cambio);
                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private decimal ObtenerMontoTextBox(TextBox Aux)
        //{
        //    try
        //    {
        //        decimal Pago = 0;
        //        decimal.TryParse(Aux.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Pago);
        //        return Pago;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
