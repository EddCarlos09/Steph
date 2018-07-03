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
    public partial class frmCancelarTicket : Form
    {
        #region Constructores

        public frmCancelarTicket()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelarTicket ~ frmCancelarTicket()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
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

        private void CargarGridVentas()
        {
            try
            {
                Venta Datos = new Venta { IDSucursal = Comun.IDSucursalCaja, FolioVenta = this.txtBusqueda.Text.Trim(), Conexion = Comun.Conexion };
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {   
                    Venta_Negocio VN = new Venta_Negocio();
                    VN.ObtenerVentasXFolio(Datos);
                }
                if (Datos.Completado)
                {
                    this.dgvVentas.AutoGenerateColumns = false;
                    this.dgvVentas.DataSource = Datos.TablaDatos;
                }
                else
                {
                    this.dgvVentas.DataSource = null;
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
                DataGridViewRow Fila = this.dgvVentas.Rows[Row];
                DatosAux.IDVenta = Fila.Cells["IDVenta"].Value.ToString();
                DatosAux.FolioVenta = Fila.Cells["FolioVenta"].Value.ToString();
                decimal Total = 0;
                decimal.TryParse(Fila.Cells["Total"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Total);
                DatosAux.Total = Total;
                return DatosAux;
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
                this.CargarGridVentas();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvVentas.SelectedRows.Count == 1)
                {
                    int Row = this.dgvVentas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Venta DatosAux = this.ObtenerDatosGrid(Row);
                    frmCancelar Canc = new frmCancelar(DatosAux);
                    Canc.ShowDialog();
                    Canc.Dispose();
                    if (Canc.DialogResult == DialogResult.OK)
                    {
                        this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelarTicket ~ txtBusqueda_KeyPress");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelarTicket ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCancelarTicket_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelarTicket ~ frmCancelarTicket_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar == (char)Keys.Enter)
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelarTicket ~ txtBusqueda_KeyPress");
            }
        }

        #endregion

    }
}
