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
    public partial class frmCatCiclos : Form
    {
        #region Variables

        private bool Busqueda = false;
        private string TextoBusq = string.Empty;

        #endregion

        #region Constructor

        public frmCatCiclos()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatCiclos ~ frmCatCiclos()");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridCatalogo()
        {
            try
            {
                CicloHorario Aux = new CicloHorario { Conexion = Comun.Conexion, IDSucursal = Comun.IDSucursalCaja };
                Ciclo_Negocio CN = new Ciclo_Negocio();
                CN.ObtenerCatCiclos(Aux);
                this.dgvCatCiclos.AutoGenerateColumns = false;
                this.dgvCatCiclos.DataSource = Aux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridCatalogoBusq(string TextoBusqueda)
        {
            try
            {
                CicloHorario Aux = new CicloHorario { Conexion = Comun.Conexion, IDSucursal = Comun.IDSucursalCaja, NombreCiclo = TextoBusqueda };
                Ciclo_Negocio CN = new Ciclo_Negocio();
                CN.ObtenerCatCiclosBusq(Aux);
                this.dgvCatCiclos.AutoGenerateColumns = false;
                this.dgvCatCiclos.DataSource = Aux.TablaDatos;
                this.TextoBusq = TextoBusqueda;
                this.Busqueda = true;
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
                this.CargarGridCatalogo();
                this.ActiveControl = this.txtTagBusqueda;
                this.txtTagBusqueda.Focus();
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

        private void ModificarDatos(int Row, CicloHorario Datos)
        {
            try
            {
                DataGridViewRow Fila = this.dgvCatCiclos.Rows[Row];
                Fila.Cells["IDCiclo"].Value = Datos.IDCiclo;
                Fila.Cells["NombreCiclo"].Value = Datos.NombreCiclo;
                Fila.Cells["CantidadCiclos"].Value = Datos.CantidadCiclos;
                Fila.Cells["IDUnidadCiclo"].Value = Datos.IDUnidadCiclo;
                Fila.Cells["Unidad"].Value = Datos.UnidadCicloDesc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CicloHorario ObtenerDatosGrid(int RowIndex)
        {
            try
            {
                CicloHorario DatosAux = new CicloHorario();
                DataGridViewRow Fila = this.dgvCatCiclos.Rows[RowIndex];
                DatosAux.IDCiclo = Fila.Cells["IDCiclo"].Value.ToString();
                DatosAux.NombreCiclo = Fila.Cells["NombreCiclo"].Value.ToString();
                int Cantidad = 0, IDUnidad = 0;
                int.TryParse(Fila.Cells["CantidadCiclos"].Value.ToString(), out Cantidad);
                int.TryParse(Fila.Cells["IDUnidadCiclo"].Value.ToString(), out IDUnidad);
                DatosAux.CantidadCiclos = Cantidad;
                DatosAux.IDUnidadCiclo = IDUnidad;
                DatosAux.UnidadCicloDesc = Fila.Cells["Unidad"].Value.ToString();
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
                if (!string.IsNullOrEmpty(this.txtTagBusqueda.Text.Trim()))
                {
                    this.CargarGridCatalogoBusq(this.txtTagBusqueda.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatCiclos ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCatCiclos.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int RowIndex = this.dgvCatCiclos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        CicloHorario Datos = this.ObtenerDatosGrid(RowIndex);
                        Datos.Conexion = Comun.Conexion;
                        Datos.IDUsuario = Comun.IDUsuario;
                        Ciclo_Negocio CN = new Ciclo_Negocio();
                        CN.EliminarCiclo(Datos);
                        if (Datos.Completado)
                        {
                            if (Busqueda)
                                CargarGridCatalogoBusq(TextoBusq);
                            else
                                CargarGridCatalogo();
                        }
                        else
                            MessageBox.Show("Ocurrió un error al eliminar el registro. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatCiclos ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCatCiclos.SelectedRows.Count == 1)
                {
                    int RowIndex = this.dgvCatCiclos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    CicloHorario Datos = this.ObtenerDatosGrid(RowIndex);
                    frmNuevoCiclo NCiclo = new frmNuevoCiclo(Datos);
                    NCiclo.ShowDialog();
                    NCiclo.Dispose();
                    if (NCiclo.DialogResult == DialogResult.OK)
                    {
                        this.ModificarDatos(RowIndex, NCiclo.DatosCiclo);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatCiclos ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoCiclo NCiclo = new frmNuevoCiclo();
                NCiclo.ShowDialog();
                NCiclo.Dispose();
                if (NCiclo.DialogResult == DialogResult.OK)
                {
                    if (Busqueda)
                        this.CargarGridCatalogoBusq(TextoBusq);
                    else
                        this.CargarGridCatalogo();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatCiclos ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmCatCiclos ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                if (Busqueda)
                {
                    this.CargarGridCatalogo();
                    this.Busqueda = false;
                    this.txtTagBusqueda.Text = string.Empty;
                    this.txtTagBusqueda.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatCiclos ~ btnComprasPendientes_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatCiclos_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatCiclos ~ frmCatCiclos_Load");
            }
        }

        private void txtTagBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatCiclos ~ txtTagBusqueda_KeyPress");
            }
        }

        #endregion
    }
}