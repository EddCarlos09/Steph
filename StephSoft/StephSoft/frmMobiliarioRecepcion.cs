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
    public partial class frmMobiliarioRecepcion : Form
    {
        #region Variables
        private string TextoBusqueda = string.Empty;
        private bool   BandBusqueda = false;
        #endregion

        #region Constructor

        public frmMobiliarioRecepcion()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecepcion ~ frmMobiliarioRecepcion()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaMobiliario()
        {
            try
            {
                this.TextoBusqueda = this.txtBusqueda.Text.Trim();
                MobiliarioResguardo Datos = new MobiliarioResguardo { Conexion = Comun.Conexion, BuscarTodos = this.chkTodosLosRegistros.Checked, FolioResguardo = TextoBusqueda, IDSucursal = Comun.IDSucursalCaja };
                MobiliarioResguardo_Negocio MobNeg = new MobiliarioResguardo_Negocio();
                MobNeg.ObtenerCatMobiliarioResguardoBusqueda(Datos);
                this.dgvMobiliarioRecepcion.AutoGenerateColumns = false;
                this.dgvMobiliarioRecepcion.DataSource = Datos.TablaDatos;
                BandBusqueda = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridCatMobiliario(bool Band)
        {
            try
            {
                MobiliarioResguardo DatosAux = new MobiliarioResguardo { Conexion = Comun.Conexion, BuscarTodos = Band, IDSucursal = Comun.IDSucursalCaja };
                MobiliarioResguardo_Negocio MN = new MobiliarioResguardo_Negocio();
                MN.ObtenerCatMobiliarioResguardo(DatosAux);
                this.dgvMobiliarioRecepcion.AutoGenerateColumns = false;
                this.dgvMobiliarioRecepcion.DataSource = DatosAux.TablaDatos;
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
                this.LlenarGridCatMobiliario(false);
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

        private MobiliarioResguardo ObtenerDatosGrid(int Row)
        {
            try
            {
                MobiliarioResguardo Datos = new MobiliarioResguardo();
                DataGridViewRow Fila = this.dgvMobiliarioRecepcion.Rows[Row];
                Datos.IDMobiliarioResguardo = Fila.Cells["IDMobiliarioResguardo"].Value.ToString();
                Datos.IDSucursal = Fila.Cells["IDSucursal"].Value.ToString();
                Datos.FolioResguardo = Fila.Cells["FolioReguardo"].Value.ToString();
                DateTime Fecha;
                DateTime.TryParse(Fila.Cells["FechaResguardo"].Value.ToString(), out Fecha);
                Datos.FechaResguardo = Fecha;
                int IDEstatus = 0;
                int.TryParse(Fila.Cells["Estatus"].Value.ToString(), out IDEstatus);
                Datos.IDStatusMobiliario = IDEstatus;
                Datos.NombreEstatus = Fila.Cells["NombreEstatus"].Value.ToString();
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
                    this.BusquedaMobiliario();
                else
                    this.LlenarGridCatMobiliario(false);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecepcion ~ btnActualizar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    this.BusquedaMobiliario();
                }
                else
                {
                    MessageBox.Show("Ingrese un texto en el campo de búsqueda.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecepcion ~ btnBuscar_Click");
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
                    this.LlenarGridCatMobiliario(false);
                    BandBusqueda = false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecepcion ~ btnCancelarBusq_Click");
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
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecepcion ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMobiliarioRecepcion.SelectedRows.Count == 1)
                {
                    int Row = this.dgvMobiliarioRecepcion.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    MobiliarioResguardo DatosAux = this.ObtenerDatosGrid(Row);
                    //frmPedidoDetalle Detalle = new frmPedidoDetalle(DatosAux);
                    //this.Visible = false;
                    //Detalle.ShowDialog();
                    //Detalle.Dispose();
                    //this.Visible = true;
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecepcion ~ btnDetallePedido_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMobiliarioRecepcion.SelectedRows.Count == 1)
                {
                    int Row = this.dgvMobiliarioRecepcion.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    MobiliarioResguardo DatosAux = this.ObtenerDatosGrid(Row);                    
                    frmMobiliarioRecibir Detalle = new frmMobiliarioRecibir(DatosAux);
                    this.Visible = false;
                    Detalle.ShowDialog();
                    Detalle.Dispose();
                    this.Visible = true;
                    if (Detalle.DialogResult == DialogResult.OK)
                    {
                        this.LlenarGridCatMobiliario(this.chkTodosLosRegistros.Checked);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecepcion ~ btnRecibir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMobiliarioRecepcion_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioRecepcion ~ frmMobiliarioRecepcion_Load");
            }
        }

        #endregion
    }
}
