using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using StephSoft.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephSoft
{
    public partial class frmCatalogoWeb : Form
    {
        #region Variables

        private bool Busqueda = false;
        private string TextoBusq = string.Empty;

        #endregion

        #region Constructor

        public frmCatalogoWeb()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ frmCatalogoWeb()");
            }
        }

        #endregion
        
        #region Métodos

        private void CargarGridCatalogo()
        {
            try
            {
                CatalogoWeb Aux = new CatalogoWeb { Conexion = Comun.Conexion, IDSucursal = Comun.IDSucursalCaja };
                CatalogoWeb_Negocio CWN = new CatalogoWeb_Negocio();
                List<CatalogoWeb> Lista = CWN.ObtenerCatalogoWeb(Aux);
                foreach (CatalogoWeb Item in Lista)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Item.BufferImagen);
                    Item.ImagenMin = Image.FromStream(ms);
                    Item.ImagenDGV = ComprimirImagen.ResizeImage(Item.ImagenMin, 40, 40);
                }
                this.dgvCatalogoWeb.DataSource = null;
                this.dgvCatalogoWeb.AutoGenerateColumns = false;
                this.dgvCatalogoWeb.DataSource = Lista;
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
                CatalogoWeb Aux = new CatalogoWeb { Conexion = Comun.Conexion, IDSucursal = Comun.IDSucursalCaja, Tag = TextoBusqueda };
                CatalogoWeb_Negocio CWN = new CatalogoWeb_Negocio();
                List<CatalogoWeb> Lista = CWN.ObtenerCatalogoWebBusq(Aux);
                foreach (CatalogoWeb Item in Lista)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Item.BufferImagen);
                    Item.ImagenMin = Image.FromStream(ms);
                    Item.ImagenDGV = ComprimirImagen.ResizeImage(Item.ImagenMin, 40, 40);
                }
                this.dgvCatalogoWeb.DataSource = null;
                this.dgvCatalogoWeb.AutoGenerateColumns = false;
                this.dgvCatalogoWeb.DataSource = Lista;
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

        private CatalogoWeb ObtenerDatosGrid(int RowIndex)
        {
            try
            {
                CatalogoWeb DatosAux = new CatalogoWeb();
                List<CatalogoWeb> Lista = (List<CatalogoWeb>)this.dgvCatalogoWeb.DataSource;
                DatosAux = Lista[RowIndex];
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
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCatalogoWeb.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int RowIndex = this.dgvCatalogoWeb.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        CatalogoWeb Datos = this.ObtenerDatosGrid(RowIndex);
                        Datos.Conexion = Comun.Conexion;
                        Datos.IDUsuario = Comun.IDUsuario;
                        CatalogoWeb_Negocio CWN = new CatalogoWeb_Negocio();
                        CWN.EliminarCatalogoWeb(Datos);
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
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCatalogoWeb.SelectedRows.Count == 1)
                {
                    int RowIndex = this.dgvCatalogoWeb.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    CatalogoWeb Datos = this.ObtenerDatosGrid(RowIndex);
                    frmNuevaImagenCatWeb NImagenWeb = new frmNuevaImagenCatWeb(Datos);
                    NImagenWeb.ShowDialog();
                    NImagenWeb.Dispose();
                    if (NImagenWeb.DialogResult == DialogResult.OK)
                    {
                        if (Busqueda)
                            CargarGridCatalogoBusq(TextoBusq);
                        else
                            CargarGridCatalogo();
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevaImagenCatWeb NImagenWeb = new frmNuevaImagenCatWeb();
                NImagenWeb.ShowDialog();
                NImagenWeb.Dispose();
                if (NImagenWeb.DialogResult == DialogResult.OK)
                {
                    if (Busqueda)
                        CargarGridCatalogoBusq(TextoBusq);
                    else
                        CargarGridCatalogo();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnSalir_Click");
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
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnCancelarBusq_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatalogoWeb_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ frmCatalogoWeb_Load");
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
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ txtTagBusqueda_KeyPress");
            }
        }

        #endregion

    }
}