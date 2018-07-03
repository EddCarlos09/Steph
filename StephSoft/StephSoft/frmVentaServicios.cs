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
    public partial class frmVentaServicios : Form
    {
        #region Variables

        private Venta DatosVenta = new Venta();
        private bool BandCambios = false;
        private bool BandVales = false;

        #endregion

        #region Constructor

        public frmVentaServicios(Venta Datos)
        {
            try
            {
                InitializeComponent();
                this.DatosVenta = Datos;
                //Comun.FechaActual = DateTime.Now;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVentaServicios ~ frmVentaServicios()");
            }
        }
            
        #endregion

        #region Métodos

        private void CargarGridServicios()
        {
            try
            {
                Venta DatosAux = new Venta { Conexion = Comun.Conexion, IDVenta = this.DatosVenta.IDVenta };
                Venta_Negocio VN = new Venta_Negocio();
                VN.ObtenerServiciosXIDVenta(DatosAux);
                this.dgvServicios.DataSource = null;
                this.dgvServicios.AutoGenerateColumns = false;
                this.dgvServicios.DataSource = DatosAux.TablaDatos;
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
                this.lblFolio.Text = this.DatosVenta.FolioVenta;
                this.txtNombreCliente.Text = this.DatosVenta.NombreCliente;
                this.BandVales = this.ObtenerExisteValeXIDVenta();
                this.CargarGridServicios();
                this.TimerTiempo.Enabled = true;
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

        private VentaDetalle ObtenerDatosVentaServicios(int Row)
        {
            try
            {
                VentaDetalle DatosAux = new VentaDetalle();
                bool Concluido = false;
                int IDEstatusServicio = 0;
                string IDVentaServ = string.Empty;
                DataGridViewRow Fila = this.dgvServicios.Rows[Row];
                bool.TryParse(Fila.Cells["Concluido"].Value.ToString(), out Concluido);
                int.TryParse(Fila.Cells["IDEstatusServicio"].Value.ToString(), out IDEstatusServicio);
                IDVentaServ = Fila.Cells["IDVentaServicio"].Value.ToString();
                DatosAux.IDVenta = this.DatosVenta.IDVenta;
                DatosAux.Concluido = Concluido;
                DatosAux.IDVentaServicio = IDVentaServ;
                DatosAux.IDEstatusServicio = IDEstatusServicio;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.IDVenta = this.DatosVenta.IDVenta;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ObtenerExisteValeXIDVenta()
        {
            try
            {
                Venta Datos = new Venta { Conexion = Comun.Conexion, IDVenta = this.DatosVenta.IDVenta };
                Venta_Negocio VN = new Venta_Negocio();
                return VN.TieneVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ServiciosCerrados()
        {
            try
            {
                bool Band = true;
                foreach (DataGridViewRow Fila in this.dgvServicios.Rows)
                {
                    bool Concluido = false;
                    bool.TryParse(Fila.Cells["Concluido"].Value.ToString(), out Concluido);
                    if (!Concluido)
                    {
                        Band = false;
                        break;
                    }
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void bgwDibujarTiempo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //Comun.FechaActual = Comun.FechaActual.AddSeconds(1);
                foreach (DataGridViewRow Fila in this.dgvServicios.Rows)
                {
                    bool Completado = false;
                    bool.TryParse(Fila.Cells["Concluido"].Value.ToString(), out Completado);
                    if (!Completado)
                    {
                        DateTime FechaInicio = DateTime.Parse(Fila.Cells["HoraInicio"].Value.ToString());
                        TimeSpan Aux = Comun.FechaActual - FechaInicio;
                        string Texto = Aux.ToString(@"d\.hh\:mm\:ss");
                        Fila.Cells["Tiempo"].Value = Texto;
                    }
                }

            }
            catch (Exception ex)
            {
                this.TimerTiempo.Start();
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ bgwDibujarTiempo_DoWork");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwDibujarTiempo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.TimerTiempo.Start();
            }
            catch (Exception ex)
            {
                this.TimerTiempo.Start();
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ bgwDibujarTiempo_RunWorkerCompleted");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BandVales)
                {
                    frmNuevoServicioTicket NServ = new frmNuevoServicioTicket(this.DatosVenta.IDVenta);
                    NServ.ShowDialog();
                    NServ.Dispose();
                    if (NServ.DialogResult == DialogResult.OK)
                    {
                        this.CargarGridServicios();
                        BandCambios = true;
                    }
                }
                else
                {
                    MessageBox.Show("La venta tiene un vale aplicado. Debe removerlo para agregar servicios.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);    
                }
                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ btnAgregarServicio_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.SelectedRows.Count == 1)
                {
                    int Row = this.dgvServicios.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    VentaDetalle Datos = this.ObtenerDatosVentaServicios(Row);
                    if (!string.IsNullOrEmpty(Datos.IDVentaServicio))
                    {
                        if (!Datos.Concluido)
                        {
                            Venta_Negocio VN = new Venta_Negocio();
                            VN.QuitarServicio(Datos);
                            if (Datos.Completado)
                            {
                                this.CargarGridServicios();
                                BandCambios = true;
                            }
                            else
                            {
                                if (Datos.Resultado == -1)
                                    MessageBox.Show("No se puede completar la acción. El servicio ya está concluido.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (Datos.Resultado == -2)
                                    MessageBox.Show("No se puede completar la acción. El servicio tiene productos extra, debe quitarlos para continuar.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                else
                                    MessageBox.Show("Ocurrió un error al guardar los datos. Código del error : " + Datos.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("No se puede completar la acción. El servicio ya está concluido.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ btnCancelarServicio_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.Rows.Count > 0)
                {
                    if (ServiciosCerrados())
                    {
                        frmResumenVenta Cobrar = new frmResumenVenta(this.DatosVenta.IDVenta);
                        this.Visible = false;
                        Cobrar.ShowDialog();
                        BandCambios = Cobrar.BandCambios;
                        Cobrar.Dispose();
                        this.Visible = true;
                        if (Cobrar.DialogResult == DialogResult.OK)
                        {
                            this.BandCambios = true;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            this.BandVales = this.ObtenerExisteValeXIDVenta();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe concluir todos los servicios. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Debe agregar productos a la venta. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ btnCobrar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConcluirServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.SelectedRows.Count == 1)
                {
                    int Row = this.dgvServicios.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    VentaDetalle Datos = this.ObtenerDatosVentaServicios(Row);
                    if (!string.IsNullOrEmpty(Datos.IDVentaServicio))
                    {
                        if (!Datos.Concluido)
                        {
                            Venta_Negocio VN = new Venta_Negocio();
                            VN.ConcluirServicio(Datos);
                            if (Datos.Completado)
                            {
                                this.CargarGridServicios();
                                BandCambios = true;
                            }
                            else
                            {
                                if (Datos.Resultado == -1)
                                    MessageBox.Show("No se puede completar la acción. El servicio ya está concluido.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                else
                                    MessageBox.Show("Ocurrió un error al guardar los datos. Código del error : " + Datos.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("No se puede completar la acción. El servicio ya está concluido.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ btnAgregarServicio_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (BandCambios)
                    this.DialogResult = DialogResult.OK;
                else
                    this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ btnRegresar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvServicios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    VentaDetalle Datos = this.ObtenerDatosVentaServicios(e.RowIndex);
                    if (!string.IsNullOrEmpty(Datos.IDVentaServicio))
                    {
                        if (!Datos.Concluido)
                        {
                            frmTicketDetalleProductosXServicio Detalle = new frmTicketDetalleProductosXServicio(Datos, this.BandVales);
                            this.Visible = false;
                            Detalle.ShowDialog();
                            Detalle.Dispose();
                            this.Visible = true;
                            if (Detalle.BandCambios)
                            {
                                this.CargarGridServicios();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El servicio ya está concluido. Ya no se pueden realizar modificaciones.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ dgvServicios_CellContentDoubleClick");
            }
        }

        private void frmDatosServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (BandCambios)
                    this.DialogResult = DialogResult.OK;
                else
                    this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ frmDatosServicio_FormClosing");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDatosServicio_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ frmDatosServicio_Load");
            }
        }

        private void TimerTiempo_Tick(object sender, EventArgs e)
        {
            try
            {
                this.TimerTiempo.Stop();
                this.bgwDibujarTiempo.RunWorkerAsync();
                //foreach (DataGridViewRow Fila in this.dgvServicios.Rows)
                //{
                //    //int Segundos = 0;
                //    //int.TryParse(Fila.Cells["TiempoSegundos"].Value.ToString(), out Segundos);
                //    //Segundos = Segundos + 1;
                //    //TimeSpan Tiempo = new TimeSpan(0, 0, Segundos);
                //    //Fila.Cells["TiempoSegundos"].Value = Segundos;
                //    //Fila.Cells["Tiempo"].Value = this.ObtenerTiempoTranscurrido(Segundos);
                //    Comun.FechaActual = Comun.FechaActual.AddSeconds(1);
                //    DateTime FechaInicio = DateTime.Parse(Fila.Cells["HoraInicio"].Value.ToString());
                //    TimeSpan Aux = Comun.FechaActual - FechaInicio;
                //    string Texto = Aux.ToString();
                //    Fila.Cells["Tiempo"].Value = Texto;
                //}
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmDatosServicio ~ TimerTiempo_Tick");
                //MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
