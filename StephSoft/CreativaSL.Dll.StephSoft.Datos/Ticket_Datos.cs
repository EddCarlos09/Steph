using CreativaSL.Dll.StephSoft.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Datos
{
    public class Ticket_Datos
    {
        public void ObtenerDetalleVenta(Venta Datos)
        {
            try
            {
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ResumenVenta", Datos.IDVenta);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 4)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Datos.Completado = true;
                            Datos.NombreCliente = Dr.GetString(Dr.GetOrdinal("NombreCliente"));
                            Datos.Saldo = Dr.GetDecimal(Dr.GetOrdinal("Saldo"));
                            Datos.PuntosVenta = Dr.GetDecimal(Dr.GetOrdinal("PuntosVenta"));
                            Datos.Subtotal = Dr.GetDecimal(Dr.GetOrdinal("Subtotal"));
                            Datos.Descuento = Dr.GetDecimal(Dr.GetOrdinal("Descuento"));
                            Datos.Iva = Dr.GetDecimal(Dr.GetOrdinal("Iva"));
                            Datos.Total = Dr.GetDecimal(Dr.GetOrdinal("Total"));
                            Datos.CodigoVale = Dr.GetString(Dr.GetOrdinal("FolioVale"));
                            Datos.FolioVenta = Dr.GetString(Dr.GetOrdinal("FolioVenta"));
                            Datos.TotalPago = Dr.GetDecimal(Dr.GetOrdinal("Pago"));
                            Datos.TotalCambio = Dr.GetDecimal(Dr.GetOrdinal("Cambio"));
                            Datos.Comision = Dr.GetDecimal(Dr.GetOrdinal("Comision"));
                            Datos.FechaHoraSistema = Dr.GetDateTime(Dr.GetOrdinal("FechaSistema"));
                            Datos.IDTipoVenta = Dr.GetInt32(Dr.GetOrdinal("IDTipoVenta"));
                            Datos.TextoVenta = Dr.GetString(Dr.GetOrdinal("TextoVenta"));
                        }
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        DataTable aux = Ds.Tables[1];
                        List<VentaDetalle> Lista = new List<VentaDetalle>();
                        VentaDetalle Item;
                        while (Dr2.Read())
                        {
                            Item = new VentaDetalle();
                            Item.Clave = Dr2.GetString(Dr2.GetOrdinal("Clave"));
                            Item.NombreProducto = Dr2.GetString(Dr2.GetOrdinal("NombreProducto"));
                            Item.CantidadVenta = Dr2.GetDecimal(Dr2.GetOrdinal("Cantidad"));
                            Item.PrecioNormal = Dr2.GetDecimal(Dr2.GetOrdinal("Precio"));
                            Item.Subtotal = Dr2.GetDecimal(Dr2.GetOrdinal("Subtotal"));
                            Item.Descuento = Dr2.GetDecimal(Dr2.GetOrdinal("Descuento"));
                            Item.Total = Dr2.GetDecimal(Dr2.GetOrdinal("Total"));
                            Lista.Add(Item);
                        }
                        Datos.ListaDetalle = Lista;

                        DataTableReader Dr3 = Ds.Tables[2].CreateDataReader();
                        List<Producto> Lista02 = new List<Producto>();
                        Producto Item02;
                        while (Dr3.Read())
                        {
                            Item02 = new Producto();
                            Item02.Clave = Dr3.GetString(Dr3.GetOrdinal("Codigo"));
                            Item02.NombreProducto = Dr3.GetString(Dr3.GetOrdinal("Producto"));
                            Lista02.Add(Item02);
                        }
                        Datos.ListaProductos = Lista02;

                        DataTableReader Dr4 = Ds.Tables[3].CreateDataReader();
                        List<FormaPago> Lista03 = new List<FormaPago>();
                        FormaPago Item03;
                        while (Dr4.Read())
                        {
                            Item03 = new FormaPago();
                            Item03.IDFormaPago = Dr4.GetInt32(Dr4.GetOrdinal("IDFormaPago"));
                            Item03.Descripcion = Dr4.GetString(Dr4.GetOrdinal("FormaPago"));
                            Item03.MontoTotal = Dr4.GetDecimal(Dr4.GetOrdinal("MontoTotal"));
                            Lista03.Add(Item03);
                        }
                        Datos.ListaFormasPago = Lista03;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
