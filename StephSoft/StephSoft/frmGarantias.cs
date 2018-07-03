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
    public partial class frmGarantias : Form
    {
        #region Constructores

        public frmGarantias()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGarantias ~ frmGarantias()");
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

        private void CargarGridGarantias()
        {
            try
            {
                Garantia Datos = new Garantia { Band = this.rbTicket.Checked, TextoBusqueda = this.ObtenerTextoBusqueda(), Conexion = Comun.Conexion };
                Garantia_Negocio GN = new Garantia_Negocio();
                GN.BusquedaGarantias(Datos);
                this.dgvVentas.AutoGenerateColumns = false;
                this.dgvVentas.DataSource = Datos.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Garantia ObtenerDatosGrid(int Row)
        {
            try
            {
                Garantia DatosAux = new Garantia();
                DataGridViewRow Fila = this.dgvVentas.Rows[Row];
                DatosAux.IDGarantia = Fila.Cells["IDGarantia"].Value.ToString();
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
                        this.CargarGridGarantias();
                    }
                    else
                        MessageBox.Show("Ingrese un texto para búsqueda.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Seleccione un tipo de Búsqueda.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGarantias ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAplicarGarantia_Click(object sender, EventArgs e)
        {
            try
            {
                frmGarantiasBusqVentas Garantia = new frmGarantiasBusqVentas();
                this.Visible = false;
                Garantia.ShowDialog();
                Garantia.Dispose();
                this.Visible = true;
                if (Garantia.DialogResult == DialogResult.OK)
                {
                    this.CargarGridGarantias();
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmGarantias ~ txtBusqueda_KeyPress");
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
                LogError.AddExcFileTxt(ex, "frmGarantias ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmGarantias_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGarantias ~ frmGarantias_Load");
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
                LogError.AddExcFileTxt(ex, "frmGarantias ~ rbTicket_CheckedChanged");
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
                LogError.AddExcFileTxt(ex, "frmGarantias ~ txtBusqueda_KeyPress");
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
                LogError.AddExcFileTxt(ex, "frmGarantias ~ txtFolioBusq_Enter");
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
                LogError.AddExcFileTxt(ex, "frmGarantias ~ txtCliente_Enter");
            }
        }

        #endregion

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvVentas.SelectedRows.Count == 1)
                {
                    int Row = this.dgvVentas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Garantia DatosAux = this.ObtenerDatosGrid(Row);
                    try
                    {
                        Ticket Impresion = new Ticket(4, 1, DatosAux.IDGarantia);
                        Impresion.ImprimirTicket();
                    }
                    catch (Exception exImpr)
                    {
                        LogError.AddExcFileTxt(exImpr, "frmGarantias ~ btnReimprimir_Click");
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmGarantias ~ txtBusqueda_KeyPress");
            }
        }

    }
}
