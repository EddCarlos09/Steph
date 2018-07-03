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
    public partial class frmElegirProductoBusq : Form
    {
        #region Propiedades / Variables        
        private Producto _Seleccionado;
        public Producto Seleccionado
        {
            get { return _Seleccionado; }
            set { _Seleccionado = value; }
        }
        private List<Producto> _DatosActuales;
        public List<Producto> DatosActuales
        {
            get { return _DatosActuales; }
            set { _DatosActuales = value; }
        }
        
        #endregion

        #region Constructor

        public frmElegirProductoBusq()
        {
            try
            {
                InitializeComponent();
                this.DatosActuales = new List<Producto>();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirProducto ~ frmElegirProducto()");
            }
        }

        #endregion

        #region Métodos

        private void Busqueda(string TextoBusqueda)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextoBusqueda.Trim()))
                {
                    Producto Datos = new Producto { Conexion = Comun.Conexion, BuscarTodos = false, NombreProducto = this.txtBusqueda.Text };
                    Producto_Negocio ProdNeg = new Producto_Negocio();
                    this._DatosActuales = ProdNeg.ObtenerProductosBusqueda(Datos);
                    this.LlenarGridProducto();
                    if (this.dgvProducto.Rows.Count > 0)
                    {
                        this.ActiveControl = this.dgvProducto;
                        this.dgvProducto.Focus();
                    }
                }
                else
                {
                    this.dgvProducto.DataSource = new List<Producto>();
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
                this.LlenarGridProducto();
                this.txtBusqueda.Text = string.Empty;
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

        private void LlenarGridProducto()
        {
            try
            {
                BindingSource Datos = new BindingSource();
                Datos.DataSource = this.DatosActuales;
                this.dgvProducto.AutoGenerateColumns = false;
                this.dgvProducto.DataSource = Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Producto ObtenerDatos(int Index)
        {
            try
            {
                DataGridViewRow Fila = this.dgvProducto.Rows[Index];
                Producto Datos = new Producto();
                Datos.IDProducto = Fila.Cells["IDProducto"].Value.ToString();
                Datos.NombreProducto = Fila.Cells["NombreProducto"].Value.ToString();
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
                this.Busqueda(this.txtBusqueda.Text);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                this._DatosActuales = new List<Producto>();
                this.LlenarGridProducto();
                this.txtBusqueda.Text = string.Empty;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ btnCancelarBusqueda_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTarjetas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this._Seleccionado = this.ObtenerDatos(e.RowIndex);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ dgv_Tarjetas_CellDoubleClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTarjetas_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.dgvProducto.SelectedRows.Count == 1)
                    {
                        Int32 RowSelected = this.dgvProducto.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        this._Seleccionado = this.ObtenerDatos(RowSelected);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ txtBusqueda_KeyUp");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmElegirProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ frmElegirTarjetaMonedero_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Busqueda(this.txtBusqueda.Text);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ txtBusqueda_KeyUp");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
