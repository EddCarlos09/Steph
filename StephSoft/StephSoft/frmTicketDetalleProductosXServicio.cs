using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft;
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
    public partial class frmTicketDetalleProductosXServicio : Form
    {

        #region Variables

        private string IDVentaServicio = string.Empty;
        private string IDVenta = string.Empty;
        private Producto Actual = new Producto();
        private Producto ActualUsos = new Producto();
        public bool BandCambios = false;
        private bool BandVales = false;

        #endregion

        #region Constructor

        public frmTicketDetalleProductosXServicio(VentaDetalle Datos, bool Band)
        {
            try
            {
                InitializeComponent();
                this.IDVentaServicio = Datos.IDVentaServicio;
                this.IDVenta = Datos.IDVenta;
                this.BandVales = Band;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ frmTicketDetalleProductosXServicio()");
            }
        }

        #endregion

        #region Métodos

        private void CargarGrid()
        {
            try
            {
                VentaDetalle VentaDet = new VentaDetalle { Conexion = Comun.Conexion, IDVentaServicio = this.IDVentaServicio };
                Venta_Negocio VN = new Venta_Negocio();
                VN.ObtenerProductosXIDVentaServicio(VentaDet);
                this.dgvProductosXServicio.AutoGenerateColumns = false;
                this.dgvProductosXServicio.DataSource = VentaDet.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridUsos()
        {
            try
            {
                VentaDetalle VentaDet = new VentaDetalle { Conexion = Comun.Conexion, IDVentaServicio = this.IDVentaServicio };
                Venta_Negocio VN = new Venta_Negocio();
                VN.ObtenerUsosXIDVentaServicio(VentaDet);
                this.dgvClavesProduccion.AutoGenerateColumns = false;
                this.dgvClavesProduccion.DataSource = VentaDet.TablaDatos;
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
                this.Actual = new Producto();
                this.txtProducto.Text = string.Empty;
                this.NumCantidadProducto.Value = 1;
                this.txtPrecio.Text = string.Format("{0:c}", 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarDatosUsos()
        {
            try
            {
                this.ActualUsos = new Producto();
                this.txtProductoUsos.Text = string.Empty;
                this.numCantidadUsos.Value = 1;
                this.LlenarComboClaves(string.Empty);
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
                this.CargarGrid();
                this.CargarGridUsos();
                this.IniciarDatos();
                this.IniciarDatosUsos();
                this.ActiveControl = this.btnElegirProducto;
                this.btnElegirProducto.Focus();
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

        private decimal ObtenerCantidad()
        {
            try
            {
                //decimal Cantidad = 0;
                //decimal.TryParse(this.txtCantidad.Text, out Cantidad);
                //return Cantidad;
                return NumCantidadProducto.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerCantidadUsos()
        {
            try
            {
                return this.numCantidadUsos.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerPrecio()
        {
            try
            {
                decimal Precio = 0;
                decimal.TryParse(this.txtPrecio.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Precio);
                return Precio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private VentaDetalle ObtenerDatosProducto(int Row)
        {
            try
            {
                VentaDetalle Aux = new VentaDetalle();
                DataGridViewRow Fila = this.dgvProductosXServicio.Rows[Row];
                Aux.IDProductoXVentaServicio = Fila.Cells["IDProductoXVentaServicio"].Value.ToString();
                Aux.IDProducto = Fila.Cells["IDProducto"].Value.ToString();
                Aux.IDVenta = this.IDVenta;
                Aux.IDVentaServicio = this.IDVentaServicio;
                Aux.IDSucursal = Comun.IDSucursalCaja;
                Aux.IDUsuario = Comun.IDUsuario;
                Aux.Conexion = Comun.Conexion;
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private VentaDetalle ObtenerDatosClaves(int Row)
        {
            try
            {
                VentaDetalle Aux = new VentaDetalle();
                DataGridViewRow Fila = this.dgvClavesProduccion.Rows[Row];
                Aux.IDClaveAsignacion = Fila.Cells["IDClaveProductoXServicio"].Value.ToString();
                bool Band = false;
                bool.TryParse(Fila.Cells["Extra"].Value.ToString(), out Band);
                Aux.ClaveExtra = Band;
                Aux.IDVenta = this.IDVenta;
                Aux.IDVentaServicio = this.IDVentaServicio;
                Aux.IDUsuario = Comun.IDUsuario;
                Aux.Conexion = Comun.Conexion;
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BandVales)
                {
                    if (!string.IsNullOrEmpty(this.Actual.IDProducto))
                    {
                        decimal Cantidad = this.ObtenerCantidad();
                        if (Cantidad > 0)
                        {
                            bool BandPrecio = true;
                            decimal Precio = 0;
                            if (this.Actual.IDTipoProducto == 4)
                            {
                                Precio = this.ObtenerPrecio();
                                if (Precio < 0)
                                    BandPrecio = false;
                            }
                            if (BandPrecio)
                            {
                                VentaDetalle DatosAux = new VentaDetalle
                                {
                                    IDVenta = this.IDVenta,
                                    IDVentaServicio = this.IDVentaServicio,
                                    IDSucursal = Comun.IDSucursalCaja,
                                    IDUsuario = Comun.IDUsuario,
                                    Conexion = Comun.Conexion,
                                    PrecioNormal = Precio,
                                    CantidadVenta = Cantidad,
                                    IDProducto = this.Actual.IDProducto
                                };
                                Venta_Negocio VN = new Venta_Negocio();
                                VN.AgregarProductoAServicio(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarGrid();
                                    this.IniciarDatos();
                                    this.btnElegirProducto.Focus();
                                    BandCambios = true;
                                }
                                else
                                {
                                    if (DatosAux.Resultado == -1)
                                    {
                                        MessageBox.Show("No se encontró el servicio. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else if (DatosAux.Resultado == -2)
                                    {
                                        MessageBox.Show("No hay existencias suficientes en la sucursal.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        MessageBox.Show(Comun.MensajeError + " Código del Error: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El precio del servicio no puede ser menor a $ 0.00.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                            MessageBox.Show("La cantidad debe ser mayor a 0.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Seleccione un producto.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("La venta tiene un vale aplicado. No se pueden agregar ni quitar productos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ btnAgregar_Click");
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
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(11);
                ElegirProducto.Location = this.txtProducto.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    this.Actual = ElegirProducto.Datos;
                    this.txtProducto.Text = this.Actual.NombreProducto;
                    this.NumCantidadProducto.Value = 1;
                    if (this.Actual.IDTipoProducto == 1)
                    {
                        this.lblPrecio.Visible = false;
                        this.txtPrecio.Visible = false;
                        this.NumCantidadProducto.ReadOnly = false;
                        this.NumCantidadProducto.Focus();
                    }
                    else
                    {
                        this.lblPrecio.Visible = true;
                        this.txtPrecio.Visible = true;
                        this.txtPrecio.Text = string.Format("{0:c}", 0);
                        this.NumCantidadProducto.ReadOnly = true;
                        this.txtPrecio.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ btnElegirProducto_Click");
            }
        }

        private void dgvProductosXServicio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (!BandVales)
                    {
                        if (MessageBox.Show("¿Está seguro de quitar el producto seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            VentaDetalle Datos = this.ObtenerDatosProducto(e.RowIndex);
                            Venta_Negocio VN = new Venta_Negocio();
                            VN.QuitarProductoServicio(Datos);
                            if (Datos.Completado)
                            {
                                this.CargarGrid();
                                BandCambios = true;
                            }
                            else
                            {
                                if (Datos.Resultado == -1)
                                {
                                    MessageBox.Show("No se encontró el servicio. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show(Comun.MensajeError + " Código del Error: " + Datos.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("La venta tiene un vale aplicado. No se pueden agregar ni quitar productos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ dgvProductosXServicio_CellDoubleClick");
            }
        }

        private void frmTicketDetalleProductosXServicio_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ frmTicketDetalleProductosXServicio_Load");
            }
        }

        #endregion

        private void btnElegirUsos_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(12);
                ElegirProducto.Location = this.txtProductoUsos.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    this.ActualUsos = ElegirProducto.Datos;
                    this.txtProductoUsos.Text = this.ActualUsos.NombreProducto;
                    this.txtMetrica.Text = this.ActualUsos.MetricaDesc;
                    this.numCantidadUsos.Value = 1;
                    this.LlenarComboClaves(this.ActualUsos.IDProducto);
                    this.cmbClavesProduccion.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ btnElegirProducto_Click");
            }
        }

        private void btnAgregarUsos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BandVales)
                {
                    if (!string.IsNullOrEmpty(this.ActualUsos.IDProducto))
                    {
                        decimal Cantidad = this.ObtenerCantidadUsos();
                        if (Cantidad > 0)
                        {
                            PedidoDetalle Item = this.ObtenerClaveSeleccionada();
                            if (!string.IsNullOrEmpty(Item.IDAsignacion))
                            {
                                VentaDetalle DatosAux = new VentaDetalle
                                {
                                    IDVenta = this.IDVenta,
                                    IDVentaServicio = this.IDVentaServicio,
                                    IDProducto = this.ActualUsos.IDProducto,
                                    IDClaveAsignacion = Item.IDAsignacion,
                                    CantidadVenta = Cantidad,
                                    ClaveEsEmpleado = Item.EsEmpleado,
                                    IDUsuario = Comun.IDUsuario,
                                    Conexion = Comun.Conexion
                                };
                                Venta_Negocio VN = new Venta_Negocio();
                                VN.AgregarClaveAServicio(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarGridUsos();
                                    this.IniciarDatosUsos();
                                    this.btnElegirUsos.Focus();
                                    BandCambios = true;
                                }
                                else
                                {
                                    MessageBox.Show(Comun.MensajeError + " Código del Error: " + DatosAux.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione una clave de producción.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                            MessageBox.Show("La cantidad debe ser mayor a 0.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Seleccione un producto.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("La venta tiene un vale aplicado. No se pueden agregar ni quitar productos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ btnAgregarUsos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTicketDetalleProductosXServicio_Resize(object sender, EventArgs e)
        {
            try
            {
                this.panelIzquierda.Size = new Size(this.panelBase.Width / 2, this.panelIzquierda.Height);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ frmTicketDetalleProductosXServicio_Resize");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboClaves(string IDProducto)
        {
            try
            {
                this.cmbClavesProduccion.Text = string.Empty;
                VentaDetalle DatosAux = new VentaDetalle { IDProducto = IDProducto, Conexion = Comun.Conexion, IDVentaServicio = this.IDVentaServicio };
                Venta_Negocio VN = new Venta_Negocio();
                List<PedidoDetalle> Lista = new List<PedidoDetalle>();
                if (!string.IsNullOrEmpty(IDProducto))
                {
                    Lista = VN.LlenarComboClavesProduccion(DatosAux);
                }
                this.cmbClavesProduccion.DataSource = Lista;
                this.cmbClavesProduccion.DisplayMember = "ClaveProduccion";
                this.cmbClavesProduccion.ValueMember = "IDAsignacion";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PedidoDetalle ObtenerClaveSeleccionada()
        {
            try
            {
                PedidoDetalle DatosAux = new PedidoDetalle();
                if (this.cmbClavesProduccion.Items.Count > 0)
                {
                    if (this.cmbClavesProduccion.SelectedIndex != -1)
                    {
                        DatosAux = (PedidoDetalle)this.cmbClavesProduccion.SelectedItem;
                    }
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtPrecio_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtPrecio.Text = string.Format("{0:c}", this.ObtenerPrecio());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ txtPrecio_Validating");
            }
        }

        private void dgvClavesProduccion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (!BandVales)
                    {
                        VentaDetalle Datos = this.ObtenerDatosClaves(e.RowIndex);
                        if (Datos.ClaveExtra)
                        {
                            if (MessageBox.Show("¿Está seguro de quitar la clave seleccionada?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Venta_Negocio VN = new Venta_Negocio();
                                VN.QuitarClaveAServicio(Datos);
                                if (Datos.Completado)
                                {
                                    this.CargarGridUsos();
                                    BandCambios = true;
                                }
                                else
                                {
                                    if (Datos.Resultado == -1)
                                    {
                                        MessageBox.Show("Sólo se pueden eliminar las claves extra al servicio.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        MessageBox.Show(Comun.MensajeError + " Código del Error: " + Datos.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //No se puede modificar
                            MessageBox.Show("Sólo se pueden eliminar las claves extra al servicio.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("La venta tiene un vale aplicado. No se pueden agregar ni quitar productos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTicketDetalleProductosXServicio ~ dgvProductosXServicio_CellDoubleClick");
            }
        }

    }
}
