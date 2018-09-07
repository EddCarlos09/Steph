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
    public partial class frmResumenVenta : Form
    {
        #region Variables

        private string IDVenta = string.Empty;
        private Vales Vale = new Vales();
        private Cobro DatosCobro = new Cobro();
        public bool BandCambios = false;        

        #endregion

        #region Constructor

        public frmResumenVenta(string ID)
        {
            try
            {
                InitializeComponent();
                IDVenta = ID;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmResumenVenta ~ frmResumenVenta()");             
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                DatosCobro = this.ObtenerDatosAPagarXIDVenta();                
                this.Vale = new Vales { IDVale = DatosCobro.IDVale, Folio = DatosCobro.FolioVale };
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

                this.txtPromociones.Visible = DatosAux.AplicaPromocion;
                this.btnDescCumpleaños.Visible = DatosAux.AplicaPromocion;
                if(DatosAux.AplicaPromocion)
                {
                    this.btnDescCumpleaños.Text = DatosAux.DescCumpleaños ? "Rem. Desc." : "Desc. Cumpl.";
                }

                this.txtValeAplicado.Text = DatosAux.FolioVale;
                this.dgvProductosXServicio.AutoGenerateColumns = false;
                this.dgvProductosXServicio.DataSource = DatosAux.TablaDatos;
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
                    case -15: this.txtErrorVale.Text = "No se cumplen las reglas del vale.";//No cumple las reglas Porcentaje
                        break;
                    case -16: this.txtErrorVale.Text = "No se cumplen las reglas del vale.";//No cumple las reglas Monto
                        break;
                    case -30:
                        this.txtErrorVale.Text = "Está aplicado el descuento por cumpleaños.";//No cumple las reglas Monto
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
                if (!string.IsNullOrEmpty(this.txtVale.Text.Trim()))
                {
                    this.txtErrorVale.Visible = false;
                    Vales Datos = new Vales
                    {
                        IDVenta = this.IDVenta,
                        IDCliente = (DatosCobro != null ? DatosCobro.IDCliente : string.Empty),
                        Folio = this.txtVale.Text.Trim(),
                        IDUsuario = Comun.IDUsuario,
                        Conexion = Comun.Conexion
                    };
                    Venta_Negocio VN = new Venta_Negocio();
                    Cobro DatosAux = VN.AplicarVale(Datos);
                    if (DatosAux.Completado)
                    {
                        BandCambios = true;
                        DatosCobro = DatosAux;
                        this.txtVale.Text = string.Empty;
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
                if (this.dgvProductosXServicio.Rows.Count > 0)
                {
                    frmConcluirPago Cobrar = new frmConcluirPago(DatosCobro);
                    this.Visible = false;
                    Cobrar.ShowDialog();
                    this.Visible = true;
                    Cobrar.Dispose();
                    if (Cobrar.DialogResult == DialogResult.OK)
                    {
                        Cobro DatosAux = Cobrar.Datos;

                        Venta_Negocio VN = new Venta_Negocio();
                        VN.CobroVentaServicios(DatosAux);
                        if (DatosAux.Completado)
                        {
                            Ticket Imprimir = new Ticket(2, 1, DatosAux.IDVenta);
                            Imprimir.ImprimirTicket();
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al guardar los datos. Código el error: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Exception AuxEx = new Exception("Ocurrió un error al guardar los datos. código del Error: " + DatosAux.Resultado);
                            LogError.AddExcFileTxt(AuxEx, "frmConcluirCobro ~ btnCobrar_Click");
                        }
                        //this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.DatosCobro.Saldo = Cobrar.Datos.Saldo;
                        this.txtMonedero.Text = string.Format("{0:c}", this.DatosCobro.Saldo);
                    }
                }
                else
                    MessageBox.Show("Debe agregar productos a la venta. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnRemoverVale_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Vale != null)
                {
                    if (!string.IsNullOrEmpty(Vale.IDVale))
                    {
                        Vales Datos = new Vales
                        {
                            IDVenta = this.IDVenta,
                            IDCliente = (DatosCobro != null ? DatosCobro.IDCliente : string.Empty),
                            IDVale = this.Vale != null ? Vale.IDVale : string.Empty,
                            IDUsuario = Comun.IDUsuario,
                            Conexion = Comun.Conexion
                        };
                        Venta_Negocio VN = new Venta_Negocio();
                        Cobro DatosAux = VN.RemoverVale(Datos);
                        if (DatosAux.Completado)
                        {
                            BandCambios = true;
                            DatosCobro = DatosAux;
                            this.Vale = new Vales();
                            this.DibujarDatos(DatosCobro);
                            this.txtValeAplicado.Text = string.Empty;
                            this.ActiveControl = this.btnCobrar;
                            this.btnCobrar.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error. Código del error: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCobro ~ btnRemoverVale_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDescCumpleaños_Click(object sender, EventArgs e)
        {
            try
            {
                if(DatosCobro.AplicaPromocion)
                {
                    string IDVenta = this.IDVenta;
                    string IDCliente = (DatosCobro != null ? DatosCobro.IDCliente : string.Empty);
                    string IDUsuario = Comun.IDUsuario;
                    string IDSucursal = Comun.IDSucursalCaja;

                    Venta_Negocio VentNeg = new Venta_Negocio();
                    if(DatosCobro.DescCumpleaños)
                    {
                        int ResultadoA = VentNeg.RemoverDescuentoCumpleaños(Comun.Conexion, IDVenta, IDUsuario);
                        if (ResultadoA == 1)
                        {
                            MessageBox.Show("El descuento por cumpleaños ha sido removido", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.IniciarForm();
                        }
                        else
                        {
                            string _ErrorMessage = string.Empty;
                            switch (ResultadoA)
                            {
                                case -1: _ErrorMessage = "El descuento no está aplicado.";
                                    break;
                                default: _ErrorMessage = "Ocurrió un error al procesar la información";
                                    break;
                            }
                            MessageBox.Show(_ErrorMessage, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {

                        Venta ResultadoA = VentNeg.AplicarDescuentoCumpleaños(Comun.Conexion, IDVenta, IDCliente, IDSucursal, IDUsuario);
                        if (ResultadoA.Resultado == 1)
                        {
                            MessageBox.Show("El descuento por cumpleaños ha sido aplicado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.IniciarForm();
                        }
                        else
                        {
                            string _ErrorMessage = string.Empty;
                            switch (ResultadoA.Resultado)
                            {
                                case -1:
                                    _ErrorMessage = "No se puede aplicar el descuento. Hay un vale aplicado.";
                                    break;
                                case -2:
                                    _ErrorMessage = "No se puede aplicar el descuento. No se encontró el cliente.";
                                    break;
                                case -3:
                                    _ErrorMessage = "No se puede aplicar el descuento. El mes del cumpleañero no coincide.";
                                    break;
                                case -4:
                                    _ErrorMessage = string.Format("No se puede aplicar el descuento. El usuario ya utilizó el descuento el día {0} en la sucursal {1}", ResultadoA.FechaVenta.ToShortDateString(), ResultadoA.NombreSucursal);
                                    break;
                                case -30:
                                    _ErrorMessage = "No se puede aplicar el descuento. Ya está aplicado.";
                                    break;
                                default:
                                    _ErrorMessage = "Ocurrió un error al procesar la información";
                                    break;
                            }
                            MessageBox.Show(_ErrorMessage, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmResumenVenta ~ btnDescCumpleaños_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCortesia_Click(object sender, EventArgs e)
        {
            try
            {
                frmAutorizacion Autorizar = new frmAutorizacion(1);
                Autorizar.ShowDialog();
                if(Autorizar.DialogResult == DialogResult.OK)
                {
                    string _IDUsuarioAutoriza = Autorizar.IDUsuario;
                    Venta_Negocio VenNeg = new Venta_Negocio();
                    Cobro DatosAux = new Cobro {Conexion = Comun.Conexion, IDVenta = DatosCobro.IDVenta, IDCaja = Comun.IDCaja,
                                                IDCajero = Comun.IDUsuario, TotalAPagar = DatosCobro.TotalAPagar,
                                                Comision = DatosCobro.Comision, Pago = 0, Cambio = 0, RequiereFactura = false,
                                                PuntosVenta = 0, IDUsuarioAutoriza = _IDUsuarioAutoriza, IDUsuario = Comun.IDUsuario };
                    VenNeg.CobroVentaServiciosCortesia(DatosAux);
                    if (DatosAux.Completado)
                    {
                        Ticket Imprimir = new Ticket(2, 1, DatosAux.IDVenta);
                        Imprimir.ImprimirTicket();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos. Código el error: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Exception AuxEx = new Exception("Ocurrió un error al guardar los datos. código del Error: " + DatosAux.Resultado);
                        LogError.AddExcFileTxt(AuxEx, "frmConcluirCobro ~ btnCobrar_Click");
                    }

                    
                }
            }
            catch(Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmResumenVenta ~ btnCortesia_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
