using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using CreativaSL.Dll.Validaciones;
using StephSoft.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephSoft
{
    public partial class frmCatEmpleado : Form
    {

        #region Constructores

        public frmCatEmpleado()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ frmCatEmpleado()");
            }
        }

        #endregion

        #region Métodos

        private DataTable GenerarTablaSucursales()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDSucursal", typeof(string));
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BusquedaUsuario(string TextoEmpleado)
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, Nombre = TextoEmpleado, BuscarTodos = false, IDSucursalActual = Comun.IDSucursalCaja };
                Usuario_Negocio CN = new Usuario_Negocio();
                CN.ObtenerCatUsuarioXIDSucBusq(DatosAux);
                this.dgvUsuario.AutoGenerateColumns = false;
                this.dgvUsuario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarUsuario(Usuario Datos)
        {
            try
            {
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.TablaUsuarioSucursal = this.GenerarTablaSucursales();
                Datos.Opcion = 3;
                Usuario_Negocio CN = new Usuario_Negocio();
                CN.ABCUsuario(Datos);
                if (Datos.Completado)
                {
                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Int32 RowToDelete = this.dgvUsuario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                        this.dgvUsuario.Rows.RemoveAt(RowToDelete);
                    else
                        this.LlenarGridUsuario(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError.AddExcFileTxt(new Exception(Datos.MensajeError), "frmCatClientes ~ EliminarCliente -> Método");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarDatos(Usuario Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvUsuario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvUsuario.Rows[RowToUpdate].Cells["Nombre"].Value = Datos.Nombre;
                    this.dgvUsuario.Rows[RowToUpdate].Cells["ApellidoPat"].Value = Datos.ApellidoPat;
                    this.dgvUsuario.Rows[RowToUpdate].Cells["ApellidoMat"].Value = Datos.ApellidoMat;
                    this.dgvUsuario.Rows[RowToUpdate].Cells["DirCalle"].Value = Datos.DirCalle;
                    this.dgvUsuario.Rows[RowToUpdate].Cells["DirColonia"].Value = Datos.DirColonia;
                    this.dgvUsuario.Rows[RowToUpdate].Cells["DirNumero"].Value = Datos.DirNumero;
                }
                else
                    this.LlenarGridUsuario(false);
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
                this.LlenarGridUsuario(false);
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

        private void LlenarGridUsuario(bool Band)
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, BuscarTodos = Band, IDSucursalActual = Comun.IDSucursalCaja };
                Usuario_Negocio CN = new Usuario_Negocio();
                CN.ObtenerCatUsuarioXIDSuc(DatosAux);
                this.dgvUsuario.AutoGenerateColumns = false;
                this.dgvUsuario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario ObtenerDatosUsuario()
        {
            try
            {
                Usuario DatosAux = new Usuario();
                Int32 RowData = this.dgvUsuario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    int ID = 0;
                    DataGridViewRow FilaDatos = this.dgvUsuario.Rows[RowData];
                    DatosAux.IDEmpleado = FilaDatos.Cells["IDEmpleado"].Value.ToString();
                    int.TryParse(FilaDatos.Cells["IDTipoUsuario"].Value.ToString(), out ID);
                    DatosAux.IDTipoUsuario = ID;
                    int.TryParse(FilaDatos.Cells["IDPuesto"].Value.ToString(), out ID);
                    DatosAux.IDPuesto = ID;
                    DatosAux.IDCategoriaPuesto = FilaDatos.Cells["IDCategoria"].Value.ToString();
                    DatosAux.IDSucursalActual = FilaDatos.Cells["IDSucursal"].Value.ToString();
                    DatosAux.AbrirCaja = Convert.ToBoolean(FilaDatos.Cells["AbrirCaja"].Value.ToString());
                    DatosAux.Nombre = FilaDatos.Cells["Nombre"].Value.ToString();
                    DatosAux.ApellidoPat = FilaDatos.Cells["ApellidoPat"].Value.ToString();
                    DatosAux.ApellidoMat = FilaDatos.Cells["ApellidoMat"].Value.ToString();
                    DatosAux.DirCalle = FilaDatos.Cells["DirCalle"].Value.ToString();
                    DatosAux.DirColonia = FilaDatos.Cells["DirColonia"].Value.ToString();
                    DatosAux.DirNumero = FilaDatos.Cells["DirNumero"].Value.ToString();
                    DatosAux.CuentaUsuario = FilaDatos.Cells["CuentaUsuario"].Value.ToString();
                    DatosAux.Password = FilaDatos.Cells["Contraseña"].Value.ToString();
                    DatosAux.AltaNominal = Convert.ToBoolean(FilaDatos.Cells["AltaNominal"].Value.ToString());
                }
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
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    if (Validar.IsValidName(txtBusqueda.Text.Trim()))
                        this.BusquedaUsuario(this.txtBusqueda.Text.Trim());
                    else
                        this.txtBusqueda.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCuentaUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        frmCuentaEmpleado Empleado = new frmCuentaEmpleado(DatosAux);
                        Empleado.ShowDialog();
                        Empleado.Dispose();
                        //this.LlenarGridUsuario(false);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnCuentaUser_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        frmHorarioEmpleado Horario = new frmHorarioEmpleado(DatosAux.IDEmpleado);
                        Horario.ShowDialog();
                        Horario.Dispose();
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnHorario_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuellaDigital_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        frmCatEmpleadoHuella Huella = new frmCatEmpleadoHuella(DatosAux);
                        Huella.ShowDialog();
                        Huella.Dispose();
                        if (Huella.DialogResult == DialogResult.OK)
                        {
                            this.LlenarGridUsuario(false);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnHuellaDigital_Click");
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
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridUsuario(true);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnTodos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ frmCatEmpleado_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnAsignarHorario_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        frmAsignarHorario Horario = new frmAsignarHorario(DatosAux);
                        Horario.ShowDialog();
                        Horario.Dispose();
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnAsignarHorario_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
