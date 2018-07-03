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
    public partial class frmPedidos : Form
    {
        #region Variables
        private bool Busqueda = false, Tab01 = false, Tab02 = false;
        private string TextoBusqueda = string.Empty;
        #endregion

        #region Constructor

        public frmPedidos()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidos ~ frmPedidos()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaPedidos(int Tab)
        {
            try
            {
                bool Band = this.ObtenerBandXTab(Tab);
                if (!Band)
                {
                    DataGridView DGV = this.ObtenerDGVXTab(Tab);
                    this.TextoBusqueda = this.txtBusqueda.Text.Trim();
                    Pedido Datos = new Pedido { Conexion = Comun.Conexion, Opcion = Tab, BuscarTodos = this.chkTodosLosRegistros.Checked, FolioPedido = TextoBusqueda, IDSucursal = Comun.IDSucursalCaja };
                    Pedido_Negocio PedNeg = new Pedido_Negocio();
                    PedNeg.ObtenerPedidosTabBusq(Datos);
                    DGV.AutoGenerateColumns = false;
                    DGV.DataSource = Datos.TablaDatos;
                    this.Busqueda = true;
                    this.SetBandXTab(Tab, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarPedidosTab(int Tab)
        {
            try
            {
                bool Band = this.ObtenerBandXTab(Tab);
                if (!Band)
                {
                    DataGridView DGV = this.ObtenerDGVXTab(Tab);
                    Pedido Datos = new Pedido { Conexion = Comun.Conexion, Opcion = Tab, BuscarTodos = this.chkTodosLosRegistros.Checked, IDSucursal = Comun.IDSucursalCaja };
                    Pedido_Negocio PedNeg = new Pedido_Negocio();
                    PedNeg.ObtenerPedidosTab(Datos);
                    DGV.AutoGenerateColumns = false;
                    DGV.DataSource = Datos.TablaDatos;
                    this.TextoBusqueda = string.Empty;
                    this.Busqueda = false;
                    this.SetBandXTab(Tab, true);
                }
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
                int Tab = this.tabControl1.SelectedIndex;
                this.SetBandXTab(Tab, false);
                this.CargarPedidosTab(Tab);
                this.ActiveControl = this.txtBusqueda;
                this.txtBusqueda.Focus();
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

        private DataGridView ObtenerDGVXTab(int Tab)
        {
            try
            {
                DataGridView DGV = new DataGridView();
                switch (Tab)
                {
                    case 0: DGV = this.dgvPedidosPendientes;
                        break;
                    case 1: DGV = this.dgvPedidosConcluidos;
                        break;
                    default: DGV = this.dgvPedidosPendientes;
                        break;
                }
                return DGV;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ObtenerBandXTab(int Tab)
        {
            try
            {
                bool Band = false;
                switch (Tab)
                {
                    case 0: Band = this.Tab01;
                        break;
                    case 1: Band = this.Tab02;
                        break;
                    default: Band = false;
                        break;
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetBandXTab(int Tab, bool Band)
        {
            try
            {
                switch (Tab)
                {
                    case 0: this.Tab01 = Band;
                        break;
                    case 1: this.Tab02 = Band;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Pedido ObtenerDatosGrid(int Row)
        {
            try
            {
                Pedido Datos = new Pedido();
                int Tab = this.tabControl1.SelectedIndex;
                DataGridViewRow Fila = this.ObtenerDGVXTab(Tab).Rows[Row];
                Datos.IDPedido = Fila.Cells["IDPedido" + Tab].Value.ToString();
                Datos.FolioPedido = Fila.Cells["Folio" + Tab].Value.ToString();
                Datos.Estatus = Fila.Cells["EstatusPedido" + Tab].Value.ToString();
                int IDEstatus = 0;
                int.TryParse(Fila.Cells["IDEstatusPedido" + Tab].Value.ToString(), out IDEstatus);
                Datos.IDEstatus = IDEstatus;
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int Tab = this.tabControl1.SelectedIndex;
                this.Tab01 = false;
                this.Tab02 = false;
                if (Busqueda)
                    this.BusquedaPedidos(Tab);
                else
                    this.CargarPedidosTab(Tab);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    Tab01 = false;
                    Tab02 = false;
                    int Tab = this.tabControl1.SelectedIndex;
                    this.BusquedaPedidos(Tab);
                }
                else
                {
                    MessageBox.Show("Ingrese un texto en el campo de búsqueda.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                if (Busqueda)
                {
                    this.txtBusqueda.Text = string.Empty;
                    int Tab = this.tabControl1.SelectedIndex;
                    Tab01 = false;
                    Tab02 = false;
                    this.CargarPedidosTab(Tab);
                    Busqueda = false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnCancelarBusq_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                int Tab = this.tabControl1.SelectedIndex;
                DataGridView DGV = this.ObtenerDGVXTab(Tab);
                if (DGV.SelectedRows.Count == 1)
                {
                    int RowToDelete = DGV.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Pedido DatosAux = this.ObtenerDatosGrid(RowToDelete);
                    if (DatosAux.IDEstatus == 1)
                    {
                        if (MessageBox.Show("¿Está seguro de eliminar el pedido? El proceso no es reversible.", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DatosAux.IDUsuario = Comun.IDUsuario;
                            DatosAux.Conexion = Comun.Conexion;
                            Pedido_Negocio PedNeg = new Pedido_Negocio();
                            PedNeg.EliminarPedido(DatosAux);
                            if (DatosAux.Completado)
                            {
                                Tab01 = false;
                                if (!Busqueda)
                                    this.CargarPedidosTab(Tab);
                                else
                                    this.BusquedaPedidos(Tab);
                            }
                            else
                                MessageBox.Show("Ocurrió un error al procesar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("El pedido debe estar en estatus Creado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoPedido Nuevo = new frmNuevoPedido();
                this.Visible = false;
                Nuevo.ShowDialog();
                Nuevo.Dispose();
                if (Nuevo.DialogResult == DialogResult.OK)
                {
                    Tab01 = false;
                    int Tab = this.tabControl1.SelectedIndex;
                    if (!Busqueda)
                        this.CargarPedidosTab(Tab);
                    else
                        this.BusquedaPedidos(Tab);
                }
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int Tab = this.tabControl1.SelectedIndex;
                DataGridView DGV = this.ObtenerDGVXTab(Tab);
                if (DGV.SelectedRows.Count == 1)
                {
                    int RowToUpdate = DGV.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Pedido DatosAux = this.ObtenerDatosGrid(RowToUpdate);
                    if (DatosAux.IDEstatus == 1)
                    {
                        frmNuevoPedido Nuevo = new frmNuevoPedido(DatosAux);
                        this.Visible = false;
                        Nuevo.ShowDialog();
                        Nuevo.Dispose();
                        //if (Nuevo.DialogResult == DialogResult.OK)
                        //{
                        //     No se modifica ningún campo de la tabla
                        //}
                        this.Visible = true;
                    }
                    else
                        MessageBox.Show("El pedido debe estar en estatus Creado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcesarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                int Tab = this.tabControl1.SelectedIndex;
                DataGridView DGV = this.ObtenerDGVXTab(Tab);
                if (DGV.SelectedRows.Count == 1)
                {
                    int RowToUpdate = DGV.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Pedido DatosAux = this.ObtenerDatosGrid(RowToUpdate);
                    if (DatosAux.IDEstatus == 1)
                    {
                        if (MessageBox.Show("¿Está seguro de enviar el pedido? El proceso no es reversible.", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DatosAux.IDUsuario = Comun.IDUsuario;
                            DatosAux.Conexion = Comun.Conexion;
                            Pedido_Negocio PedNeg = new Pedido_Negocio();
                            PedNeg.EnviarPedido(DatosAux);
                            if (DatosAux.Completado)
                            {
                                Tab01 = false;
                                if (!Busqueda)
                                    this.CargarPedidosTab(Tab);
                                else
                                    this.BusquedaPedidos(Tab);
                            }
                            else
                                MessageBox.Show("Ocurrió un error al procesar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("El pedido debe estar en estatus Creado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnProcesarPedido_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            try
            {
                int Tab = this.tabControl1.SelectedIndex;
                DataGridView DGV = this.ObtenerDGVXTab(Tab);
                if (DGV.SelectedRows.Count == 1)
                {
                    int Row = DGV.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Pedido DatosAux = this.ObtenerDatosGrid(Row);
                    frmPedidoDetalle Detalle = new frmPedidoDetalle(DatosAux);
                    this.Visible = false;
                    Detalle.ShowDialog();
                    Detalle.Dispose();
                    this.Visible = true;
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnDetallePedido_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidos ~ frmPedidos_Load");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Tab = this.tabControl1.SelectedIndex;
                if (Busqueda)
                    this.BusquedaPedidos(Tab);
                else
                    this.CargarPedidosTab(Tab);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnSurtir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnRecepcionPedido_Click(object sender, EventArgs e)
        {
            try
            {
                frmPedidosRecepcion Recepcion = new frmPedidosRecepcion();
                this.Visible = false;
                Recepcion.ShowDialog();
                Recepcion.Dispose();
                this.Visible = true;
                this.Tab01 = false;
                this.Tab02 = false;
                this.tabControl1_SelectedIndexChanged(this.tabControl1, new EventArgs());
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmPedidos ~ btnRecepcionPedido_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
