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
    public partial class frmVentaDirecta : Form
    {
        #region Variables
        string IDVenta = string.Empty;
        string CodigoVale = string.Empty;
        string IDVale = string.Empty;
        Cliente DatosCliente = new Cliente();
        List<VentaDetalle> DetalleVenta = new List<VentaDetalle>();
        #endregion

        #region Constructor

        public frmVentaDirecta()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ frmVentaDirecta()");
            }
        }

        #endregion

        #region Métodos

        private void ActualizarCantidadProducto(VentaDetalle Datos)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private VentaDetalle ObtenerDatosGrid(int Row)
        {
            try
            {
                VentaDetalle Datos = new VentaDetalle();
                DataGridViewRow Fila = this.dgvProductosXServicio.Rows[Row];
                Datos.IDVentaDetalle = Fila.Cells["IDVentaDetalle"].Value.ToString();
                Datos.IDVenta = this.IDVenta;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.Conexion = Comun.Conexion;
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AgregarProductoAVentaPorCodigo(string Codigo)
        {
            try
            {
                VentaDetalle DatosAux = new VentaDetalle { Clave = Codigo, IDSucursal = Comun.IDSucursalCaja, IDUsuario = Comun.IDUsuario, CantidadVenta = 1, IDVenta = this.IDVenta, Conexion = Comun.Conexion };
                Venta_Negocio VN = new Venta_Negocio();
                VentaDetalle Item = VN.ObtenerProductoXClaveProducto(DatosAux);
                if (DatosAux.Completado)
                {
                    this.AgregarProducto(Item);
                }
                else
                {
                    switch (DatosAux.Resultado)
                    {
                        case -1: MessageBox.Show("Hay un vale agregado a la venta. Elimínelo para continuar. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case -2: MessageBox.Show("No existe la clave ingresada. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case -3: MessageBox.Show("No hay existencia suficiente. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case -4: MessageBox.Show("El producto no está marcado para venta. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        default: MessageBox.Show("Ocurrió un error. Cantacte a Soporte Técnico. Código del error: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
                this.txtCodigoProducto.SelectionStart = 0;
                this.txtCodigoProducto.SelectionLength = this.txtCodigoProducto.Text.Length;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AgregarProductoAVentaPorIDProducto(string IDProducto)
        {
            try
            {
                VentaDetalle DatosAux = new VentaDetalle { IDProducto = IDProducto, IDSucursal = Comun.IDSucursalCaja, IDUsuario = Comun.IDUsuario, CantidadVenta = 1, IDVenta = this.IDVenta, Conexion = Comun.Conexion };
                Venta_Negocio VN = new Venta_Negocio();
                VentaDetalle Item = VN.ObtenerProductoXIDProducto(DatosAux);
                if (DatosAux.Completado)
                {
                    this.AgregarProducto(Item);
                }
                else
                {
                    switch (DatosAux.Resultado)
                    {
                        case -1: MessageBox.Show("Hay un vale agregado a la venta. Elimínelo para continuar. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case -2: MessageBox.Show("No existe la clave ingresada. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case -3: MessageBox.Show("No hay existencia suficiente. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        default: MessageBox.Show("Ocurrió un error. Cantacte a Soporte Técnico. Código del error: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
                this.txtCodigoProducto.SelectionStart = 0;
                this.txtCodigoProducto.SelectionLength = this.txtCodigoProducto.Text.Length;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AgregarProducto(VentaDetalle DatosAux)
        {
            try
            {
                bool BandExiste = false;
                foreach (VentaDetalle Item in DetalleVenta)
                {
                    if (Item.IDVentaDetalle == DatosAux.IDVentaDetalle)
                    {
                        Item.PrecioNormal = DatosAux.PrecioNormal;
                        Item.CantidadVenta = DatosAux.CantidadVenta;
                        Item.Subtotal = DatosAux.Subtotal;
                        Item.Descuento = DatosAux.Descuento;
                        Item.Total = DatosAux.Total;
                        BandExiste = true;
                        break;
                    }
                }
                if (!BandExiste)
                    DetalleVenta.Add(DatosAux);
                this.CargarGridVentaDetalle();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Venta CalcularTotales()
        {
            try
            {
                Venta Datos = new Venta();
                decimal Subtotal = 0, Descuento = 0, Total = 0;
                foreach (VentaDetalle Item in DetalleVenta)
                {
                    Subtotal += Item.Subtotal;
                    Descuento += Item.Descuento;
                    Total += Item.Total;
                }
                if (!string.IsNullOrEmpty(this.DatosCliente.IDCliente))
                {
                    Datos.IDVenta = this.IDVenta;
                    Datos.IDCliente = this.DatosCliente.IDCliente;
                    Datos.Conexion = Comun.Conexion;
                    Venta_Negocio VN = new Venta_Negocio();
                    VN.ObtenerPuntosVenta(Datos);
                }
                Datos.Subtotal = Subtotal;
                Datos.Descuento = Descuento;
                Datos.Total = Total;
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CambiarCantidadVenta(VentaDetalle Aux)
        {
            try
            {
                foreach (VentaDetalle Item in DetalleVenta)
                {
                    if (Aux.IDVentaDetalle == Item.IDVentaDetalle)
                    {
                        Item.CantidadVenta = Aux.CantidadVenta;
                        Item.PrecioNormal = Aux.PrecioNormal;
                        Item.Subtotal = Aux.Subtotal;
                        Item.Descuento = Aux.Descuento;
                        Item.Total = Aux.Total;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridVentaDetalle()
        {
            try
            {
                BindingSource Datos = new BindingSource();
                Datos.DataSource = this.DetalleVenta;
                this.dgvProductosXServicio.AutoGenerateColumns = false;
                this.dgvProductosXServicio.DataSource = Datos;
                Venta DatosAux = this.CalcularTotales();
                this.DibujarTotales(DatosAux);
                int Row = this.dgvProductosXServicio.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                this.dgvProductosXServicio.Rows[Row].Selected = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DibujarTotales(Venta Datos)
        {
            try
            {
                this.txtSubtotal.Text = string.Format("{0:c}", Datos.Subtotal);
                this.txtDescuento.Text = string.Format("{0:c}", Datos.Descuento);
                this.txtTotal.Text = string.Format("{0:c}", Datos.Total);
                this.txtPuntosObtenidos.Text = string.Format("{0:c}", Datos.PuntosObtenidos);
                this.txtValeAplicado.Text = this.CodigoVale;
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
                this.txtCodigoProducto.Text = string.Empty;
                this.txtNombreCliente.Text = string.Empty;
                this.txtNumTarjeta.Text = string.Empty;
                this.txtValeAplicado.Text = string.Empty;
                this.txtVale.Text = string.Empty;
                this.txtMonedero.Text = string.Format("{0:c}", 0);
                this.txtSubtotal.Text = string.Format("{0:c}", 0);
                this.txtDescuento.Text = string.Format("{0:c}", 0);
                this.txtPuntosObtenidos.Text = string.Format("{0:c}", 0);
                this.txtTotal.Text = string.Format("{0:c}", 0);
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
                this.IniciarVenta();
                this.IniciarDatos();
                this.ActiveControl = this.txtCodigoProducto;
                this.txtCodigoProducto.Focus();
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

        private void IniciarVenta()
        {
            try
            {
                Venta Datos = new Venta();
                Datos.IDCaja = Comun.CajaAbierta ? Comun.IDCaja : string.Empty;
                Datos.IDSucursal = Comun.IDSucursalCaja;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.Conexion = Comun.Conexion;
                Venta_Negocio VN = new Venta_Negocio();
                VN.InsertarNuevaVenta(Datos);
                if (Datos.Completado)
                {
                    this.IDVenta = Datos.IDVenta;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
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
                    default: this.txtErrorVale.Text = "Ocurrió un error. Código del error: " + Error;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void QuitarItemLista(VentaDetalle Datos)
        {
            try
            {
                VentaDetalle AuxDel = null;
                foreach (VentaDetalle Item in DetalleVenta)
                {
                    if (Item.IDVentaDetalle == Datos.IDVentaDetalle)
                    {
                        AuxDel = Item;
                        break;
                    }
                }
                if (AuxDel != null)
                {
                    DetalleVenta.Remove(AuxDel);
                    this.CargarGridVentaDetalle();
                    this.CalcularTotales();
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
                        IDCliente = (DatosCliente != null ? DatosCliente.IDCliente : string.Empty),
                        Folio = this.txtVale.Text.Trim(),
                        IDUsuario = Comun.IDUsuario,
                        Conexion = Comun.Conexion
                    };
                    Venta_Negocio VN = new Venta_Negocio();
                    Cobro DatosAux = VN.AplicarVale(Datos);
                    if (DatosAux.Completado)
                    {
                        this.txtVale.Text = string.Empty;
                        this.IDVale = DatosAux.IDVale;
                        this.CodigoVale = DatosAux.FolioVale;

                        List<VentaDetalle> Lista = new List<VentaDetalle>();
                        VentaDetalle Item;
                        DataTableReader Dr = DatosAux.TablaDatos.CreateDataReader();
                        while (Dr.Read())
                        {
                            Item = new VentaDetalle();
                            Item.IDVentaDetalle = Dr.GetString(Dr.GetOrdinal("IDVentaDetalle"));
                            Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                            Item.Clave = Dr.GetString(Dr.GetOrdinal("Clave"));
                            Item.NombreProducto = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                            Item.PrecioNormal = Dr.GetDecimal(Dr.GetOrdinal("Precio"));
                            Item.CantidadVenta = Dr.GetDecimal(Dr.GetOrdinal("Cantidad"));
                            Item.Subtotal = Dr.GetDecimal(Dr.GetOrdinal("Subtotal"));
                            Item.Descuento = Dr.GetDecimal(Dr.GetOrdinal("Descuento"));
                            Item.Total = Dr.GetDecimal(Dr.GetOrdinal("Total"));

                            Lista.Add(Item);
                        }
                        this.DetalleVenta = Lista;
                        this.CargarGridVentaDetalle();
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
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ btnAplicarVale_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string IDAnterior = this.DatosCliente.IDCliente;
                frmSeleccionarCliente ElegirCliente = new frmSeleccionarCliente();
                ElegirCliente.Location = this.txtNombreCliente.PointToScreen(new Point());
                ElegirCliente.Location = new Point(ElegirCliente.Location.X - 1, ElegirCliente.Location.Y - 2);
                ElegirCliente.ShowDialog();
                ElegirCliente.Dispose();
                if (ElegirCliente.DialogResult == DialogResult.OK)
                {
                    Cliente Aux = ElegirCliente.Datos;
                    DatosCliente = Aux;
                    this.txtNombreCliente.Text = Aux.Nombre;
                    this.txtNumTarjeta.Text = Aux.FolioTarjeta;
                    this.txtMonedero.Text = string.Format("{0:c}", Aux.SaldoMonedero);
                }
                else
                {
                    this.txtPromociones.Visible = false;
                    this.DatosCliente = new Cliente();
                    this.txtNombreCliente.Text = string.Empty;
                    this.txtNumTarjeta.Text = string.Empty;
                    this.txtMonedero.Text = string.Format("{0:c}", 0);
                }
                if (!string.IsNullOrEmpty(this.IDVale) && !string.IsNullOrEmpty(IDAnterior))
                {
                    this.btnRemoverVale_Click(this.btnRemoverVale, new EventArgs());
                }
                this.DibujarTotales(this.CalcularTotales());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ btnBuscarCliente_Click");
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmElegirProductoBusq Producto = new frmElegirProductoBusq();
                Producto.ShowDialog();
                Producto.Dispose();
                if (Producto.DialogResult == DialogResult.OK)
                {
                    Producto DatosAux = Producto.Seleccionado;
                    this.AgregarProductoAVentaPorIDProducto(DatosAux.IDProducto);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ btnBuscarProducto_Click");
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
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DetalleVenta.Count > 0)
                {
                    Venta Datos = this.CalcularTotales();
                    Cobro DatosAux = new Cobro();
                    DatosAux.IDVenta = this.IDVenta;
                    DatosAux.TotalAPagar = Datos.Total;
                    DatosAux.PuntosVenta = Datos.PuntosObtenidos;
                    DatosAux.Saldo = this.DatosCliente.SaldoMonedero;
                    DatosAux.IDTarjeta = this.DatosCliente.IDTarjeta;
                    DatosAux.IDCliente = this.DatosCliente.IDCliente;
                    frmConcluirPago Cobrar = new frmConcluirPago(DatosAux);
                    this.Visible = false;
                    Cobrar.ShowDialog();
                    this.Visible = true;
                    Cobrar.Dispose();
                    if (Cobrar.DialogResult == DialogResult.OK)
                    {
                        DatosAux = Cobrar.Datos;
                        DatosAux.CodigoEmpleado = this.txtClaveVendedor.Text.Trim();
                        DatosAux.IDSucursal = Comun.IDSucursalCaja;
                        DatosAux.IDCliente = this.DatosCliente.IDCliente;
                        Venta_Negocio VN = new Venta_Negocio();
                        VN.CobroVenta(DatosAux);
                        if (DatosAux.Completado)
                        {
                            try
                            {
                                Ticket Imprimir = new Ticket(1, 1, DatosAux.IDVenta);
                                Imprimir.ImprimirTicket();
                                this.DialogResult = DialogResult.OK;
                            }
                            catch (Exception ex01)
                            {
                                LogError.AddExcFileTxt(ex01, "Error al imprimir: " + ex01.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al guardar los datos. Código el error: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Exception AuxEx = new Exception("Ocurrió un error al guardar los datos. código del Error: " + DatosAux.Resultado);
                            LogError.AddExcFileTxt(AuxEx, "frmConcluirCobro ~ btnCobrar_Click");
                        }
                    }
                    else
                    {
                        this.DatosCliente.SaldoMonedero = Cobrar.Datos.Saldo;
                    }
                }
                else
                {
                    MessageBox.Show("Debe agregar productos a la venta", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ btnCobrar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverVale_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.IDVale))
                {
                    Vales Datos = new Vales
                    {
                        IDVenta = this.IDVenta,
                        IDCliente = DatosCliente.IDCliente,
                        IDVale = this.IDVale,
                        IDUsuario = Comun.IDUsuario,
                        Conexion = Comun.Conexion
                    };
                    Venta_Negocio VN = new Venta_Negocio();
                    Cobro DatosAux = VN.RemoverVale(Datos);
                    if (DatosAux.Completado)
                    {
                        this.IDVale = string.Empty;
                        this.CodigoVale = string.Empty;

                        List<VentaDetalle> Lista = new List<VentaDetalle>();
                        VentaDetalle Item;
                        DataTableReader Dr = DatosAux.TablaDatos.CreateDataReader();
                        while (Dr.Read())
                        {
                            Item = new VentaDetalle();
                            Item.IDVentaDetalle = Dr.GetString(Dr.GetOrdinal("IDVentaDetalle"));
                            Item.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                            Item.Clave = Dr.GetString(Dr.GetOrdinal("Clave"));
                            Item.NombreProducto = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                            Item.PrecioNormal = Dr.GetDecimal(Dr.GetOrdinal("Precio"));
                            Item.CantidadVenta = Dr.GetDecimal(Dr.GetOrdinal("Cantidad"));
                            Item.Subtotal = Dr.GetDecimal(Dr.GetOrdinal("Subtotal"));
                            Item.Descuento = Dr.GetDecimal(Dr.GetOrdinal("Descuento"));
                            Item.Total = Dr.GetDecimal(Dr.GetOrdinal("Total"));

                            Lista.Add(Item);
                        }
                        this.DetalleVenta = Lista;
                        this.CargarGridVentaDetalle();
                        this.ActiveControl = this.btnCobrar;
                        this.btnCobrar.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error. Código del error: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvProductosXServicio_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    DataGridViewColumn Columna = this.dgvProductosXServicio.Columns[e.ColumnIndex];
                    if (Columna.Name == "Cantidad")
                    {
                        int Aux = 0;
                        if (!int.TryParse(e.FormattedValue.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Aux))
                        {
                            e.Cancel = true;
                            //this.dgvProductosXServicio.Rows[e.RowIndex].ErrorText = "Debe ingresar un dato válido en cantidad.";
                            this.txtErrorGrid.Visible = true;
                            this.txtErrorGrid.Text = "Debe ingresar un dato válido en cantidad.";
                        }
                        else
                        {
                            if (Aux <= 0)
                            {
                                e.Cancel = true;
                                this.txtErrorGrid.Visible = true;
                                this.txtErrorGrid.Text = "La cantidad debe ser mayor a 0.";
                                //this.dgvProductosXServicio.Rows[e.RowIndex].ErrorText = "La cantidad debe ser mayor o igual a 0.";
                            }
                            else
                            {
                                int CantAnterior = 0;
                                int.TryParse(this.dgvProductosXServicio.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString(), out CantAnterior);
                                if (Aux != CantAnterior)
                                {
                                    VentaDetalle DatosAux = new VentaDetalle();
                                    DatosAux.IDVentaDetalle = this.dgvProductosXServicio.Rows[e.RowIndex].Cells["IDVentaDetalle"].Value.ToString();
                                    DatosAux.CantidadVenta = (int)Aux;
                                    DatosAux.IDVenta = this.IDVenta;
                                    DatosAux.IDProducto = this.dgvProductosXServicio.Rows[e.RowIndex].Cells["IDProducto"].Value.ToString();
                                    DatosAux.IDSucursal = Comun.IDSucursalCaja;
                                    DatosAux.IDUsuario = Comun.IDUsuario;
                                    DatosAux.Conexion = Comun.Conexion;
                                    Venta_Negocio VN = new Venta_Negocio();
                                    VentaDetalle DatosResult = VN.CambiarCantidadVenta(DatosAux);
                                    if (DatosAux.Completado)
                                    {
                                        this.txtErrorGrid.Visible = false;
                                        this.CambiarCantidadVenta(DatosResult);
                                    }
                                    else
                                    {
                                        e.Cancel = true;
                                        this.txtErrorGrid.Visible = true;

                                        if (DatosAux.Resultado == -1)
                                        {
                                            this.txtErrorGrid.Text = "Hay un vale agregado en la venta, elimínelo para continuar.";
                                            //this.dgvProductosXServicio.Rows[e.RowIndex].ErrorText = "Hay un vale agregado en la venta, elimínelo para continuar.";
                                        }
                                        else if (DatosAux.Resultado == -3)
                                        {
                                            this.txtErrorGrid.Text = "No hay existencia suficiente.";
                                            //this.dgvProductosXServicio.Rows[e.RowIndex].ErrorText = "No hay existencia suficiente.";
                                        }
                                        else
                                        {
                                            this.txtErrorGrid.Text = "Ocurrió un error al consultar la información.";
                                            //this.dgvProductosXServicio.Rows[e.RowIndex].ErrorText = "Ocurrió un error al consultar la información.";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ dgvProductosXServicio_CellValidating");
            }
        }

        bool Band = false;

        private void dgvProductosXServicio_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && !Band)
                {
                    DataGridViewColumn Columna = this.dgvProductosXServicio.Columns[e.ColumnIndex];
                    if (Columna.Name == "Cantidad")
                    {
                        Band = true;
                        this.CargarGridVentaDetalle();
                    }
                }
                else
                {
                    if (Band)
                    {
                        Band = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ dgvProductosXServicio_CellValidated");
            }
        }

        private void dgvProductosXServicio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (MessageBox.Show("¿Está seguro de quitar el producto seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        VentaDetalle Datos = this.ObtenerDatosGrid(e.RowIndex);
                        Venta_Negocio VN = new Venta_Negocio();
                        VN.QuitarProductoVenta(Datos);
                        if (Datos.Completado)
                        {
                            this.QuitarItemLista(Datos);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ dgvProductosXServicio_CellValidated");
            }
        }

        private void frmVentaDirecta_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F10)
                    btnBuscarProducto_Click(this.btnBuscarProducto, new EventArgs());
                //if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                //    MessageBox.Show("+");
                //if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                //    MessageBox.Show("-");
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ frmVentaDirecta_KeyUp");
            }
        }

        private void frmVentaDirecta_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ frmVentaDirecta_Load");
            }
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                    this.AgregarProductoAVentaPorCodigo(this.txtCodigoProducto.Text.Trim());
                else
                    Validaciones.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ txtCodigoProducto_KeyPress");
            }
        }

        #endregion

        private void frmVentaDirecta_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.DialogResult != DialogResult.OK)
                {
                    Venta Datos = new Venta { IDVenta = this.IDVenta, IDUsuario = Comun.IDUsuario, Conexion = Comun.Conexion };
                    Venta_Negocio VN = new Venta_Negocio();
                    VN.QuitarVenta(Datos);
                    if (!Datos.Completado)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ frmVentaDirecta_FormClosing");
            }
        }

        private void txtClaveVendedor_Validated(object sender, EventArgs e)
        {
            try
            {
                MostrarNombreEmpleado(txtClaveVendedor.Text.Trim());
            }
            catch(Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaDirecta ~ txtClaveVendedor_Validated");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarNombreEmpleado(string _ClaveEmpleado)
        {
            try
            {
                if (!string.IsNullOrEmpty(_ClaveEmpleado))
                {
                    Usuario_Negocio Neg = new Usuario_Negocio();
                    string _Nombre = Neg.ObtenerNombreEmpleadoXClave(Comun.Conexion, Comun.IDSucursalCaja, _ClaveEmpleado);
                    txtNombreEmpleado.Text = _Nombre;
                    if (string.IsNullOrEmpty(_Nombre))
                    {
                        MessageBox.Show("Clave no encontrada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClaveVendedor.Text = string.Empty;
                        txtClaveVendedor.Focus();
                    }

                }
                else
                {
                    txtNombreEmpleado.Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
