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
    public partial class frmNuevoPedido : Form
    {        
        #region Propiedades / Variables
        private bool NuevoRegistro = true;
        private Pedido _DatosPedido;
        public Pedido DatosPedido
        {
            get { return _DatosPedido; }
            set { _DatosPedido = value; }
        }
        #endregion

        #region Constructor(es)

        public frmNuevoPedido()
        {
            try
            {
                InitializeComponent();
                this._DatosPedido = new Pedido();
                this._DatosPedido.DetallePedido = new List<PedidoDetalle>();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedido ~ frmNuevoPedido()");
            }
        }

        public frmNuevoPedido(Pedido Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosPedido = Datos;
                this.NuevoRegistro = false;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedido ~ frmNuevoPedido(Pedido Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridPedidoDetalle()
        {
            try
            {
                this.dgvPedidoDetalle.AutoGenerateColumns = false;
                this.dgvPedidoDetalle.DataSource = null;
                this.dgvPedidoDetalle.DataSource = this._DatosPedido.DetallePedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void CargarDatosAModificar(Pedido Datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(Datos.IDPedido.Trim()))
                {
                    this.txtFolioPedido.Text = this._DatosPedido.FolioPedido;
                    this.CargarGridPedidoDetalle();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnLista(PedidoDetalle Item)
        {
            try
            {
                bool Band = false;
                foreach (PedidoDetalle ItemLista in this._DatosPedido.DetallePedido)
                {
                    if (ItemLista.IDProducto == Item.IDProducto && ItemLista.IDEmpleado == Item.IDEmpleado && string.IsNullOrEmpty(ItemLista.IDAsignacion))
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemClaveEnLista(PedidoDetalle Item)
        {
            try
            {
                bool Band = false;
                foreach (PedidoDetalle ItemLista in this._DatosPedido.DetallePedido)
                {
                    if (ItemLista.IDProducto == Item.IDProducto && ItemLista.IDEmpleado == Item.IDEmpleado && ItemLista.IDAsignacion == Item.IDAsignacion)
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaPedidoDetalle()
        {
            try
            {
                DataTable Aux = new DataTable();
                Aux.Columns.Add("IDPedidoDetalle", typeof(string));
                Aux.Columns.Add("IDProducto", typeof(string));
                Aux.Columns.Add("Cantidad", typeof(decimal));
                Aux.Columns.Add("IDEmpleado", typeof(string));
                Aux.Columns.Add("IDAsignacion", typeof(string));
                Aux.Columns.Add("ClaveProduccion", typeof(string));
                foreach (PedidoDetalle Item in this._DatosPedido.DetallePedido)
                {
                    object[] Fila = { Item.IDPedidoDetalle, Item.IDProducto, Item.Cantidad, Item.IDEmpleado, Item.IDAsignacion, Item.ClaveProduccion };
                    Aux.Rows.Add(Fila);
                }
                return Aux;
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
                if (!NuevoRegistro)
                {
                    this._DatosPedido.DetallePedido = this.ObtenerDetallePedidoXID(this._DatosPedido.IDPedido);
                    this.CargarDatosAModificar(this._DatosPedido);
                }                
                this.LlenarTablaProductos();
                this.ActiveControl = this.btnAgregarProducto;
                this.btnAgregarProducto.Focus();
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

        private void LlenarTablaProductos()
        {
            try
            {
                //this.dgvProveedor.DataSource = null;
                //this.dgvProveedor.AutoGenerateColumns = false;
                //this.dgvProveedor.DataSource = ProveedoresXProducto;
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

        private Pedido ObtenerDatos()
        {
            try
            {
                Pedido DatosAux = new Pedido();
                DatosAux.NuevoRegistro = NuevoRegistro;
                DatosAux.IDPedido = NuevoRegistro ? string.Empty : this._DatosPedido.IDPedido;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.TablaDatos = this.GenerarTablaPedidoDetalle();
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.Conexion = Comun.Conexion;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PedidoDetalle ObtenerDatosGrid(int Row)
        {
            try
            {
                PedidoDetalle DatosAux = new PedidoDetalle();
                DataGridViewRow Fila = this.dgvPedidoDetalle.Rows[Row];
                DatosAux.IDPedidoDetalle = Fila.Cells["IDPedidoDetalle"].Value.ToString();
                DatosAux.IDProducto = Fila.Cells["IDProducto"].Value.ToString();
                DatosAux.IDEmpleado = Fila.Cells["IDEmpleado"].Value.ToString();
                DatosAux.IDAsignacion = Fila.Cells["IDAsignacion"].Value.ToString();
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<PedidoDetalle> ObtenerDetallePedidoXID(string IDPedido)
        {
            try
            {
                Pedido_Negocio PedNeg = new Pedido_Negocio();
                return PedNeg.ObtenerDetallePedido(new Pedido { IDPedido = IDPedido, Conexion = Comun.Conexion });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RemoverItem(int RowToDelete)
        {
            try
            {
                PedidoDetalle DatosAux = this.ObtenerDatosGrid(RowToDelete);
                PedidoDetalle ItemToDelete = null;
                if (!string.IsNullOrEmpty(DatosAux.IDPedidoDetalle))
                {
                    foreach (PedidoDetalle Item in this._DatosPedido.DetallePedido)
                    {
                        if (Item.IDPedidoDetalle == DatosAux.IDPedidoDetalle)
                        {
                            ItemToDelete = Item;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (PedidoDetalle Item in this._DatosPedido.DetallePedido)
                    {
                        if (Item.IDProducto == DatosAux.IDProducto && Item.IDEmpleado == DatosAux.IDEmpleado && Item.IDAsignacion == DatosAux.IDAsignacion)
                        {
                            ItemToDelete = Item;
                            break;
                        }
                    }
                }
                if (ItemToDelete != null)
                {
                    this._DatosPedido.DetallePedido.Remove(ItemToDelete);
                    this.CargarGridPedidoDetalle();
                }
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
                if(this.dgvPedidoDetalle.Rows.Count == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe agregar al menos un producto al pedido.", ControlSender = this.dgvPedidoDetalle });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos    
        
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {

                frmNuevoPedidoProducto AgregarProducto = new frmNuevoPedidoProducto();
                AgregarProducto.ShowDialog();
                AgregarProducto.Dispose();
                if (AgregarProducto.DialogResult == DialogResult.OK)
                {
                    PedidoDetalle Aux = AgregarProducto.Datos;
                    if (!this.ExisteItemEnLista(Aux))
                    {
                        Aux.IDPedidoDetalle = string.Empty;
                        Aux.IDPedido = NuevoRegistro ? string.Empty : this._DatosPedido.IDPedido;
                        this._DatosPedido.DetallePedido.Add(Aux);
                        this.CargarGridPedidoDetalle();
                    }
                    else
                        MessageBox.Show("El producto ya se encuentra agregado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedido ~ btnAgregarProducto_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReemplazar_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoPedidoReemplazoProducto AgregarProducto = new frmNuevoPedidoReemplazoProducto();
                AgregarProducto.ShowDialog();
                AgregarProducto.Dispose();
                if (AgregarProducto.DialogResult == DialogResult.OK)
                {
                    PedidoDetalle Aux = AgregarProducto.Datos;
                    if (!this.ExisteItemClaveEnLista(Aux))
                    {
                        Aux.IDPedidoDetalle = string.Empty;
                        Aux.IDPedido = NuevoRegistro ? string.Empty : this._DatosPedido.IDPedido;
                        this._DatosPedido.DetallePedido.Add(Aux);
                        this.CargarGridPedidoDetalle();
                    }
                    else
                        MessageBox.Show("El producto a reemplazar ya se encuentra agregado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedido ~ btnReemplazar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPedidoDetalle.SelectedRows.Count == 1)
                {
                    int RowToDelete = this.dgvPedidoDetalle.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    this.RemoverItem(RowToDelete);
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedido ~ btnQuitar_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevoPedido ~ btnCancelar_Click");
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
                    Pedido Datos = this.ObtenerDatos();
                    Pedido_Negocio PedNeg = new Pedido_Negocio();
                    PedNeg.ACPedidos(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado > 0)
                        {
                            List<Error> LstError = new List<Error>();
                            LstError.Add(new Error { Numero = 1, Descripcion = Datos.MensajeError, ControlSender = this });
                            this.MostrarMensajeError(LstError);
                        }
                        else
                            MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedido ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmNuevoPedido_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedido ~ frmNuevoPedido_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
