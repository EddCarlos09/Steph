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
    public partial class frmClavesXIDEmpleado : Form
    {
        #region Propiedades / Variables        
        Usuario Datos = new Usuario();
        bool EsEmpl = false;
        #endregion

        #region Constructor(es)

        public frmClavesXIDEmpleado()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmClavesXIDEmpleado ~ frmClavesXIDEmpleado()");
            }
        }

        public frmClavesXIDEmpleado(Usuario _Datos)
        {
            try
            {
                InitializeComponent();
                Datos = _Datos;
                EsEmpl = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmClavesXIDEmpleado ~ frmClavesXIDEmpleado(Usuario _Datos)");
            }
        }

        #endregion

        #region Métodos        

        private void IniciarDatos()
        {
            try
            {
                if (EsEmpl)
                {
                    if (!string.IsNullOrEmpty(Datos.IDEmpleado.Trim()))
                    {
                        this.txtCodigoEmpleado.Text = Datos.CodigoUsuario;
                        this.txtNombreEmpleado.Text = string.Format("{0} {1} {2}", Datos.Nombre, Datos.ApellidoPat, Datos.ApellidoMat);
                    }
                }
                else
                {
                    label1.Visible = false;
                    txtCodigoEmpleado.Visible = false;
                    label5.Visible = false;
                    txtNombreEmpleado.Visible = false;
                    label42.Text = "Claves por sucursal";
                }
                LlenarGrid(string.Empty);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGrid(string BusqProducto)
        {
            try
            {
                this.dgvClaves.AutoGenerateColumns = false;
                this.dgvClaves.DataSource = ObtenerClaves(EsEmpl ? Datos.IDEmpleado.Trim() : Comun.IDSucursalCaja, EsEmpl, BusqProducto);
                this.DibujarColoresGrid();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.IniciarDatos();
                this.ActiveControl = this.btnCancelar;
                this.btnCancelar.Focus();
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

        private DataTable ObtenerClaves(string IDGen, bool EsEmpleado, string BusqProd)
        {
            try
            {
                Producto_Negocio ProdNeg = new Producto_Negocio();
                return ProdNeg.ObteneClavesXIDEmpleadoIDSucursal(Comun.Conexion, EsEmpleado, IDGen, BusqProd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DibujarColoresGrid()
        {
            try
            {
                foreach (DataGridViewRow Fila in this.dgvClaves.Rows)
                {
                    bool CumpleMetrica = false;
                    bool.TryParse(Fila.Cells["CumpleMetrica"].Value.ToString(), out CumpleMetrica);
                    if (CumpleMetrica)
                    {
                        //Fila.DefaultCellStyle.BackColor = Color.Green;
                        Fila.DefaultCellStyle.BackColor = Color.Green;
                    }
                    else
                    {
                        //Fila.DefaultCellStyle.BackColor = Color.Red;
                        //Fila.Cells["CantidadMetrica"].Style.BackColor = Color.Red;
                        Fila.DefaultCellStyle.BackColor = Color.Red;
                    }
                    Fila.Selected = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private Producto ObtenerDatosGrid(int Row)
        {
            try
            {
                Producto _DatosGrid = new Producto();
                if (Row >= 0)
                {
                    DataGridViewRow FilaDatos = this.dgvClaves.Rows[Row];
                    _DatosGrid.IDAsignacion = FilaDatos.Cells["IDAsignacion"].Value.ToString();
                    _DatosGrid.ClaveProduccion = FilaDatos.Cells["ClaveProduccion"].Value.ToString();
                    _DatosGrid.NombreProducto = FilaDatos.Cells["Producto"].Value.ToString();
                }
                return _DatosGrid;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos
        
        private void dgvClaves_Sorted(object sender, EventArgs e)
        {
            try
            {
                this.DibujarColoresGrid();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmClavesXIDEmpleado ~ dgvClaves_Sorted");
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
                LogError.AddExcFileTxt(ex, "frmClavesXIDEmpleado ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmClavesXIDEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmClavesXIDEmpleado ~ frmClavesXIDEmpleado_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtProducto.Text.Trim()))
                {
                    this.LlenarGrid(txtProducto.Text);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmClavesXIDEmpleado ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnInicializar_Click(object sender, EventArgs e)
        {
            try
            {
                frmInicializarClaves Inicializar;
                if (EsEmpl)
                    Inicializar = new frmInicializarClaves(Datos);
                else
                    Inicializar = new frmInicializarClaves();
                Inicializar.ShowDialog();
                Inicializar.Dispose();
                if (Inicializar.DialogResult == DialogResult.OK)
                {
                    this.LlenarGrid(this.txtProducto.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmClavesXIDEmpleado ~ btnCrearClave_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearClave_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevaClaveProduccion Entregar;
                if (EsEmpl)
                    Entregar = new frmNuevaClaveProduccion(Datos);
                else
                    Entregar = new frmNuevaClaveProduccion();
                Entregar.ShowDialog();
                Entregar.Dispose();
                if(Entregar.DialogResult == DialogResult.OK)
                {
                    this.LlenarGrid(this.txtProducto.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmClavesXIDEmpleado ~ btnCrearClave_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClaves.SelectedRows.Count == 1)
                {
                    int Row = dgvClaves.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Producto Datos = this.ObtenerDatosGrid(Row);
                    if (!string.IsNullOrEmpty(Datos.IDAsignacion))
                    {
                        if (MessageBox.Show(string.Format("¿Está seguro(a) de dar de baja el producto {0} con clave {1}? Este proceso no es reversible.", Datos.NombreProducto, Datos.ClaveProduccion), Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Producto_Negocio ProdNeg = new Producto_Negocio();
                            int Result = ProdNeg.BajaClaveProduccion(Comun.Conexion, EsEmpl, Datos.IDAsignacion, Comun.IDSucursalCaja, Comun.IDUsuario);
                            if(Result == 1)
                            {
                                MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LlenarGrid(this.txtProducto.Text.Trim());
                            }
                            else
                            {
                                string Message = string.Empty;
                                switch(Result)
                                {
                                    case -1: Message = "La clave ya no está en producción.";
                                        break;
                                    case -2: Message = "No hay existencias suficientes para reemplazar la clave.";
                                        break;
                                    default: Message = "Error al guardar los datos. Intente nuevamente. ";
                                        break;
                                }
                                MessageBox.Show(Message, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmClavesXIDEmpleado ~ btnBaja_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReemplazar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClaves.SelectedRows.Count == 1)
                {
                    int Row = dgvClaves.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Producto Datos = this.ObtenerDatosGrid(Row);
                    if (!string.IsNullOrEmpty(Datos.IDAsignacion))
                    {
                        if (MessageBox.Show(string.Format("¿Está seguro(a) de reemplazar el producto {0} con clave {1}? Este proceso no es reversible.", Datos.NombreProducto, Datos.ClaveProduccion), Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Producto_Negocio ProdNeg = new Producto_Negocio();
                            int Result = ProdNeg.ReemplazarClaveProduccion(Comun.Conexion, EsEmpl, Datos.IDAsignacion, Comun.IDSucursalCaja, Comun.IDUsuario);
                            if (Result == 1)
                            {
                                MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LlenarGrid(this.txtProducto.Text.Trim());
                            }
                            else
                            {
                                string Message = string.Empty;
                                switch (Result)
                                {
                                    case -1:
                                        Message = "La clave ya no está en producción.";
                                        break;
                                    case -2:
                                        Message = "No hay existencias suficientes para reemplazar la clave.";
                                        break;
                                    default:
                                        Message = "Error al guardar los datos. Intente nuevamente. ";
                                        break;
                                }
                                MessageBox.Show(Message, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmClavesXIDEmpleado ~ btnReemplazar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
