using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephSoft
{
    public partial class Form1 : Form
    {
        #region Variables
        private bool Busqueda = false;
        #endregion

        #region Constructor

        public Form1()
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

        private void BusquedaPedidos()
        {
            try
            {
                //Validar datos de búsqueda
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarPedidosPendientes()
        {
            try
            {
                Pedido Datos = new Pedido { IDSucursal = Comun.IDSucursalCaja, IDEstatus = 1, Conexion = Comun.Conexion };
                Pedido_Negocio PedNeg = new Pedido_Negocio();
                PedNeg.ObtenerPedidosXIDEstatusXIDSucursal(Datos);
                this.dgvPedidos.AutoGenerateColumns = false;
                this.dgvPedidos.DataSource = Datos.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarPedidosBusq()
        {
            try
            {
               
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
                this.CargarPedidosPendientes();
                this.ActiveControl = this.btnBuscar;
                this.btnBuscar.Focus();
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
                DataGridViewRow Fila = this.dgvPedidos.Rows[Row];
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception)
            {

            }
            try
            {
                this.BusquedaPedidos();
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
                    this.dtpFecha.Value = DateTime.Today;
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
                if (this.dgvPedidos.SelectedRows.Count == 1)
                {
                    int RowToDelete = this.dgvPedidos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
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
                                this.CargarPedidosPendientes();
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
                    if (!Busqueda)
                        this.CargarPedidosPendientes();
                    else
                        this.CargarPedidosBusq();
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
                if (this.dgvPedidos.SelectedRows.Count == 1)
                {
                    int RowToUpdate = this.dgvPedidos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Pedido DatosAux = this.ObtenerDatosGrid(RowToUpdate);
                    if (DatosAux.IDEstatus == 1)
                    {
                        frmNuevoPedido Nuevo = new frmNuevoPedido(DatosAux);
                        this.Visible = false;
                        Nuevo.ShowDialog();
                        Nuevo.Dispose();
                        if (Nuevo.DialogResult == DialogResult.OK)
                        {
                        }
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
                if (this.dgvPedidos.SelectedRows.Count == 1)
                {
                    int RowToUpdate = this.dgvPedidos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
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
                                this.CargarPedidosPendientes();
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
                if (this.dgvPedidos.SelectedRows.Count == 1)
                {
                    int RowToUpdate = this.dgvPedidos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Pedido DatosAux = this.ObtenerDatosGrid(RowToUpdate);
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

        #endregion

    }
}
