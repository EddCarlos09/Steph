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
    public partial class frmPedidosRecepcion : Form
    {
        #region Variables
        private string TextoBusqueda = string.Empty;
        private bool   BandBusqueda = false;
        #endregion

        #region Constructor

        public frmPedidosRecepcion()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidosRecepcion ~ frmPedidosRecepcion()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaPedidos()
        {
            try
            {                
                this.TextoBusqueda = this.txtBusqueda.Text.Trim();
                Pedido Datos = new Pedido { Conexion = Comun.Conexion, BuscarTodos = this.chkTodosLosRegistros.Checked, FolioPedido = TextoBusqueda, IDSucursal = Comun.IDSucursalCaja };
                Pedido_Negocio PedNeg = new Pedido_Negocio();
                PedNeg.ObtenerPedidosSurtidosBusq(Datos);
                this.dgvPedidosPendientes.AutoGenerateColumns = false;
                this.dgvPedidosPendientes.DataSource = Datos.TablaDatos;
                BandBusqueda = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarPedidos()
        {
            try
            {
                    Pedido Datos = new Pedido { Conexion = Comun.Conexion, BuscarTodos = this.chkTodosLosRegistros.Checked, IDSucursal = Comun.IDSucursalCaja };
                    Pedido_Negocio PedNeg = new Pedido_Negocio();
                    PedNeg.ObtenerPedidosSurtidos(Datos);
                    this.dgvPedidosPendientes.AutoGenerateColumns = false;
                    this.dgvPedidosPendientes.DataSource = Datos.TablaDatos;
                    this.TextoBusqueda = string.Empty;
                    this.BandBusqueda = false;
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
                this.CargarPedidos();
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

        private Pedido ObtenerDatosGrid(int Row)
        {
            try
            {
                Pedido Datos = new Pedido();
                DataGridViewRow Fila = this.dgvPedidosPendientes.Rows[Row];
                Datos.IDPedidoSurtido = Fila.Cells["IDPedidoSurtido"].Value.ToString();
                Datos.IDPedido = Fila.Cells["IDPedido"].Value.ToString();
                Datos.FolioPedido = Fila.Cells["Folio"].Value.ToString();
                Datos.Estatus = Fila.Cells["EstatusPedido"].Value.ToString();
                int IDEstatus = 0;
                int.TryParse(Fila.Cells["IDEstatusPedido"].Value.ToString(), out IDEstatus);
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
                if (BandBusqueda)
                    this.BusquedaPedidos();
                else
                    this.CargarPedidos();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidosRecepcion ~ btnActualizar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    this.BusquedaPedidos();
                }
                else
                {
                    MessageBox.Show("Ingrese un texto en el campo de búsqueda.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidosRecepcion ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                if (BandBusqueda)
                {
                    this.txtBusqueda.Text = string.Empty;
                    this.CargarPedidos();
                    BandBusqueda = false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidosRecepcion ~ btnCancelarBusq_Click");
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
                LogError.AddExcFileTxt(ex, "frmPedidosRecepcion ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPedidosPendientes.SelectedRows.Count == 1)
                {
                    int Row = this.dgvPedidosPendientes.Rows.GetFirstRow(DataGridViewElementStates.Selected);
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
                LogError.AddExcFileTxt(ex, "frmPedidosRecepcion ~ btnDetallePedido_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPedidosPendientes.SelectedRows.Count == 1)
                {
                    int Row = this.dgvPedidosPendientes.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Pedido DatosAux = this.ObtenerDatosGrid(Row);
                    frmPedidoRecibir Detalle = new frmPedidoRecibir(DatosAux);
                    this.Visible = false;
                    Detalle.ShowDialog();
                    Detalle.Dispose();
                    if (Detalle.DialogResult == DialogResult.OK)
                        this.CargarPedidos();
                    this.Visible = true;
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmPedidosRecepcion ~ btnRecibir_Click");
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
                LogError.AddExcFileTxt(ex, "frmPedidosRecepcion ~ frmPedidos_Load");
            }
        }

        #endregion
    }
}
