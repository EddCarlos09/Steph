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
    public partial class frmNuevaPromocionVenta : Form
    {
        private string IDVenta = string.Empty;
        private Producto DatosServicio = new Producto();
        public frmNuevaPromocionVenta(string ID)
        {
            try
            {
                InitializeComponent();
                IDVenta = ID;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocionVenta ~ frmNuevaPromocionVenta(string ID)");
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
                LogError.AddExcFileTxt(ex, "frmNuevaPromocionVenta ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    PromocionVenta Datos = this.ObtenerDatos();
                    Venta_Negocio VN = new Venta_Negocio();
                    bool Result = VN.AgregarPromocionAVenta(Datos, Comun.Conexion, Comun.IDSucursalCaja, Comun.IDUsuario);
                    if (Result)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        //if (Datos.Resultado == -1)
                        //{
                        //    MessageBox.Show("La venta tiene un vale aplicado. Debe removerlo para agregar servicios. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                        //else if (Datos.Resultado == -2)
                        //{
                        //    MessageBox.Show("El servicio ya se encuentra en la venta. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                        //else if (Datos.Resultado == -3)
                        //{
                        //    MessageBox.Show("El servicio requiere productos extras con los que no cuenta la sucursal. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                        //else
                        //    MessageBox.Show("Ocurrió un error. Intente nuevamente. Si el problema persiste, contacte a Soporte Técnico. Código del Error: " + Datos.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocionVenta ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaPromocionVenta_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocionVenta ~ frmNuevaPromocionVenta_Load");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboPromociones();
                this.ActiveControl = this.cmbPromociones;
                this.cmbPromociones.Focus();
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

        private PromocionVenta ObtenerDatos()
        {
            try
            {
                PromocionVenta Datos = new PromocionVenta();
                Datos.IDVenta = this.IDVenta;
                Datos.IDPromocion = this.ObtenerDatosPromocion().IDPromocion;
                Datos.TablaDatos = this.GenerarTabla();
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
                Producto PromocionAux = this.ObtenerDatosPromocion();
                if (PromocionAux.IDPromocion <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una promoción de la lista.", ControlSender = this.cmbPromociones });
                foreach (DataGridViewRow Fila in this.dgvServiciosPromocion.Rows)
                {
                    DataGridViewComboBoxCell Celda = (DataGridViewComboBoxCell)Fila.Cells["Empleado"];
                    if (Celda.Items.Count > 0)
                    {
                        string IDEmpleado = Celda.Value != null ? Celda.Value.ToString() : string.Empty;
                        if (string.IsNullOrEmpty(IDEmpleado))
                        {
                            Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un empleado en " + Fila.Cells["Servicio"].Value.ToString() + ".", ControlSender = this.dgvServiciosPromocion });
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

        private List<Usuario> ObtenerListaEmpleados()
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, IDSucursalActual = Comun.IDSucursalCaja, IncluirSelect = true };
                Usuario_Negocio UN = new Usuario_Negocio();
                return UN.LlenarComboCatEmpleados(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboPromociones()
        {
            try
            {
                Venta_Negocio VN = new Venta_Negocio();
                this.cmbPromociones.DataSource = VN.ObtenerPromocionesDelDia(true, Comun.Conexion, Comun.IDSucursalCaja);
                this.cmbPromociones.ValueMember = "IDPromocion";
                this.cmbPromociones.DisplayMember = "NombreProducto";
                this.cmbPromociones.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbPromociones.AutoCompleteSource = AutoCompleteSource.ListItems;
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
                TablaAux.Columns.Add("IDPromocion", typeof(int));
                TablaAux.Columns.Add("IDPromocionDetalle", typeof(int));
                TablaAux.Columns.Add("IDPromocionDetalleProd", typeof(int));
                TablaAux.Columns.Add("IDServicio", typeof(string));
                TablaAux.Columns.Add("IDEmpleado", typeof(string));

                foreach (DataGridViewRow Fila in this.dgvServiciosPromocion.Rows)
                {
                    DataGridViewComboBoxCell Combo = (DataGridViewComboBoxCell)Fila.Cells["Empleado"];
                    if (Combo.Items.Count > 0)
                    {
                        string IDEmpleado = Combo.Value != null ? Combo.Value.ToString() : string.Empty;
                        string IDServicio = Fila.Cells["IDServicio"].Value.ToString();
                        int IDPromocion = 0, IDPromocionDetalle = 0, IDPromocionDetalleProd = 0;
                        int.TryParse(Fila.Cells["IDPromocion"].Value.ToString(), out IDPromocion);
                        int.TryParse(Fila.Cells["IDPromocionDetalle"].Value.ToString(), out IDPromocionDetalle);
                        int.TryParse(Fila.Cells["IDPromocionDetalleProd"].Value.ToString(), out IDPromocionDetalleProd);
                        object[] NuevaFila = { IDPromocion, IDPromocionDetalle, IDPromocionDetalleProd, IDServicio, IDEmpleado };
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
                if (this.cmbPromociones.SelectedIndex != -1)
                {
                    Aux = (Usuario)this.cmbPromociones.SelectedItem;
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Producto ObtenerDatosPromocion()
        {
            try
            {
                Producto Aux = new Producto();
                if (this.cmbPromociones.SelectedIndex != -1)
                {
                    Aux = (Producto)this.cmbPromociones.SelectedItem;
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void LlenarGridServicios(int IDPromocion)
        {
            try
            {
                if (IDPromocion > 0)
                {
                    
                    Servicio_Negocio SN = new Servicio_Negocio();
                    List<Producto> Lista = SN.ObtenerServiciosXIDPromocion(Comun.Conexion, IDPromocion);
                    this.dgvServiciosPromocion.AutoGenerateColumns = false;
                    this.dgvServiciosPromocion.DataSource = null;
                    this.dgvServiciosPromocion.DataSource = Lista;

                    List<Usuario> ListaEmpleados = ObtenerListaEmpleados();
                    foreach (DataGridViewRow Fila in this.dgvServiciosPromocion.Rows)
                    {
                        DataGridViewComboBoxCell Combo = (DataGridViewComboBoxCell)Fila.Cells["Empleado"];
                        Combo.DataSource = ListaEmpleados;//this.ClonarLista(ListaEmpleados);
                        Combo.DisplayMember = "Nombre";
                        Combo.ValueMember = "IDEmpleado";
                        if (ListaEmpleados.Count > 0)
                        {
                            Combo.Value = ListaEmpleados[0].IDEmpleado;
                        }
                    }
                }
                else
                {
                    this.dgvServiciosPromocion.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbPromociones_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Producto DatosAux = this.ObtenerDatosPromocion();
                this.LlenarGridServicios(DatosAux.IDPromocion);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocionVenta ~ cmbPromociones_SelectedValueChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPromociones_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbPromociones.SelectedIndex == -1)
                {
                    this.LlenarGridServicios(-1);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocionVenta ~ cmbPromociones_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public List<Usuario> ClonarLista(List<Usuario> Empleados)
        {
            try
            {
                List<Usuario> ListaClonada = new List<Usuario>();
                Usuario ItemClonado;
                foreach(Usuario Item in Empleados)
                {
                    ItemClonado = new Usuario { IDUsuario = Item.IDUsuario, Nombre = Item.Nombre };
                    ListaClonada.Add(ItemClonado);
                }
                return ListaClonada;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}

