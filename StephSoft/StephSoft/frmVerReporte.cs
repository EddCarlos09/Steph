using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using Microsoft.Reporting.WinForms;
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
    public partial class frmVerReporte : Form
    {

        private int TipoListado = 0;
        private string ID = string.Empty;


        public frmVerReporte(int Tipo, string AuxID)
        {
            try
            {
                InitializeComponent();
                this.ID = AuxID;
                this.TipoListado = Tipo;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerListados ~ frmVerListados()");
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
                LogError.AddExcFileTxt(ex, "frmVerListados ~ btnSalir_Click");
            }
        }

        private void frmVerReporte_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarReporte();
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerListados ~ frmVerReporte_Load");
            }
        }



        private void CargarReporte()
        {
            try
            {
                switch (TipoListado)
                {
                    case 1: 
                        this.lblTitulo.Text = "CITAS DEL DÍA";
                        break;
                    case 2: this.GenerarReporteCajas();
                        this.panel8.Visible = false;
                        this.lblTitulo.Text = "CIERRE DE CAJA";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteCitas()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                Cita Datos = new Cita { Conexion = Comun.Conexion, IDSucursal = ID, FechaCita=this.dtpFechaInicio.Value };
                Cita_Negocio CN = new Cita_Negocio();
                List<Cita> Lista = CN.ObtenerCitasPorSucursal(Datos);
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[5];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                Parametros[2] = new ReportParameter("Direccion", Comun.Direccion);
                Parametros[4] = new ReportParameter("TituloReporte", "CITAS DEL DÍA");
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[3] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                    Parametros[3] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephSoft.Informes.InformeCitas.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Citas", Lista));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteCajas()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                Caja Datos = new Caja { Conexion = Comun.Conexion, IDCaja = ID };
                Caja_Negocio CN = new Caja_Negocio();
                CN.ObtenerReporteResumenCaja(Datos);
                if (Datos.Completado)
                {
                    List<FormaPago> Lista = Datos.ListaFormasPago;
                    reportViewer1.LocalReport.EnableExternalImages = true;
                    ReportParameter[] Parametros = new ReportParameter[16];
                    Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                    Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                    Parametros[2] = new ReportParameter("Direccion", Comun.Direccion);
                    Parametros[4] = new ReportParameter("TituloReporte", "RESUMEN DE CAJA");
                    if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                    {
                        string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                        Parametros[3] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                    }
                    else
                        Parametros[3] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);

                    Parametros[5] = new ReportParameter("Cajero", Datos.Cajero);
                    Parametros[6] = new ReportParameter("FechaInicio", Datos.FechaHoraApertura);
                    Parametros[7] = new ReportParameter("FechaFin", Datos.FechaHoraCierre);
                    Parametros[8] = new ReportParameter("Apertura", Datos.Apertura.ToString());
                    Parametros[9] = new ReportParameter("Ventas", Datos.TotalVentas.ToString());
                    Parametros[10] = new ReportParameter("Depositos", Datos.TotalDepositos.ToString());
                    Parametros[11] = new ReportParameter("Retiros", Datos.TotalRetirosCajaLlena.ToString());
                    Parametros[12] = new ReportParameter("CierreCaja", Datos.Cierre.ToString());
                    Parametros[13] = new ReportParameter("Cancelaciones", Datos.TotalCancelaciones.ToString());
                    Parametros[14] = new ReportParameter("Penalizacion", Datos.Penalizaciones.ToString());
                    Parametros[15] = new ReportParameter("Saldo", Datos.Saldo.ToString());


                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephSoft.Informes.ResumenCaja.rdlc";
                    reportViewer1.LocalReport.SetParameters(Parametros);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("FormasPago", Lista));
                    this.reportViewer1.RefreshReport();
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.GenerarReporteCitas();
            }
            catch (Exception ex)
            {

                LogError.AddExcFileTxt(ex, "frmVerListados ~ btnGenerar_Click()");
            }
        }
    }
}
