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
using CreativaSL.LibControls.WinForms;
using StephSoft;
using System.IO;

namespace StephSoft
{
    public partial class frmMenuInicio : Form
    {
        #region Propiedades / Variables

        private bool TabNotasAbiertas = false;
        private bool TabNotasCerradas = false;

        #endregion

        #region Contructor

        public frmMenuInicio()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ frmMenuInicio()");
            }
        }

        #endregion

        #region Eventos

        private void btnCitas_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCitas cita = new frmCitas();
                cita.ShowDialog();
                cita.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCitas_Click");
            }
        }

        private void btnCatalogoFoto_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatalogoWeb CatWeb = new frmCatalogoWeb();
                this.Visible = false;
                CatWeb.ShowDialog();
                CatWeb.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCatalogoFoto_Click");
            }
        }

        private void btnAsignacionHorario_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatCiclos Ciclos = new frmCatCiclos();
                this.Visible = false;
                Ciclos.ShowDialog();
                Ciclos.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnAsignacionHorario_Click");
            }
        }

        private void btnVentaProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Comun.CajaAbierta)
                {
                    frmVentaDirecta VentasDirectas = new frmVentaDirecta();
                    this.Visible = false;
                    VentasDirectas.ShowDialog();
                    VentasDirectas.Dispose();
                    this.Visible = true;
                    if (VentasDirectas.DialogResult == DialogResult.OK)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("No hay caja abierta.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnVentaProducto_Click");
            }
        }

        private void btnChecadoEntradaSalida_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmChecador Checador = new frmChecador();
                Checador.ShowDialog();
                Checador.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnChecadoEntradaSalida_Click");
            }
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            try
            {
                frmPedidos Pedidos = new frmPedidos();
                this.Visible = false;
                Pedidos.ShowDialog();
                this.Visible = true;
                Pedidos.Dispose();
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnPedido_Click");
            }
        }

        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            try
            {
                frmCancelarTicket Cancelaciones = new frmCancelarTicket();
                this.Visible = false;
                Cancelaciones.ShowDialog();
                Cancelaciones.Dispose();
                this.Visible = true;
                this.TabNotasCerradas = false;
                this.LlenarGridNotasCerradas();
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCancelarTicket_Click");
            }
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            try
            {
                frmGastosXSucursal Gastos = new frmGastosXSucursal();
                Gastos.ShowDialog();
                Gastos.Dispose();
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnGastos_Click");
            }
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (Comun.CajaAbierta)
                {
                    Button_Creativa btn = (Button_Creativa)sender;
                    MenuStripCaja.Show(btn, btn.Width / 2, btn.Height);
                    MenuStripCaja.Focus();
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCaja_Click");
            }
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            try
            {
                                
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnComisiones_Click");
            }
        }

        private void btnInventarios_Click(object sender, EventArgs e)
        {
            try
            {
                frmInventario Inventario = new frmInventario();
                this.Visible = false;
                Inventario.ShowDialog();
                this.Visible = true;
                Inventario.Dispose();
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnInventarios_Click");
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCatClientes cliente = new frmCatClientes();
                cliente.ShowDialog();
                cliente.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnClientes_Click");
            }
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatEmpleado Empleados = new frmCatEmpleado();
                this.Visible = false;
                Empleados.ShowDialog();
                Empleados.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnPersonal_Click");
            }
        }

        private void btnReporteVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (Comun.CajaAbierta)
                {
                    Ticket Impresion = new Ticket(1, Comun.IDCaja);
                    Impresion.ImprimirTicket();
                }
                else
                {
                    MessageBox.Show("No hay caja abierta.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnReporteVenta_Click");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnSalir_Click");
            }
        }

        private void btnNuevoServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (Comun.CajaAbierta)
                {
                    frmNuevoTicket FrmTicket = new frmNuevoTicket();
                    FrmTicket.ShowDialog();
                    FrmTicket.Dispose();
                    if (FrmTicket.DialogResult == DialogResult.OK)
                    {
                        //Venta DatosVenta = FrmTicket.DatosVenta;
                        //DataTable Aux = (DataTable)this.dgvNotasAbiertas.DataSource;
                        //Aux.Rows.Add(new object[] { DatosVenta.IDVenta, 
                        //                            DatosVenta.IDEstatusVenta, 
                        //                            DatosVenta.IDCliente, 
                        //                            DatosVenta.FolioVenta, 
                        //                            DatosVenta.NombreCliente, 
                        //                            DatosVenta.HoraInicio, 
                        //                            "__:__:__", 
                        //                            string.Empty, 
                        //                            DatosVenta.TiempoTranscurridoSegundos, 
                        //                            DatosVenta.Subtotal, 
                        //                            DatosVenta.Descuento, 
                        //                            DatosVenta.Iva, 
                        //                            DatosVenta.Total });
                        //this.dgvNotasAbiertas.DataSource = null;
                        //this.dgvNotasAbiertas.DataSource = Aux;
                        //this.dgvNotasAbiertas.Sort(this.dgvNotasAbiertas.Columns["FolioVenta0"], ListSortDirection.Descending);
                        this.TabNotasAbiertas = false;
                        this.LlenarGridNotasAbiertas();
                    }

                }
                else
                {
                    MessageBox.Show("No hay caja abierta.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnNuevoServicio_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNotasAbiertas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    Venta DatosAux = this.ObtenerDatosGrid(e.RowIndex);
                    if (!string.IsNullOrEmpty(DatosAux.IDVenta))
                    {
                        frmVentaServicios FormServicio = new frmVentaServicios(DatosAux);
                        this.Visible = false;
                        FormServicio.ShowDialog();
                        this.Visible = true;
                        FormServicio.Dispose();
                        this.TabNotasAbiertas = false;                        
                        this.LlenarGridNotasAbiertas();
                        if (FormServicio.DialogResult == DialogResult.OK)
                        {
                            this.TabNotasCerradas = false;
                            //this.tcNotas.SelectedIndex = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ dgvNotasAbiertas_CellDoubleClick");
            }
        }

        private void frmMenuInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.F1)
                {
                    this.btnNuevoServicio_Click(this.btnNuevoServicio, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ frmMenuInicio_KeyPress");
            }
        }

        private void frmMenuInicio_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    this.btnNuevoServicio_Click(this.btnNuevoServicio, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ frmMenuInicio_KeyUp");
            }
        }

        private void frmMenuInicio_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ frmMenuInicio_Load");
            }
        }

        private void tcNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tcNotas.SelectedIndex == 0)
                {
                    this.LlenarGridNotasAbiertas();
                }
                else
                {
                    this.LlenarGridNotasCerradas();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ tcNotas_SelectedIndexChanged");
            }
        }
        
        private void toolsm_caja_cerrar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCierreCaja cerrarCaja = new frmCierreCaja();
                cerrarCaja.ShowDialog();
                cerrarCaja.Dispose();
                if (cerrarCaja.DialogResult == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Cancel;
                    frmVerReporte Reporte = new frmVerReporte(2, Comun.IDCaja);
                    this.Visible = false;
                    Reporte.ShowDialog();
                    Reporte.Dispose();
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_caja_cerrar_Click");
            }
        }

        private void toolsm_caja_depositos_Click(object sender, EventArgs e)
        {
            try
            {
                frmDepositosRetirosCaja retiros = new frmDepositosRetirosCaja(1);
                retiros.ShowDialog();
                retiros.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_caja_retiros_Click");
            }
        }

        private void toolsm_caja_retiros_Click(object sender, EventArgs e)
        {
            try
            {
                frmDepositosRetirosCaja retiros = new frmDepositosRetirosCaja(2);
                retiros.ShowDialog();
                retiros.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_caja_retiros_Click");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.PermisosUsuario();
                this.PermisoFilaUno();
                this.tcNotas_SelectedIndexChanged(this.tcNotas, new EventArgs());
                this.TimerTiempo.Enabled = true;
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
        private void PermisoFilaUno()
        {
            foreach (Control item in this.panelFilaUno.Controls)
	        {
                if (item is Button)
                {
                    Button Aux = (Button)item;
                    DataTable table = Comun.TablaPermisos;
                    DataRow[] PermisoUs;
                    string expression;
                    expression = "IDModulo=" + Aux.Tag;
                    PermisoUs = table.Select(expression);
                    if (PermisoUs.Length == 1)
                    {
                        bool Band;
                        DataRow Fila = PermisoUs[0];
                        bool.TryParse(Fila["Lectura"].ToString(), out Band);
                        if (Band)
                        {
                            Aux.Enabled = true;
                        }
                        else
                        {
                            Aux.Enabled = false;
                        }
                    }
                }
	        }
        }

        private void PermisosUsuario()
        {
            foreach (Control item in this.PanelMenu.Controls)
            {
                if (item is Button)
                {
                    Button Aux = (Button)item;
                    DataTable table = Comun.TablaPermisos;
                    DataRow[] PermisoUs;
                    string expression;
                    expression = "IDModulo=" + Aux.Tag;
                    PermisoUs = table.Select(expression);
                    if (PermisoUs.Length == 1)
                    {
                        bool Band;
                        DataRow Fila = PermisoUs[0];
                        bool.TryParse(Fila["Lectura"].ToString(), out Band);
                        if (Band)
                        {
                            Aux.Enabled = true;
                        }
                        else
                        {
                            Aux.Enabled = false;
                        }
                    }
                }
            }
        }

        private void LlenarGridNotasAbiertas()
        {
            try
            {
                if (!this.TabNotasAbiertas)
                {
                    Venta Datos = new Venta { IDEstatusVenta = 1, Actual = true, IDSucursal = Comun.IDSucursalCaja, FechaVenta = DateTime.Today, Conexion = Comun.Conexion };
                    Venta_Negocio VN = new Venta_Negocio();
                    VN.ObtenerVentasXFecha(Datos);
                    this.dgvNotasAbiertas.AutoGenerateColumns = false;
                    this.dgvNotasAbiertas.DataSource = null;
                    this.dgvNotasAbiertas.DataSource = Datos.TablaDatos;
                    this.TabNotasAbiertas = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridNotasCerradas()
        {
            try
            {
                if (!TabNotasCerradas)
                {
                    Venta Datos = new Venta { IDEstatusVenta = 2, Actual = true, IDSucursal = Comun.IDSucursalCaja, FechaVenta = DateTime.Today, Conexion = Comun.Conexion };
                    Venta_Negocio VN = new Venta_Negocio();
                    VN.ObtenerVentasXFecha(Datos);
                    this.dgvNotasCerradas.AutoGenerateColumns = false;
                    this.dgvNotasCerradas.DataSource = null;
                    this.dgvNotasCerradas.DataSource = Datos.TablaDatos;
                    this.TabNotasCerradas = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Venta ObtenerDatosGrid(int Row)
        {
            try
            {
                Venta DatosAux = new Venta();
                int Tab = this.tcNotas.SelectedIndex;
                DataGridView DGV = this.ObtenerDataGridView();
                if(DGV != null)
                {
                    int IDEstatusVenta = 0;
                    DatosAux.IDVenta = DGV.Rows[Row].Cells["IDVenta" + Tab].Value.ToString();
                    DatosAux.IDCliente = DGV.Rows[Row].Cells["IDCliente"+ Tab].Value.ToString();
                    DatosAux.NombreCliente = DGV.Rows[Row].Cells["NombreCliente" + Tab].Value.ToString();
                    DatosAux.FolioVenta = DGV.Rows[Row].Cells["FolioVenta" + Tab].Value.ToString();
                    int.TryParse(DGV.Rows[Row].Cells["IDEstatusVenta" + Tab].Value.ToString(), out IDEstatusVenta);
                    DatosAux.IDEstatusVenta = IDEstatusVenta;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataGridView ObtenerDataGridView()
        {
            try
            {
                DataGridView DGV = new DataGridView();
                int Tab = this.tcNotas.SelectedIndex;
                switch (Tab)
                {
                    case 0: DGV = this.dgvNotasAbiertas;
                        break;
                    case 1: DGV = this.dgvNotasCerradas;
                        break;
                    default: DGV = null;
                        break;
                }
                return DGV;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void bgwDibujarTiempo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Comun.FechaActual = Comun.FechaActual.AddSeconds(1);
                foreach (DataGridViewRow Fila in this.dgvNotasAbiertas.Rows)
                {
                    bool Completado = false;
                    bool.TryParse(Fila.Cells["Concluido0"].Value.ToString(), out Completado);
                    if (!Completado)
                    {
                        DateTime FechaInicio = DateTime.Parse(Fila.Cells["HoraInicio0"].Value.ToString());
                        TimeSpan Aux = Comun.FechaActual - FechaInicio;
                        string Texto = Aux.ToString(@"d\.hh\:mm\:ss");
                        Fila.Cells["TiempoTranscurrido0"].Value = Texto;
                    }
                }
            }
            catch (Exception ex)
            {
                this.TimerTiempo.Start();
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwDibujarTiempo_DoWork");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwDibujarTiempo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.TimerTiempo.Start();
            }
            catch (Exception ex)
            {
                this.TimerTiempo.Start();
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwDibujarTiempo_RunWorkerCompleted");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimerTiempo_Tick(object sender, EventArgs e)
        {
            try
            {
                this.TimerTiempo.Stop();
                this.bgwDibujarTiempo.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ TimerTiempo_Tick");
            }
        }

        private void lblConfuguraciones_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfiguracionLocal local = new frmConfiguracionLocal();
                local.ShowDialog();
                local.Dispose();
                if (local.DialogResult == DialogResult.OK)
                    this.Close();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ lblConfuguraciones_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblMiPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                frmPefilUsuario perfil = new frmPefilUsuario();
                perfil.ShowDialog();
                perfil.Dispose();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ lblMiPerfil_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecepcionMobiliario_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmMobiliarioRecepcion cita = new frmMobiliarioRecepcion();
                cita.ShowDialog();
                cita.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCitas_Click");
            }
        }

        private void btnGarantia_Click(object sender, EventArgs e)
        {
            try
            {
                frmGarantias Garantias = new frmGarantias();
                this.Visible = false;
                Garantias.ShowDialog();
                Garantias.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnGarantia_Click");
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaVentas Garantias = new frmBusquedaVentas();
                this.Visible = false;
                Garantias.ShowDialog();
                Garantias.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnGarantia_Click");
            }
        }

        private void btnDescantarExistencia_Click(object sender, EventArgs e)
        {
            frmDescontarExistencia DescExist = new frmDescontarExistencia();
            DescExist.ShowDialog();
            DescExist.Dispose();
            if (DescExist.DialogResult == DialogResult.OK)
            {
            }
        }
    }
}
