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
    public partial class frmNuevoServicioTicket : Form
    {
        private string IDVenta = string.Empty;
        private Producto DatosServicio = new Producto();
        public frmNuevoServicioTicket(string ID)
        {
            try
            {
                InitializeComponent();
                IDVenta = ID;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicioTicket ~ frmNuevoServicioTicket(string ID)");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicioTicket ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirServicio_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario AuxEmp = this.ObtenerDatosEmpleado();
                frmSeleccionarProducto ElegirServicio = new frmSeleccionarProducto(13);
                ElegirServicio.Location = this.txtCliente.PointToScreen(new Point());
                ElegirServicio.Location = new Point(ElegirServicio.Location.X - 1, ElegirServicio.Location.Y - 2);
                ElegirServicio.ShowDialog();
                ElegirServicio.Dispose();
                if (ElegirServicio.DialogResult == DialogResult.OK)
                {
                    Producto Aux = ElegirServicio.Datos;
                    this.DatosServicio = Aux;
                    this.txtCliente.Text = Aux.NombreProducto;
                    this.LlenarGridProductos(AuxEmp.IDEmpleado, this.DatosServicio.IDProducto);
                }
                else
                {
                    this.DatosServicio = new Producto();
                    this.txtCliente.Text = string.Empty;
                    this.LlenarGridProductos(AuxEmp.IDEmpleado, this.DatosServicio.IDProducto);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicioTicket ~ btnElegirServicio_Click");
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
                    VentaDetalle Datos = this.ObtenerDatos();
                    Venta_Negocio VN = new Venta_Negocio();
                    VN.AgregarServicioAVenta(Datos);
                    if (Datos.Completado)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado == -1)
                        {
                            MessageBox.Show("La venta tiene un vale aplicado. Debe removerlo para agregar servicios. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Datos.Resultado == -2)
                        {
                            MessageBox.Show("El servicio ya se encuentra en la venta. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Datos.Resultado == -3)
                        {
                            MessageBox.Show("El servicio requiere productos extras con los que no cuenta la sucursal. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("Ocurrió un error. Intente nuevamente. Si el problema persiste, contacte a Soporte Técnico. Código del Error: " + Datos.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicioTicket ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoServicioTicket_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicioTicket ~ frmNuevoServicioTicket_Load");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboEmpleados();
                this.ActiveControl = this.btnElegirCliente;
                this.btnElegirCliente.Focus();
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

        private VentaDetalle ObtenerDatos()
        {
            try
            {
                VentaDetalle Datos = new VentaDetalle();
                Datos.IDVenta = this.IDVenta;
                Datos.IDServicio = this.DatosServicio.IDProducto;
                Datos.IDEmpleado = this.ObtenerDatosEmpleado().IDEmpleado;
                Datos.TablaDatos = this.GenerarTabla();
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.Conexion = Comun.Conexion;
                return Datos;
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
                if (string.IsNullOrEmpty(this.DatosServicio.IDProducto))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un servicio.", ControlSender = this.btnElegirCliente });
                Usuario EmpAux = this.ObtenerDatosEmpleado();
                if (string.IsNullOrEmpty(EmpAux.IDEmpleado))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un empleado de la lista.", ControlSender = this.btnElegirCliente });

                foreach (DataGridViewRow Fila in this.dgvProductosXServicio.Rows)
                {
                    DataGridViewComboBoxCell Celda = (DataGridViewComboBoxCell)Fila.Cells["ClaveProduccion"];
                    if (Celda.Items.Count > 0)
                    {
                        string IDAsignacion = Celda.Value.ToString();
                        if (string.IsNullOrEmpty(IDAsignacion))
                        {
                            Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una clave de producción en " + Fila.Cells["NombreProducto"].Value.ToString() + "." , ControlSender = this.btnElegirCliente });
                        }
                    }
                }
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboEmpleados()
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, IDSucursalActual = Comun.IDSucursalCaja, IncluirSelect = true };
                Usuario_Negocio UN = new Usuario_Negocio();
                this.cmbEmpleados.DataSource = UN.LlenarComboCatEmpleados(DatosAux);
                this.cmbEmpleados.ValueMember = "IDEmpleado";
                this.cmbEmpleados.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTabla()
        {
            try
            {
                DataTable TablaAux = new DataTable();
                TablaAux.Columns.Add("IDProducto", typeof(string));
                TablaAux.Columns.Add("IDAsignacion", typeof(string));
                TablaAux.Columns.Add("EsEmpleado", typeof(bool));
                foreach (DataGridViewRow Fila in this.dgvProductosXServicio.Rows)
                {
                    DataGridViewComboBoxCell Combo = (DataGridViewComboBoxCell)Fila.Cells["ClaveProduccion"];
                    if (Combo.Items.Count > 0)
                    {
                        string IDAsignacion = Combo.Value != null ? Combo.Value.ToString() : string.Empty;
                        string IDProducto = Fila.Cells["IDProducto"].Value.ToString();
                        bool EsEmpl = false;
                        foreach (PedidoDetalle AuxItem in Combo.Items)
                        {
                            if (AuxItem.IDAsignacion == IDAsignacion)
                            {
                                EsEmpl = AuxItem.EsEmpleado;
                                break;
                            }
                        }
                        object[] NuevaFila = { IDProducto, IDAsignacion, EsEmpl };
                        TablaAux.Rows.Add(NuevaFila);
                    }
                }
                return TablaAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario ObtenerDatosEmpleado()
        {
            try
            {
                Usuario Aux = new Usuario();
                if (this.cmbEmpleados.SelectedIndex != -1)
                {
                    Aux = (Usuario)this.cmbEmpleados.SelectedItem;
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Producto ObtenerProductoXID(string ID, List<Producto> Lista)
        {
            try
            {
                Producto Aux = new Producto();
                foreach (Producto Item in Lista)
                {
                    if (Item.IDProducto == ID)
                    {
                        Aux = Item;
                        break;
                    }
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridProductos(string IDEmpleado, string IDServicio)
        {
            try
            {
                if (!string.IsNullOrEmpty(IDEmpleado) && !string.IsNullOrEmpty(IDServicio))
                {
                    Servicio DatosAux = new Servicio { Conexion = Comun.Conexion, IDServicio = IDServicio, IDEmpleado = IDEmpleado, IDSucursal = Comun.IDSucursalCaja };
                    Servicio_Negocio SN = new Servicio_Negocio();
                    List<Producto> Lista = SN.ObtenerProductosXIDServicio(DatosAux);
                    this.dgvProductosXServicio.AutoGenerateColumns = false;
                    this.dgvProductosXServicio.DataSource = null;
                    this.dgvProductosXServicio.DataSource = Lista;
                    foreach (DataGridViewRow Fila in this.dgvProductosXServicio.Rows)
                    {
                        Producto AuxProd = this.ObtenerProductoXID(Fila.Cells["IDProducto"].Value.ToString(), Lista);
                        if (!string.IsNullOrEmpty(AuxProd.IDProducto))
                        {
                            DataGridViewComboBoxCell Combo = (DataGridViewComboBoxCell)Fila.Cells["ClaveProduccion"];
                            Combo.DataSource = AuxProd.ListaClaves;
                            Combo.DisplayMember = "ClaveProduccion";
                            Combo.ValueMember = "IDAsignacion";
                            if (AuxProd.ListaClaves.Count > 0)
                            {
                                Combo.Value = AuxProd.ListaClaves[0].IDAsignacion;
                            }
                        }
                    }
                }
                else
                {
                    this.dgvProductosXServicio.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbEmpleados_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Usuario DatosAux = this.ObtenerDatosEmpleado();
                this.LlenarGridProductos(DatosAux.IDEmpleado, this.DatosServicio.IDProducto);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicioTicket ~ cmbEmpleados_SelectedValueChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEmpleados_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbEmpleados.SelectedIndex == -1)
                {
                    this.LlenarGridProductos(string.Empty, this.DatosServicio.IDProducto);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicioTicket ~ cmbEmpleados_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

