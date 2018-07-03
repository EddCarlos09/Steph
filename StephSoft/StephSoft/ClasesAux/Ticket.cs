using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StephSoft.ClasesAux
{
    public class Ticket
    {
        #region Variables

        int TipoTicket = 0, TotalCopias = 0;
        Venta ResumenVenta = new Venta();
        Caja ResumenCaja = new Caja();
        Garantia ResumenGarantia = new Garantia();
        string ID = string.Empty;
        string IDCaja = string.Empty;
        #endregion

        #region Constructor

        public Ticket(int Tipo, int Copias)
        {
            try
            {
                TipoTicket = Tipo;
                TotalCopias = Copias;
                ResumenVenta.ListaDetalle = new List<VentaDetalle>();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "Ticket ~ Ticket(int Tipo, int Copias)");
            }
        }

        public Ticket(int Tipo, int Copias, string IDVentaAux)
        {
            try
            {
                TipoTicket = Tipo;
                TotalCopias = Copias;
                this.ID = IDVentaAux;
                ResumenVenta.ListaDetalle = new List<VentaDetalle>();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "Ticket ~ Ticket(int Tipo, int Copias)");
            }
        }

        public Ticket(int Copias, string IDCajaAux)
        {
            try
            {
                TipoTicket = 3;
                TotalCopias = Copias;
                this.IDCaja = IDCajaAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "Ticket ~ Ticket(int Tipo, int Copias)");
            }
        }

        #endregion

        #region Métodos

        public void ImprimirTicket()
        {
            try
            {
                switch (TipoTicket)
                {
                    case 1:
                    case 2: Venta Aux = new Venta { IDVenta = this.ID, Conexion = Comun.Conexion };
                        Ticket_Negocio TN = new Ticket_Negocio();
                        TN.ObtenerDetalleVenta(Aux);
                        if (Aux.Completado)
                            this.ResumenVenta = Aux;
                        break;
                    case 3: Caja DatosAuxCaja = new Caja { IDCaja = this.IDCaja, Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
                        Caja_Negocio CN = new Caja_Negocio();
                        CN.ObtenerReporteTicketCaja(DatosAuxCaja);
                        if (DatosAuxCaja.Completado)
                            this.ResumenCaja = DatosAuxCaja;
                        else
                            return;
                        break;
                    case 4: Garantia DatosAuxGarantia = new Garantia { IDGarantia = this.ID, Conexion = Comun.Conexion };
                        Garantia_Negocio GN = new Garantia_Negocio();
                        DatosAuxGarantia = GN.ObtenerDetalleGarantia(DatosAuxGarantia);
                        if (DatosAuxGarantia.Completado)
                            this.ResumenGarantia = DatosAuxGarantia;
                        else
                            return;
                        break;
                    default: ResumenVenta = new Venta();
                        break;
                }
                for (int i = 0; i < TotalCopias; i++)
                {
                    PositionY = 10;
                    this.ImpresionTicket();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Impresión y Diseño del Ticket

        int PositionY = 0;

        private void ImpresionTicket()
        {
            PrintDocument Documento = new PrintDocument();
            PaperSize Plantilla;
            Plantilla = new PaperSize("Ticket", 275, 1000);
            Documento.DefaultPageSettings.PaperSize = Plantilla;
            Documento.PrintPage += new PrintPageEventHandler(Document_PrintPage);
            PrinterSettings Ps = new PrinterSettings();
            Ps.PrinterName = Comun.Impresora;
            Ps.DefaultPageSettings.PaperSize = Plantilla;
            Documento.PrinterSettings = Ps;
            if (Ps.IsValid)
                Documento.Print();
            else
                return;
            //throw new Exception("No se pudo conectar con la impresora.");
        }

        void Document_PrintPage(object sender, PrintPageEventArgs e)
        {

            PrintDocument dc = (PrintDocument)sender;
            PaperSize plantilla = new PaperSize("Ticket", 275, 1000);
            switch (TipoTicket)
            {
                case 1: plantilla = new PaperSize("Ticket", 275, 600);
                    break;
                case 2: plantilla = new PaperSize("Ticket", 275, 300);
                    break;
                case 3: plantilla = new PaperSize("Ticket", 275, 10000);
                    break;
                case 4: plantilla = new PaperSize("Ticket", 275, 300);
                    break;
            }
            dc.DefaultPageSettings.PaperSize = plantilla;
            PageSettings Ps = dc.DefaultPageSettings;
            Graphics G = e.Graphics;
            SolidBrush Brush = new SolidBrush(Color.Black);
            this.AgregarEncabezado(ref G, Ps);

            switch (TipoTicket)
            {
                case 1:
                case 2: this.AgregarEncabezadoContenido(ref G, Ps);
                    this.AgregarDatosContenido(ref G, ResumenVenta.ListaDetalle, Ps);
                    this.AgregarTotales(ref G, Ps);
                    this.AgregarPieTicket(ref G, Ps);
                    break;
                case 3: this.CuerpoTicketCaja(ref G, Ps);
                    break;
                case 4: this.CuerpoTicketGarantia(ref G, Ps);
                    break;
            }


        }

        #region Métodos para la construccion del documento a imprimir

        private void AgregarEncabezado(ref Graphics G, PageSettings Ps)
        {
            try
            {
                // *******************************    DATOS DEL ENCABEZADO  ************************************ //
                if (!string.IsNullOrEmpty(Comun.UrlLogo))
                {
                    if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo))
                    {
                        this.AddLogo(Image.FromFile(@"Resources\Documents\" + Comun.UrlLogo), ref G, Ps.PaperSize.Width);
                    }
                }
                if (!string.IsNullOrEmpty(Comun.RegimenFiscal))
                    this.AddTitulos(ref G, Ps, Comun.RegimenFiscal, new Font("Arial", 7, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                if (!string.IsNullOrEmpty(Comun.NombreComercial))
                    this.AddTitulos(ref G, Ps, Comun.NombreComercial, new Font("Arial", 9, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                if (!string.IsNullOrEmpty(Comun.Eslogan))
                    this.AddTitulos(ref G, Ps, Comun.Eslogan, new Font("Arial", 9, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                if (!string.IsNullOrEmpty(Comun.Direccion))
                    this.AddTitulos(ref G, Ps, Comun.Direccion, new Font("Arial", 8, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                if (!string.IsNullOrEmpty(Comun.RFC))
                    //this.addTextCenter("RFC. " + Comun.RFC, ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                    this.AddTitulos(ref G, Ps, "RFC. " + Comun.RFC, new Font("Arial", 8, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                if (!string.IsNullOrEmpty(Comun.Sucursal))
                    //this.addTextCenter("SUCURSAL: " + Comun.Nombre_Sucursal, ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                    this.AddTitulos(ref G, Ps, "SUCURSAL: " + Comun.Sucursal, new Font("Arial", 8, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                // **************************** TERMINA REGION DATOS DEL ENCABEZADO  *************************** //
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AgregarEncabezadoContenido(ref Graphics G, PageSettings Ps)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF Pf = new PointF();
                StringFormat Sf = new StringFormat();
                Pf.X = 10;
                Pf.Y = PositionY += 25;
                Sf.Alignment = StringAlignment.Near;
                switch (TipoTicket)
                {
                    case 1: G.DrawString("DETALLE DE VENTA", new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                        break;
                    case 2: G.DrawString("DETALLE DEL SERVICIO", new Font("Arial", 8), Brush, Pf, Sf);
                        break;
                }
                Pf.X = 10;
                Pf.Y = PositionY += 25;
                Sf.Alignment = StringAlignment.Near;
                G.DrawString("Cant", new Font("Arial", 8), Brush, Pf, Sf);
                Pf.X = 40;
                G.DrawString("Concepto", new Font("Arial", 8), Brush, Pf, Sf);
                Pf.X = 190;
                Sf.Alignment = StringAlignment.Far;
                G.DrawString("P/U", new Font("Arial", 8), Brush, Pf, Sf);
                Pf.X = Ps.PaperSize.Width - 15;
                G.DrawString("Importe", new Font("Arial", 8), Brush, Pf, Sf);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AgregarDatosContenido(ref Graphics G, List<VentaDetalle> DetalleVenta, PageSettings Ps)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                StringFormat sf = new StringFormat();
                bool BandDescuento = false;
                foreach (VentaDetalle Detalle in DetalleVenta)
                {
                    sf.Alignment = StringAlignment.Near;
                    pf.Y = PositionY += 15;
                    pf.X = 10;
                    G.DrawString(string.Format("{0:F2}", Detalle.CantidadVenta), new Font("Arial", 8), Brush, pf, sf);
                    pf.X = 40;
                    if (Detalle.NombreProducto.Length > 12)
                    {
                        int aux = 12;
                        while (G.MeasureString(Detalle.NombreProducto.Substring(0, aux), new Font("Arial", 8)).Width < 95)
                        {
                            aux++;
                            if (Detalle.NombreProducto.Length < aux)
                                break;
                        }
                        G.DrawString(Detalle.NombreProducto.Substring(0, aux - 1), new Font("Arial", 8), Brush, pf, sf);
                    }
                    else
                        G.DrawString(Detalle.NombreProducto, new Font("Arial", 8), Brush, pf, sf);
                    sf.Alignment = StringAlignment.Far;
                    pf.X = 190;
                    G.DrawString(string.Format("{0:c}", Detalle.PrecioNormal), new Font("Arial", 8), Brush, pf, sf);
                    pf.X = Ps.PaperSize.Width - 15;
                    G.DrawString(string.Format("{0:c}", Detalle.Subtotal), new Font("Arial", 8), Brush, pf, sf);
                    if (Detalle.Descuento > 0)
                    {
                        pf.X = Ps.PaperSize.Width - 5;
                        G.DrawString("D", new Font("Arial", 8, FontStyle.Bold), Brush, pf, sf);
                        BandDescuento = true;
                    }
                }
                PositionY += 15;
                if (BandDescuento)
                {
                    pf.Y = PositionY;
                    this.AddMensajeTitle(ref G, Ps, " D E S C U E N T O S", new Font("Arial", 9, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                    pf.Y = PositionY += 15;
                    foreach (VentaDetalle Detalle in DetalleVenta)
                    {
                        if (Detalle.Descuento > 0)
                        {
                            sf.Alignment = StringAlignment.Near;
                            pf.X = 10;
                            G.DrawString(ResumenVenta.CodigoVale, new Font("Arial", 8), Brush, pf, sf);
                            sf.Alignment = StringAlignment.Far;
                            pf.X = Ps.PaperSize.Width - 15;
                            G.DrawString(string.Format("{0:c}", Detalle.Descuento * -1), new Font("Arial", 8), Brush, pf, sf);
                            pf.Y = PositionY += 15;
                        }
                    }
                }

                PositionY += 15;
                if (ResumenVenta.ListaProductos.Count > 0)
                {
                    pf.Y = PositionY;
                    this.AddMensajeTitle(ref G, Ps, "TARJETAS DE REGALO", new Font("Arial", 9, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                    pf.Y = PositionY += 15;
                    foreach (Producto Item01 in ResumenVenta.ListaProductos)
                    {
                        sf.Alignment = StringAlignment.Near;
                        pf.X = 10;
                        G.DrawString(Item01.Clave, new Font("Arial", 8), Brush, pf, sf);
                        sf.Alignment = StringAlignment.Near;
                        pf.X = 90;
                        G.DrawString(Item01.NombreProducto, new Font("Arial", 8), Brush, pf, sf);
                        pf.Y = PositionY += 15;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AgregarTotales(ref Graphics G, PageSettings Ps)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF Pf = new PointF();
                StringFormat Sf = new StringFormat();
                //==============================================================================================
                Pf.Y = PositionY += 15;
                Sf.Alignment = StringAlignment.Far;
                Pf.X = 180;
                G.DrawString(string.Format("SUBTOTAL"), new Font("Arial", 8), Brush, Pf, Sf);
                Pf.X = Ps.PaperSize.Width - 15;
                G.DrawString(string.Format("{0:c}", ResumenVenta.Subtotal), new Font("Arial", 8), Brush, Pf, Sf);
                //==============================================================================================
                Pf.Y = PositionY += 15;
                Sf.Alignment = StringAlignment.Far;
                Pf.X = 180;
                G.DrawString(string.Format("DESCUENTO"), new Font("Arial", 8), Brush, Pf, Sf);
                Pf.X = Ps.PaperSize.Width - 15;
                G.DrawString(string.Format("{0:c}", ResumenVenta.Descuento), new Font("Arial", 8), Brush, Pf, Sf);
                //==============================================================================================
                Pf.Y = PositionY += 15;
                Sf.Alignment = StringAlignment.Far;
                Pf.X = 180;
                G.DrawString(string.Format("TOTAL"), new Font("Arial", 8), Brush, Pf, Sf);
                Pf.X = Ps.PaperSize.Width - 15;
                G.DrawString(string.Format("{0:c}", ResumenVenta.Total), new Font("Arial", 8), Brush, Pf, Sf);
                //==============================================================================================
                if (ResumenVenta.Comision > 0)
                {
                    Pf.Y = PositionY += 15;
                    Sf.Alignment = StringAlignment.Far;
                    Pf.X = 180;
                    G.DrawString(string.Format("COMISIÓN POR PAGO"), new Font("Arial", 8), Brush, Pf, Sf);
                    Pf.X = Ps.PaperSize.Width - 15;
                    G.DrawString(string.Format("{0:c}", ResumenVenta.Comision), new Font("Arial", 8), Brush, Pf, Sf);
                }
                //==============================================================================================
                //Pf.Y = PositionY += 15;
                //Sf.Alignment = StringAlignment.Far;
                //Pf.X = 180;
                //G.DrawString(string.Format("PAGO"), new Font("Arial", 8), Brush, Pf, Sf);
                //Pf.X = Ps.PaperSize.Width - 15;
                //G.DrawString(string.Format("{0:c}", ResumenVenta.TotalPago), new Font("Arial", 8), Brush, Pf, Sf);
                //==============================================================================================
                foreach (FormaPago ItemFP in ResumenVenta.ListaFormasPago)
                {
                    Pf.Y = PositionY += 15;
                    Sf.Alignment = StringAlignment.Far;
                    Pf.X = 180;
                    G.DrawString(ItemFP.Descripcion.ToUpper(), new Font("Arial", 8), Brush, Pf, Sf);
                    Pf.X = Ps.PaperSize.Width - 15;
                    G.DrawString(string.Format("{0:c}", ItemFP.MontoTotal), new Font("Arial", 8), Brush, Pf, Sf);
                }
                //==============================================================================================
                Pf.Y = PositionY += 15;
                Sf.Alignment = StringAlignment.Far;
                Pf.X = 180;
                G.DrawString(string.Format("CAMBIO"), new Font("Arial", 8), Brush, Pf, Sf);
                Pf.X = Ps.PaperSize.Width - 15;
                G.DrawString(string.Format("{0:c}", ResumenVenta.TotalCambio), new Font("Arial", 8), Brush, Pf, Sf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AgregarPieTicket(ref Graphics G, PageSettings Ps)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF Pf = new PointF();
                StringFormat Sf = new StringFormat();
                //==============================================================================================
                //Folio Venta, Total en letras, Fecha y hora Sistema
                Pf.Y = PositionY += 25;
                ConvertirMonedaTexto Convr = new ConvertirMonedaTexto();
                this.AddMensajeTitle(ref G, Ps, Convr.Convertir(ResumenVenta.Total.ToString(), true), new Font("Arial", 7, FontStyle.Bold), StringAlignment.Near, 10);
                this.AddMensajeTitle(ref G, Ps, "FOLIO VENTA: " + ResumenVenta.FolioVenta, new Font("Arial", 7, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                if (!string.IsNullOrEmpty(ResumenVenta.NombreCliente))
                {
                    this.AddMensajeTitle(ref G, Ps, " ** GRACIAS POR SU COMPRA ** ", new Font("Arial", 7, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                    this.AddMensajeTitle(ref G, Ps, ResumenVenta.NombreCliente.ToUpper(), new Font("Arial", 7, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                }
                //===============================================================================================

                Sf.Alignment = StringAlignment.Center;
                int Aux = Ps.PaperSize.Width / 4;
                Pf.X = Aux;
                Pf.Y = PositionY;
                G.DrawString(ResumenVenta.FechaHoraSistema.ToString("dd/MM/yyyy"), new Font("Arial", 8), Brush, Pf, Sf);
                Pf.X = Aux * 3;
                G.DrawString(ResumenVenta.FechaHoraSistema.ToString("HH:mm:ss"), new Font("Arial", 8), Brush, Pf, Sf);
                Pf.Y = PositionY += 25;


                if (ResumenVenta.IDTipoVenta == 2 && !string.IsNullOrEmpty(ResumenVenta.TextoVenta))
                {
                    this.AddMensajeTitle(ref G, Ps, ResumenVenta.TextoVenta.ToUpper(), new Font("Arial", 7, FontStyle.Bold), StringAlignment.Center, Ps.PaperSize.Width / 2);
                }

                this.AddLetterSpace('-', ref G, Ps.PaperSize.Width, Ps.PaperSize.Height, new Font("Arial", 8, FontStyle.Bold));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CuerpoTicketCaja(ref Graphics G, PageSettings Ps)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF Pf = new PointF();
                StringFormat Sf = new StringFormat();
                Pf.X = 10;
                Pf.Y = PositionY += 25;
                Sf.Alignment = StringAlignment.Near;
                G.DrawString("FECHA: " + ResumenCaja.FechaTicket.ToShortDateString(), new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                Pf.Y = PositionY += 15;
                Sf.Alignment = StringAlignment.Near;
                G.DrawString("FOLIO: " + ResumenCaja.FolioTicket.ToString(), new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                Pf.Y = PositionY += 10;

                foreach (FormaPago Item in this.ResumenCaja.ListaFormasPago)
                {
                    Pf.X = 10;
                    Pf.Y = PositionY += 15;
                    Sf.Alignment = StringAlignment.Near;
                    G.DrawString(Item.Descripcion.ToUpper(), new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);

                    Pf.X = 190;
                    Sf.Alignment = StringAlignment.Far;
                    G.DrawString(string.Format("{0:c}", Item.MontoTotal), new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                }

                Pf.Y = PositionY += 10;

                foreach (Usuario ItemUser in this.ResumenCaja.ListaEmpleados)
                {
                    Pf.X = 10;
                    Pf.Y = PositionY += 15;
                    Sf.Alignment = StringAlignment.Near;
                    this.AddLetterSpace('-', ref G, Ps.PaperSize.Width, Ps.PaperSize.Height, new Font("Arial", 8, FontStyle.Bold));
                    Pf.Y = PositionY += 15;
                    G.DrawString(ItemUser.Nombre.ToUpper(), new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                    this.AddLetterSpace('-', ref G, Ps.PaperSize.Width, Ps.PaperSize.Height, new Font("Arial", 8, FontStyle.Bold));
                    foreach (VentaDetalle ItemServ in this.ResumenCaja.ListaServicios)
                    {
                        if (ItemServ.IDEmpleado == ItemUser.IDEmpleado)
                        {
                            Pf.X = 15;
                            Pf.Y = PositionY += 15;
                            Sf.Alignment = StringAlignment.Near;
                            if (ItemServ.Descripcion.Length > 20)
                            {
                                int aux = 20;
                                while (G.MeasureString(ItemServ.Descripcion.Substring(0, aux), new Font("Arial", 8)).Width < 180)
                                {
                                    aux++;
                                    if (ItemServ.Descripcion.Length < aux)
                                        break;
                                }
                                G.DrawString(ItemServ.Descripcion.Substring(0, aux - 1), new Font("Arial", 8), Brush, Pf, Sf);
                            }
                            else
                            {
                                G.DrawString(ItemServ.Descripcion, new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                            }
                            Pf.X = Ps.PaperSize.Width - 30;
                            Sf.Alignment = StringAlignment.Far;
                            G.DrawString(string.Format("{0:c}", ItemServ.Total), new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                            if (ItemServ.CantidadVenta > 1)
                            {
                                Pf.X = Pf.X + 15;
                                G.DrawString("(" + ((int)ItemServ.CantidadVenta).ToString() + ")", new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                            }
                        }
                    }
                    Pf.Y = PositionY += 25;
                    Pf.X = Ps.PaperSize.Width - 30;
                    Sf.Alignment = StringAlignment.Far;
                    G.DrawString(string.Format("{0:c}", ItemUser.TotalVentas), new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CuerpoTicketGarantia(ref Graphics G, PageSettings Ps)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF Pf = new PointF();
                StringFormat Sf = new StringFormat();
                Pf.X = 10;
                Pf.Y = PositionY += 25;
                Sf.Alignment = StringAlignment.Near;
                G.DrawString("GARANTÍA: " + ResumenGarantia.CodigoVale, new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                Pf.Y = PositionY += 15;
                G.DrawString("FOLIO DE VENTA: " + ResumenGarantia.FolioVenta, new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                Pf.Y = PositionY += 15;
                G.DrawString("CLIENTE: " + ResumenGarantia.IDCliente.ToUpper(), new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                Pf.Y = PositionY += 25;
                G.DrawString("SERVICIO(S) A GARANTÍA ", new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);

                Pf.X = 10;
                Pf.Y = PositionY += 15;
                Sf.Alignment = StringAlignment.Near;
                G.DrawString("CLAVE", new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);

                Pf.X = 90;
                Sf.Alignment = StringAlignment.Near;
                G.DrawString("SERVICIO", new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);

                foreach (VentaDetalle Item in this.ResumenGarantia.ListaDetalle)
                {
                    Pf.X = 10;
                    Pf.Y = PositionY += 15;
                    Sf.Alignment = StringAlignment.Near;
                    G.DrawString(Item.Clave.ToUpper(), new Font("Arial", 8, FontStyle.Regular), Brush, Pf, Sf);

                    Pf.X = 90;
                    Sf.Alignment = StringAlignment.Near;
                    G.DrawString(Item.NombreProducto.ToUpper(), new Font("Arial", 8, FontStyle.Regular), Brush, Pf, Sf);
                }

                Pf.X = 10;
                Pf.Y = PositionY += 25;
                Sf.Alignment = StringAlignment.Near;
                G.DrawString("OBSERVACIONES", new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                this.AddMensaje(ref G, Ps, this.ResumenGarantia.Observaciones.ToUpper(), new Font("Arial", 8), StringAlignment.Near, 10);

                Pf.Y = PositionY += 25;
                Sf.Alignment = StringAlignment.Near;
                G.DrawString("EMPLEADO QUE AUTORIZA", new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                Pf.Y = PositionY += 15;
                G.DrawString(this.ResumenGarantia.IDEmpleadoAutoriza.ToUpper(), new Font("Arial", 8, FontStyle.Regular), Brush, Pf, Sf);

                if (!string.IsNullOrEmpty(ResumenGarantia.TextoBusqueda))
                {
                    Pf.X = 10;
                    Pf.Y = PositionY += 25;
                    Sf.Alignment = StringAlignment.Near;
                    G.DrawString("IMPORTANTE:", new Font("Arial", 8, FontStyle.Bold), Brush, Pf, Sf);
                    this.AddMensaje(ref G, Ps, this.ResumenGarantia.TextoBusqueda.ToUpper(), new Font("Arial", 8), StringAlignment.Near, 10);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Métodos Auxiliares

        private void AddTitulos(ref Graphics g, PageSettings ps, string mensaje, Font fuente, StringAlignment sa, int px)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = px;
                pf.Y = PositionY;
                StringFormat sf = new StringFormat();
                sf.Alignment = sa;

                string cadena = "", palabra = "", lastcadena = "", lastpalabra = "";
                int i = 0;

                while (i < mensaje.Length)
                {
                    while (g.MeasureString(cadena, fuente).Width < (ps.PaperSize.Width - 20) && i < mensaje.Length)
                    {
                        while (mensaje[i] != ' ')
                        {
                            palabra += mensaje[i];
                            i++;
                            if (i >= mensaje.Length)
                                break;
                        }
                        palabra += ' ';
                        i++;
                        lastcadena = cadena;
                        lastpalabra = palabra;
                        cadena += palabra;
                        palabra = "";
                    }
                    if (i >= mensaje.Length)
                    {
                        g.DrawString(cadena, fuente, Brush, pf, sf);
                        pf.Y = PositionY += 18;
                    }
                    else
                    {
                        g.DrawString(lastcadena, fuente, Brush, pf, sf);
                        pf.Y = PositionY += 18;
                        cadena = lastpalabra;
                    }
                }
                //pf.Y = position_y += 5;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddTextCenter(string text, ref Graphics h, int max_x, int max_y)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = max_x / 2;
                pf.Y = PositionY += 15;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                h.DrawString(text, new Font("Arial", 8), Brush, pf, sf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddTextLeft(string text, ref Graphics h, int max_x, int max_y)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                int x = 10;
                pf.X = x;
                pf.Y = PositionY += 10;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                h.DrawString(text, new Font("Arial", 8), Brush, pf, sf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddTextRigth(string text, ref Graphics h, int max_x, int max_y)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = max_x - 13;
                pf.Y = PositionY += 10;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;
                h.DrawString(text, new Font("Arial", 8), Brush, pf, sf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddLetterSpace(char letra, ref Graphics h, int max_x, int may_y, Font fuente)
        {
            try
            {
                string cadena = "";
                while (h.MeasureString(cadena, fuente).Width < (max_x - 10))
                {
                    cadena += letra;
                }
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = 10;
                pf.Y = PositionY += 15;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                h.DrawString(cadena, fuente, Brush, pf, sf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddMensaje(ref Graphics g, PageSettings ps, string mensaje, Font fuente, StringAlignment sa, int px)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = px;
                pf.Y = PositionY += 15;
                StringFormat sf = new StringFormat();
                sf.Alignment = sa;

                string cadena = "", palabra = "", lastcadena = "", lastpalabra = "";
                int i = 0;

                while (i < mensaje.Length)
                {
                    while (g.MeasureString(cadena, fuente).Width < (ps.PaperSize.Width - 20) && i < mensaje.Length)
                    {
                        while (mensaje[i] != ' ')
                        {
                            palabra += mensaje[i];
                            i++;
                            if (i >= mensaje.Length || mensaje[i] == 0x000A)
                                break;
                        }
                        palabra += ' ';
                        lastcadena = cadena;
                        lastpalabra = palabra;
                        cadena += palabra;
                        palabra = "";
                        if (i < mensaje.Length)
                        {
                            if (mensaje[i] == 0x000A)
                            {
                                g.DrawString(cadena, fuente, Brush, pf, sf);
                                pf.Y = PositionY += 15;
                                lastcadena = "";
                                cadena = "";
                                palabra = "";
                                lastpalabra = "";
                            }
                        }
                        i++;
                    }
                    if (i >= mensaje.Length)
                    {
                        g.DrawString(cadena, fuente, Brush, pf, sf);
                        pf.Y = PositionY += 15;
                    }
                    else
                    {
                        g.DrawString(lastcadena, fuente, Brush, pf, sf);
                        pf.Y = PositionY += 15;
                        cadena = lastpalabra;
                    }
                }
                //pf.Y = PositionY += 5;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddMensajeTitle(ref Graphics g, PageSettings ps, string mensaje, Font fuente, StringAlignment sa, int px)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = px;
                pf.Y = PositionY;
                StringFormat sf = new StringFormat();
                sf.Alignment = sa;

                string cadena = "", palabra = "", lastcadena = "", lastpalabra = "";
                int i = 0;

                while (i < mensaje.Length)
                {
                    while (g.MeasureString(cadena, fuente).Width < (ps.PaperSize.Width - 20) && i < mensaje.Length)
                    {
                        while (mensaje[i] != ' ')
                        {
                            palabra += mensaje[i];
                            i++;
                            if (i >= mensaje.Length)
                                break;
                        }
                        palabra += ' ';
                        i++;
                        lastcadena = cadena;
                        lastpalabra = palabra;
                        cadena += palabra;
                        palabra = "";
                    }
                    if (i >= mensaje.Length)
                    {
                        g.DrawString(cadena, fuente, Brush, pf, sf);
                        pf.Y = PositionY += 15;
                    }
                    else
                    {
                        g.DrawString(lastcadena, fuente, Brush, pf, sf);
                        pf.Y = PositionY += 15;
                        cadena = lastpalabra;
                    }
                }
                //pf.Y = PositionY += 5;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddLogo(Image Logo, ref Graphics h, int max_x)
        {
            try
            {
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF Pf = new PointF();
                Pf.Y = PositionY += 5;
                Pf.X = (int)(max_x - Logo.Width) / 2;
                h.DrawImage(Logo, Pf);
                PositionY += (Logo.Height + 15);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion


    }
}

