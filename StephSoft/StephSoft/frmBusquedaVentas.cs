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
    public partial class frmBusquedaVentas : Form
    {
        #region Constructores

        public frmBusquedaVentas()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmBusquedaVentas ~ frmBusquedaVentas()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarDatos()
        {
            try
            {
                this.txtCliente.Text = string.Empty;
                this.txtFolioBusq.Text = string.Empty;
                this.rbTicket.Checked = true;
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
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.IniciarDatos();
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
                Venta Datos = new Venta { Band = this.rbTicket.Checked, FolioVenta = this.ObtenerTextoBusqueda(), Conexion = Comun.Conexion };
                Venta_Negocio VN = new Venta_Negocio();
                VN.BusquedaVentasTicket(Datos);
                this.dgvVentas.AutoGenerateColumns = false;
                this.dgvVentas.DataSource = Datos.TablaDatos;
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
                DatosAux.NombreCliente = Fila.Cells["Cliente"].Value.ToString();
                DateTime FechaAux = DateTime.Today;
                DateTime.TryParse(Fila.Cells["FechaVenta"].Value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out FechaAux);
                DatosAux.FechaVenta = FechaAux;
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

        private string ObtenerTextoBusqueda()
        {
            try
            {
                string TextoBusqueda = string.Empty;

                if (this.rbTicket.Checked)
                    TextoBusqueda = this.txtFolioBusq.Text.Trim();
                else
                    TextoBusqueda = this.txtCliente.Text.Trim();
                return TextoBusqueda;
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
                if (this.rbTicket.Checked || this.rbCliente.Checked)
                {
                    if (!string.IsNullOrEmpty(this.ObtenerTextoBusqueda()))
                    {
                        this.CargarGridVentas();
                    }
                    else
                        MessageBox.Show("Seleccione un tipo de Búsqueda.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Seleccione un tipo de Búsqueda.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmBusquedaVentas ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvVentas.SelectedRows.Count == 1)
                {
                    int Row = this.dgvVentas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Venta DatosAux = this.ObtenerDatosGrid(Row);
                    try
                    {
                        Ticket Impresion = new Ticket(1, 1, DatosAux.IDVenta);
                        Impresion.ImprimirTicket();
                    }
                    catch (Exception exImpr)
                    {
                        LogError.AddExcFileTxt(exImpr, "frmBusquedaVentas ~ btnTicket_Click");
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmBusquedaVentas ~ btnTicket_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmBusquedaVentas ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBusquedaVentas_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmBusquedaVentas ~ frmBusquedaVentas_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbTicket_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbTicket.Checked)
                    this.txtFolioBusq.Focus();
                else
                    this.txtCliente.Focus();
                this.txtCliente.Text = string.Empty;
                this.txtFolioBusq.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmBusquedaVentas ~ rbTicket_CheckedChanged");
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmBusquedaVentas ~ txtBusqueda_KeyPress");
            }
        }

        private void txtFolioBusq_Enter(object sender, EventArgs e)
        {
            try
            {
                this.rbTicket.Checked = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmBusquedaVentas ~ txtFolioBusq_Enter");
            }
        }

        private void txtCliente_Enter(object sender, EventArgs e)
        {
            try
            {
                this.rbCliente.Checked = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmBusquedaVentas ~ txtCliente_Enter");
            }
        }

        #endregion

    }
}
