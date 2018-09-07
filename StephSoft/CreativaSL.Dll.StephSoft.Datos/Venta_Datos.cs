using CreativaSL.Dll.StephSoft.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Datos
{
    public class Venta_Datos
    {
        public void InsertarNuevaVentaAbierta(Venta Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDCliente, Datos.IDCaja, Datos.IDSucursal, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "Ventas.spCSLDB_set_NuevaVentaAbierta", Parametros);
                while (Dr.Read())
                {
                    Datos.IDVenta = !Dr.IsDBNull(Dr.GetOrdinal("IDVenta")) ? Dr.GetString(Dr.GetOrdinal("IDVenta")) : string.Empty;
                    if (!string.IsNullOrEmpty(Datos.IDVenta))
                    {
                        Datos.IDCliente = !Dr.IsDBNull(Dr.GetOrdinal("IDCliente")) ? Dr.GetString(Dr.GetOrdinal("IDCliente")) : string.Empty;
                        Datos.IDEstatusVenta = !Dr.IsDBNull(Dr.GetOrdinal("IDEstatusVenta")) ? Dr.GetInt32(Dr.GetOrdinal("IDEstatusVenta")) : 0;
                        Datos.FolioVenta = !Dr.IsDBNull(Dr.GetOrdinal("FolioVenta")) ? Dr.GetString(Dr.GetOrdinal("FolioVenta")) : string.Empty;
                        Datos.NombreCliente = !Dr.IsDBNull(Dr.GetOrdinal("NombreCliente")) ? Dr.GetString(Dr.GetOrdinal("NombreCliente")) : string.Empty;
                        Datos.HoraInicio = !Dr.IsDBNull(Dr.GetOrdinal("HoraInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("HoraInicio")) : DateTime.Now;
                        Datos.TiempoTranscurridoSegundos = 0;
                        Datos.Subtotal = 0;
                        Datos.Descuento = 0;
                        Datos.Iva = 0;
                        Datos.Total = 0;
                        Datos.Completado = true;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //public void InsertarNuevoServicioAVenta(Servicio Datos)
        //{
        //    try
        //    {
        //        Datos.Completado = false;
        //        object[] Parametros = { Datos.IDVenta, Datos.IDServicio, Datos.IDEmpleado, Datos.IDSucursal, Datos.IDUsuario };
        //        SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_set_AgregarServicioAVenta", Parametros);
        //        while (Dr.Read())
        //        {
        //            Datos.Resultado = !Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? Dr.GetInt32(Dr.GetOrdinal("Resultado")) : 0;
        //            if (Datos.Resultado == 1)
        //            {
        //                Datos.IDServicio = !Dr.IsDBNull(Dr.GetOrdinal("IDServicio")) ? Dr.GetString(Dr.GetOrdinal("IDServicio")) : string.Empty;
        //                Datos.Clave = !Dr.IsDBNull(Dr.GetOrdinal("Clave")) ? Dr.GetString(Dr.GetOrdinal("Clave")) : string.Empty;
        //                Datos.NombreServicio = !Dr.IsDBNull(Dr.GetOrdinal("NombreServicio")) ? Dr.GetString(Dr.GetOrdinal("NombreServicio")) : string.Empty;
        //                Datos.NombreEmpleado = !Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? Dr.GetString(Dr.GetOrdinal("NombreEmpleado")) : string.Empty;
        //                Datos.IDEstatus = !Dr.IsDBNull(Dr.GetOrdinal("IDEstatus")) ? Dr.GetInt32(Dr.GetOrdinal("IDEstatus")) : 0;
        //                Datos.Estatus = !Dr.IsDBNull(Dr.GetOrdinal("Estatus")) ? Dr.GetString(Dr.GetOrdinal("Estatus")) : string.Empty;
        //                Datos.TiempoTranscurrido = !Dr.IsDBNull(Dr.GetOrdinal("Tiempo")) ? Dr.GetString(Dr.GetOrdinal("Tiempo")) : string.Empty; ;
        //                Datos.PrecioNormal = !Dr.IsDBNull(Dr.GetOrdinal("PrecioUnitario")) ? Dr.GetDecimal(Dr.GetOrdinal("PrecioUnitario")) : 0;
        //                Datos.CantidadVenta = !Dr.IsDBNull(Dr.GetOrdinal("Cantidad")) ? Dr.GetDecimal(Dr.GetOrdinal("Cantidad")) : 0;
        //                Datos.Subtotal = !Dr.IsDBNull(Dr.GetOrdinal("Subtotal")) ? Dr.GetDecimal(Dr.GetOrdinal("Subtotal")) : 0;
        //                Datos.Descuento = !Dr.IsDBNull(Dr.GetOrdinal("Descuento")) ? Dr.GetDecimal(Dr.GetOrdinal("Descuento")) : 0;
        //                Datos.Iva = !Dr.IsDBNull(Dr.GetOrdinal("Iva")) ? Dr.GetDecimal(Dr.GetOrdinal("Iva")) : 0;
        //                Datos.IvaUnitario = !Dr.IsDBNull(Dr.GetOrdinal("IvaUnitario")) ? Dr.GetDecimal(Dr.GetOrdinal("IvaUnitario")) : 0;
        //                Datos.Total = !Dr.IsDBNull(Dr.GetOrdinal("Total")) ? Dr.GetDecimal(Dr.GetOrdinal("Total")) : 0;
        //                Datos.Completado = true;
        //            }
        //            else
        //            {
        //                Datos.MensajeError = !Dr.IsDBNull(Dr.GetOrdinal("Mensaje")) ? Dr.GetString(Dr.GetOrdinal("Mensaje")) : string.Empty;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        
        public void ObtenerVentasXFecha(Venta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEstatusVenta, Datos.Actual, Datos.FechaVenta, Datos.IDSucursal  };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_get_TicketsXFechaXTab", Parametros);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
                this.ObtenerFechaHoraServidor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerServiciosXIDVenta(Venta Datos)
        {
            try
            {
                //DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ServiciosXIDVenta", Datos.IDVenta);

                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_get_ServiciosXIDVenta", Datos.IDVenta);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
                this.ObtenerFechaHoraServidor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerProductosXIDVentaServicio(VentaDetalle Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_get_PRoductosXIDVentaServicio", Datos.IDVentaServicio);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
                this.ObtenerFechaHoraServidor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void ObtenerUsosXIDVentaServicio(VentaDetalle Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_get_ClavesUsoXIDVentaServicio", Datos.IDVentaServicio);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoDetalle> LlenarComboClavesProduccion(VentaDetalle Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDVentaServicio, Datos.IDProducto };
                List<PedidoDetalle> Lista = new List<PedidoDetalle>();
                PedidoDetalle Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "Ventas.spCSLDB_get_ComboClavesXIDProductoVentaServicio", Parametros);
                while (Dr.Read())
                {
                    Item = new PedidoDetalle();
                    Item.IDAsignacion = Dr.GetString(Dr.GetOrdinal("IDAsignacion"));
                    Item.ClaveProduccion = Dr.GetString(Dr.GetOrdinal("ClaveProduccion"));
                    Item.EsEmpleado = Dr.GetBoolean(Dr.GetOrdinal("EsEmpleado"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarClaveAServicio(VentaDetalle Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDVentaServicio, Datos.IDProducto, Datos.IDClaveAsignacion, 
                                        Datos.ClaveEsEmpleado, Datos.CantidadVenta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_set_NuevaClaveServicio", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void QuitarClaveAServicio(VentaDetalle Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDClaveAsignacion, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_set_QuitarClaveProduccionServicio", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void AgregarServicioAVenta(VentaDetalle Datos)
        {
            try
            {
                Datos.Completado = false;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "Ventas.spCSLDB_set_NuevoServicioVenta",
                     new SqlParameter("@IDVenta", Datos.IDVenta),
                     new SqlParameter("@IDServicio", Datos.IDServicio),
                     new SqlParameter("@IDEmpleado", Datos.IDEmpleado),
                     new SqlParameter("@TablaClaves", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (Dr.Read())
                {
                    Datos.Resultado = !Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? Dr.GetInt32(Dr.GetOrdinal("Resultado")) : 0;
                    if (Datos.Resultado == 1)
                    {
                        //Datos.IDVentaDetalle = !Dr.IsDBNull(Dr.GetOrdinal("IDVentaDetalle")) ? Dr.GetString(Dr.GetOrdinal("IDVentaDetalle")) : string.Empty;
                        //Datos.IDServicio = !Dr.IsDBNull(Dr.GetOrdinal("IDServicio")) ? Dr.GetString(Dr.GetOrdinal("IDServicio")) : string.Empty;
                        //Datos.Clave = !Dr.IsDBNull(Dr.GetOrdinal("Clave")) ? Dr.GetString(Dr.GetOrdinal("Clave")) : string.Empty;
                        //Datos.NombreServicio = !Dr.IsDBNull(Dr.GetOrdinal("NombreServicio")) ? Dr.GetString(Dr.GetOrdinal("NombreServicio")) : string.Empty;
                        //Datos.NombreEmpleado = !Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? Dr.GetString(Dr.GetOrdinal("NombreEmpleado")) : string.Empty;
                        //Datos.IDEstatus = !Dr.IsDBNull(Dr.GetOrdinal("IDEstatus")) ? Dr.GetInt32(Dr.GetOrdinal("IDEstatus")) : 0;
                        //Datos.Estatus = !Dr.IsDBNull(Dr.GetOrdinal("Estatus")) ? Dr.GetString(Dr.GetOrdinal("Estatus")) : string.Empty;
                        //Datos.TiempoTranscurrido = !Dr.IsDBNull(Dr.GetOrdinal("Tiempo")) ? Dr.GetString(Dr.GetOrdinal("Tiempo")) : string.Empty; ;
                        //Datos.PrecioNormal = !Dr.IsDBNull(Dr.GetOrdinal("PrecioUnitario")) ? Dr.GetDecimal(Dr.GetOrdinal("PrecioUnitario")) : 0;
                        //Datos.CantidadVenta = !Dr.IsDBNull(Dr.GetOrdinal("Cantidad")) ? Dr.GetDecimal(Dr.GetOrdinal("Cantidad")) : 0;
                        //Datos.Subtotal = !Dr.IsDBNull(Dr.GetOrdinal("Subtotal")) ? Dr.GetDecimal(Dr.GetOrdinal("Subtotal")) : 0;
                        //Datos.Descuento = !Dr.IsDBNull(Dr.GetOrdinal("Descuento")) ? Dr.GetDecimal(Dr.GetOrdinal("Descuento")) : 0;
                        //Datos.Iva = !Dr.IsDBNull(Dr.GetOrdinal("Iva")) ? Dr.GetDecimal(Dr.GetOrdinal("Iva")) : 0;
                        //Datos.IvaUnitario = !Dr.IsDBNull(Dr.GetOrdinal("IvaUnitario")) ? Dr.GetDecimal(Dr.GetOrdinal("IvaUnitario")) : 0;
                        //Datos.Total = !Dr.IsDBNull(Dr.GetOrdinal("Total")) ? Dr.GetDecimal(Dr.GetOrdinal("Total")) : 0;
                        Datos.Completado = true;
                    }
                    //else
                    //{   
                    //    Datos.MensajeError = !Dr.IsDBNull(Dr.GetOrdinal("Mensaje")) ? Dr.GetString(Dr.GetOrdinal("Mensaje")) : string.Empty;
                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarProductoAServicio(VentaDetalle Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDVenta, Datos.IDVentaServicio, Datos.IDProducto, Datos.CantidadVenta, Datos.PrecioNormal, Datos.IDSucursal, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_set_NuevoProductoServicio", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerFechaHoraServidor()
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Comun.Conexion, "spCSLDB_get_HoraServidor");
                if (Result != null)
                {
                    DateTime FechaAux = DateTime.Now;
                    if (DateTime.TryParse(Result.ToString(), out FechaAux))
                    {
                        Comun.FechaActual = FechaAux;
                    }
                    else
                    {
                        Comun.FechaActual = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ConcluirServicio(VentaDetalle Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDVenta, Datos.IDVentaServicio, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_set_ConcluirServicioVenta", Parametros);
                if(Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if(Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void QuitarServicio(VentaDetalle Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDVenta, Datos.IDVentaServicio, Datos.IDUsuario, Datos.IDSucursal };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_set_QuitarServicioVenta", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDatosCobroXIDVenta(Cobro Datos)
        {
            try
            {
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_get_DatosCobroXIDVenta", Datos.IDVenta);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Datos.Completado = true;
                            Datos.IDCliente = Dr.GetString(Dr.GetOrdinal("IDCliente"));
                            Datos.IDTarjeta = Dr.GetString(Dr.GetOrdinal("IDTarjeta"));
                            Datos.Cliente = Dr.GetString(Dr.GetOrdinal("NombreCliente"));
                            Datos.IDTipoMonedero = Dr.GetInt32(Dr.GetOrdinal("IDTipoMonedero"));
                            Datos.NumTarjeta = Dr.GetString(Dr.GetOrdinal("NumTarjeta"));
                            Datos.Saldo = Dr.GetDecimal(Dr.GetOrdinal("Saldo"));
                            Datos.PuntosVenta = Dr.GetDecimal(Dr.GetOrdinal("PuntosVenta"));
                            Datos.Subtotal = Dr.GetDecimal(Dr.GetOrdinal("Subtotal"));
                            Datos.Descuento = Dr.GetDecimal(Dr.GetOrdinal("Descuento"));
                            Datos.Iva = Dr.GetDecimal(Dr.GetOrdinal("Iva"));
                            Datos.TotalAPagar = Dr.GetDecimal(Dr.GetOrdinal("TotalAPagar"));
                            Datos.FolioVale = Dr.GetString(Dr.GetOrdinal("FolioVale"));
                            Datos.IDVale = Dr.GetString(Dr.GetOrdinal("IDVale"));
                            Datos.DescCumpleaños = Dr.GetBoolean(Dr.GetOrdinal("DescCump"));
                            Datos.AplicaPromocion = Dr.GetBoolean(Dr.GetOrdinal("AplicaPromocion"));
                        }
                        Datos.TablaDatos = Ds.Tables[1];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cobro AplicarVale(Vales Datos)
        {
            try
            {
                Cobro Resultado = new Cobro();
                Resultado.Completado = false;
                object[] Parametros = { Datos.IDVenta, Datos.IDCliente, Datos.Folio, Datos.IDUsuario };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_get_ValidarVale", Parametros);
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                            if (Resultado.Resultado == 1)
                            {
                                Resultado.Completado = true;
                                Resultado.IDVenta = Datos.IDVenta;
                                Resultado.IDCliente = Dr.GetString(Dr.GetOrdinal("IDCliente"));
                                Resultado.IDTarjeta = Dr.GetString(Dr.GetOrdinal("IDTarjeta"));
                                Resultado.Cliente = Dr.GetString(Dr.GetOrdinal("NombreCliente"));
                                Resultado.IDTipoMonedero = Dr.GetInt32(Dr.GetOrdinal("IDTipoMonedero"));
                                Resultado.NumTarjeta = Dr.GetString(Dr.GetOrdinal("NumTarjeta"));
                                Resultado.Saldo = Dr.GetDecimal(Dr.GetOrdinal("Saldo"));
                                Resultado.PuntosVenta = Dr.GetDecimal(Dr.GetOrdinal("PuntosVenta"));
                                Resultado.Subtotal = Dr.GetDecimal(Dr.GetOrdinal("Subtotal"));
                                Resultado.Descuento = Dr.GetDecimal(Dr.GetOrdinal("Descuento"));
                                Resultado.Iva = Dr.GetDecimal(Dr.GetOrdinal("Iva"));
                                Resultado.TotalAPagar = Dr.GetDecimal(Dr.GetOrdinal("TotalAPagar"));
                                Resultado.FolioVale = Dr.GetString(Dr.GetOrdinal("FolioVale"));
                                Resultado.IDVale = Dr.GetString(Dr.GetOrdinal("IDVale"));
                                Resultado.DescCumpleaños = Dr.GetBoolean(Dr.GetOrdinal("DescCump"));
                                Resultado.AplicaPromocion = Dr.GetBoolean(Dr.GetOrdinal("AplicaPromocion"));
                            }
                        }
                    }
                    if (Ds.Tables.Count == 2)
                    {
                        Resultado.TablaDatos = Ds.Tables[1];
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Cobro RemoverVale(Vales Datos)
        {
            try
            {
                Cobro Resultado = new Cobro();
                Resultado.Completado = false;
                object[] Parametros = { Datos.IDVenta, Datos.IDCliente, Datos.IDVale, Datos.IDUsuario };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_set_RemoverValeVenta", Parametros);
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Resultado.Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                            if (Resultado.Resultado == 1)
                            {
                                Resultado.Completado = true;
                                Resultado.IDVenta = Datos.IDVenta;
                                Resultado.IDCliente = Dr.GetString(Dr.GetOrdinal("IDCliente"));
                                Resultado.IDTarjeta = Dr.GetString(Dr.GetOrdinal("IDTarjeta"));
                                Resultado.Cliente = Dr.GetString(Dr.GetOrdinal("NombreCliente"));
                                Resultado.IDTipoMonedero = Dr.GetInt32(Dr.GetOrdinal("IDTipoMonedero"));
                                Resultado.NumTarjeta = Dr.GetString(Dr.GetOrdinal("NumTarjeta"));
                                Resultado.Saldo = Dr.GetDecimal(Dr.GetOrdinal("Saldo"));
                                Resultado.PuntosVenta = Dr.GetDecimal(Dr.GetOrdinal("PuntosVenta"));
                                Resultado.Subtotal = Dr.GetDecimal(Dr.GetOrdinal("Subtotal"));
                                Resultado.Descuento = Dr.GetDecimal(Dr.GetOrdinal("Descuento"));
                                Resultado.Iva = Dr.GetDecimal(Dr.GetOrdinal("Iva"));
                                Resultado.TotalAPagar = Dr.GetDecimal(Dr.GetOrdinal("TotalAPagar"));
                                Resultado.FolioVale = Dr.GetString(Dr.GetOrdinal("FolioVale"));
                                Resultado.IDVale = Dr.GetString(Dr.GetOrdinal("IDVale"));
                            }
                        }
                    }
                    if (Ds.Tables.Count == 2)
                    {
                        Resultado.TablaDatos = Ds.Tables[1];
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void QuitarProductoServicio(VentaDetalle Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDVenta, Datos.IDVentaServicio, Datos.IDProductoXVentaServicio, 
                                          Datos.IDSucursal, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_set_QuitarProductoServicio", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TieneVale(Venta Datos)
        {
            try
            {
                bool Band = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_get_TieneValeXIDVenta", Datos.IDVenta);
                if (Result != null)
                {
                    Datos.Completado = true;
                    bool.TryParse(Result.ToString(), out Band);
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CobroVentaServicios(Cobro Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "Ventas.spCSLDB_set_PagoVentaAbierta",
                     new SqlParameter("@IDVenta", Datos.IDVenta),
                     new SqlParameter("@IDCajaXSucursal", Datos.IDCaja),
                     new SqlParameter("@IDCajero", Datos.IDCajero),
                     new SqlParameter("@Total", Datos.TotalAPagar),
                     new SqlParameter("@Comision", Datos.Comision),
                     new SqlParameter("@TotalPagar", Datos.TotalAPagar + Datos.Comision),
                     new SqlParameter("@Pago", Datos.Pago),
                     new SqlParameter("@Cambio", Datos.Cambio),
                     new SqlParameter("@RequiereFact", Datos.RequiereFactura),
                     new SqlParameter("@MonederoVenta", Datos.PuntosVenta),
                     new SqlParameter("@TablaFP", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CobroVentaServiciosCortesia(Cobro Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDVenta, Datos.IDCaja, Datos.IDCajero, Datos.TotalAPagar, Datos.Comision, Datos.TotalAPagar + Datos.Comision,
                                        Datos.Pago, Datos.Cambio, Datos.RequiereFactura, Datos.PuntosVenta, Datos.IDUsuarioAutoriza, Datos.IDUsuario};
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_set_PagoVentaAbiertaCortesia", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void InsertarNuevaVenta(Venta Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = {Datos.IDCaja, Datos.IDSucursal, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_set_NuevaVenta", Parametros);
                if (Result != null)
                {
                    if(!string.IsNullOrEmpty(Result.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDVenta = Result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VentaDetalle ObtenerProductoXClaveProducto(VentaDetalle Datos)
        {
            try
            {
                VentaDetalle DatosResult = new VentaDetalle();
                object [] Parametros = { Datos.IDVenta, Datos.Clave, (int)Datos.CantidadVenta, Datos.IDSucursal, Datos.IDUsuario };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_set_AgregarProductoXClave", Parametros);
                if (Ds != null)
                {
                    int Resultado = 0;
                    if (Ds.Tables.Count > 0)
                    {
                        //DataTable Aux = Ds.Tables[0];
                        int.TryParse(Ds.Tables[0].Rows[0][0].ToString(), out Resultado);
                        if (Resultado == 1)
                        {
                            Datos.Completado = true;
                            if (Ds.Tables.Count > 1)
                            {
                                DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                                while (Dr.Read())
                                {
                                    DatosResult.IDVentaDetalle = Dr.GetString(Dr.GetOrdinal("IDVentaDetalle"));
                                    DatosResult.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                                    DatosResult.Clave = Dr.GetString(Dr.GetOrdinal("Clave"));
                                    DatosResult.NombreProducto = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                                    DatosResult.PrecioNormal = Dr.GetDecimal(Dr.GetOrdinal("Precio"));
                                    DatosResult.CantidadVenta = Dr.GetDecimal(Dr.GetOrdinal("Cantidad"));
                                    DatosResult.Subtotal = Dr.GetDecimal(Dr.GetOrdinal("Subtotal"));
                                    DatosResult.Descuento = Dr.GetDecimal(Dr.GetOrdinal("Descuento"));
                                    DatosResult.Total = Dr.GetDecimal(Dr.GetOrdinal("Total"));
                                }
                            }
                        }
                        Datos.Resultado = Resultado;
                    }
                }
                return DatosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VentaDetalle ObtenerProductoXIDProducto(VentaDetalle Datos)
        {
            try
            {
                VentaDetalle DatosResult = new VentaDetalle();
                object[] Parametros = { Datos.IDVenta, Datos.IDProducto, (int)Datos.CantidadVenta, Datos.IDSucursal, Datos.IDUsuario };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_set_AgregarProductoXIDProducto", Parametros);
                if (Ds != null)
                {
                    int Resultado = 0;
                    if (Ds.Tables.Count > 0)
                    {
                        //DataTable Aux = Ds.Tables[0];
                        int.TryParse(Ds.Tables[0].Rows[0][0].ToString(), out Resultado);
                        if (Resultado == 1)
                        {
                            Datos.Completado = true;
                            if (Ds.Tables.Count > 1)
                            {
                                DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                                while (Dr.Read())
                                {
                                    DatosResult.IDVentaDetalle = Dr.GetString(Dr.GetOrdinal("IDVentaDetalle"));
                                    DatosResult.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                                    DatosResult.Clave = Dr.GetString(Dr.GetOrdinal("Clave"));
                                    DatosResult.NombreProducto = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                                    DatosResult.PrecioNormal = Dr.GetDecimal(Dr.GetOrdinal("Precio"));
                                    DatosResult.CantidadVenta = Dr.GetDecimal(Dr.GetOrdinal("Cantidad"));
                                    DatosResult.Subtotal = Dr.GetDecimal(Dr.GetOrdinal("Subtotal"));
                                    DatosResult.Descuento = Dr.GetDecimal(Dr.GetOrdinal("Descuento"));
                                    DatosResult.Total = Dr.GetDecimal(Dr.GetOrdinal("Total"));
                                }
                            }
                        }
                        Datos.Resultado = Resultado;
                    }
                }
                return DatosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPuntosVenta(Venta Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_get_MonederoVenta", Datos.IDVenta, Datos.IDCliente);
                if (Result != null)
                {
                    decimal Resultado = 0;
                    decimal.TryParse(Result.ToString(), out Resultado);
                    Datos.Completado = true;
                    Datos.PuntosObtenidos = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void CobroVenta(Cobro Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "Ventas.spCSLDB_set_PagoVenta",
                     new SqlParameter("@IDVenta", Datos.IDVenta),
                     new SqlParameter("@IDCliente", Datos.IDCliente),
                     new SqlParameter("@IDCajaXSucursal", Datos.IDCaja),
                     new SqlParameter("@ClaveEmpleado", Datos.CodigoEmpleado),
                     new SqlParameter("@Total", Datos.TotalAPagar),
                     new SqlParameter("@Comision", Datos.Comision),
                     new SqlParameter("@TotalPagar", Datos.TotalAPagar + Datos.Comision),
                     new SqlParameter("@Pago", Datos.Pago),
                     new SqlParameter("@Cambio", Datos.Cambio),
                     new SqlParameter("@RequiereFact", Datos.RequiereFactura),
                     new SqlParameter("@MonederoVenta", Datos.PuntosVenta),
                     new SqlParameter("@IDSucursal", Datos.IDSucursal),
                     new SqlParameter("@TablaFP", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void QuitarProductoVenta(VentaDetalle Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_set_QuitarProductoVenta", Datos.IDVenta, Datos.IDVentaDetalle, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VentaDetalle CambiarCantidadVenta(VentaDetalle Datos)
        {
            try
            {
                VentaDetalle DatosResult = new VentaDetalle();
                object[] Parametros = { Datos.IDVenta, Datos.IDVentaDetalle, Datos.IDProducto, (int)Datos.CantidadVenta, Datos.IDSucursal, Datos.IDUsuario };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_set_ActualizarCantVentaXIDProducto", Parametros);
                if (Ds != null)
                {
                    int Resultado = 0;
                    if (Ds.Tables.Count > 0)
                    {
                        //DataTable Aux = Ds.Tables[0];
                        int.TryParse(Ds.Tables[0].Rows[0][0].ToString(), out Resultado);
                        if (Resultado == 1)
                        {
                            Datos.Completado = true;
                            if (Ds.Tables.Count > 1)
                            {
                                DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                                while (Dr.Read())
                                {
                                    DatosResult.IDVentaDetalle = Dr.GetString(Dr.GetOrdinal("IDVentaDetalle"));
                                    DatosResult.IDProducto = Dr.GetString(Dr.GetOrdinal("IDProducto"));
                                    DatosResult.Clave = Dr.GetString(Dr.GetOrdinal("Clave"));
                                    DatosResult.NombreProducto = Dr.GetString(Dr.GetOrdinal("NombreProducto"));
                                    DatosResult.PrecioNormal = Dr.GetDecimal(Dr.GetOrdinal("Precio"));
                                    DatosResult.CantidadVenta = Dr.GetDecimal(Dr.GetOrdinal("Cantidad"));
                                    DatosResult.Subtotal = Dr.GetDecimal(Dr.GetOrdinal("Subtotal"));
                                    DatosResult.Descuento = Dr.GetDecimal(Dr.GetOrdinal("Descuento"));
                                    DatosResult.Total = Dr.GetDecimal(Dr.GetOrdinal("Total"));
                                }
                            }
                        }
                        Datos.Resultado = Resultado;
                    }
                }
                return DatosResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void QuitarVenta(Venta Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Ventas.spCSLDB_set_EliminarVentaDirecta", Datos.IDVenta, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerVentasXFolio(Venta Datos)
        {
            try
            {
                object[] Parametros = { Datos.FolioVenta, Datos.IDSucursal };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_VentasXFolioVenta", Parametros);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.TablaDatos = Ds.Tables[0];
                        Datos.Completado = true;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void BusquedaVentasGarantia(Venta Datos)
        {
            try
            {
                object[] Parametros = { Datos.Band, Datos.FolioVenta };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_get_BusqVentasGarantia", Parametros);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.TablaDatos = Ds.Tables[0];
                        Datos.Completado = true;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BusquedaVentasTicket(Venta Datos)
        {
            try
            {
                object[] Parametros = { Datos.Band, Datos.FolioVenta };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_get_BusqVentasTicket", Parametros);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.TablaDatos = Ds.Tables[0];
                        Datos.Completado = true;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleVenta(Venta Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "Ventas.spCSLDB_get_DetalleVenta", Datos.IDVenta);
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<MotivoCanc> ObtenerComboMotivoCanc(MotivoCanc Datos)
        {
            try
            {
                List<MotivoCanc> Lista = new List<MotivoCanc>();
                MotivoCanc Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboMotivoCanc", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new MotivoCanc();
                    Item.IDMotivo = Dr.GetInt32(Dr.GetOrdinal("IDMotivo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.RequiereDatos = Dr.GetBoolean(Dr.GetOrdinal("RequiereDatos"));
                    Lista.Add(Item);
                }
                Dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CancelarVenta(Venta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDVenta, Datos.IDMotivoCan, Datos.ComentariosCanc, Datos.MontoPenalizacionCanc, Datos.IDSucursal, Datos.IDCaja, Datos.IDUsuario };
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_CancelarTicketVenta", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Producto> ObtenerPromocionesDelDia(bool IncluirSelect, string Conexion, string IDSucursal)
        {
            try
            {
                List<Producto> Promociones = new List<Producto>();
                Producto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Ventas.spCSLDB_get_PromocionesXSucursal", IncluirSelect, IDSucursal);
                while(Dr.Read())
                {
                    Item = new Producto();
                    Item.IDPromocion = !Dr.IsDBNull(Dr.GetOrdinal("IDPromocion")) ? Dr.GetInt32(Dr.GetOrdinal("IDPromocion")) : -1;
                    Item.NombreProducto = !Dr.IsDBNull(Dr.GetOrdinal("NombreProducto")) ? Dr.GetString(Dr.GetOrdinal("NombreProducto")) : string.Empty;
                    Promociones.Add(Item);
                }
                Dr.Close();
                return Promociones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool AgregarPromocionAVenta(PromocionVenta Datos, string Conexion, string IDSucursal, string IDUsuario)
        {
            try
            {
                int Resultado = 0;
                object Result = SqlHelper.ExecuteScalar(Conexion, CommandType.StoredProcedure, "Ventas.spCSLDB_set_AgregarPromocionAVenta",
                    new SqlParameter("@IDPromocion", Datos.IDPromocion),
                    new SqlParameter("@IDVenta", Datos.IDVenta),
                    new SqlParameter("@TablaEmpleados", Datos.TablaDatos),
                    new SqlParameter("@IDSucursal", IDSucursal),
                    new SqlParameter("@IDUsuario", IDUsuario));
                if(Result != null)
                {
                    if(int.TryParse(Result.ToString(), out Resultado))
                    {
                        return Resultado == 1;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool IniciarServicio(VentaDetalle Datos, string Conexion, string IDUsuario)
        {
            try
            {
                int Resultado = 0;
                object Result = SqlHelper.ExecuteScalar(Conexion, CommandType.StoredProcedure, "Ventas.spCSLDB_set_IniciarServicio",
                    new SqlParameter("@IDVentaServicio", Datos.IDVentaServicio),
                    new SqlParameter("@TablaClaves", Datos.TablaDatos),
                    new SqlParameter("@IDUsuario", IDUsuario)
                    );
                if (Result != null)
                {
                    if (int.TryParse(Result.ToString(), out Resultado))
                    {
                        return Resultado == 1;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Venta AplicarDescuentoCumpleaños(string Conexion, string IDVenta, string IDCliente, string IDSucursal, string IDUsuario)
        {
            try
            {
                Venta Resultado = new Venta();
                object[] Parametros = { IDVenta, IDCliente, IDSucursal, IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "Ventas.spCSLDB_set_DescuentoCumple", Parametros);
                while(Dr.Read())
                {
                    Resultado.Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado.Resultado == -4)
                    {
                        Resultado.FechaVenta = Dr.GetDateTime(Dr.GetOrdinal("fechaServicio"));
                        Resultado.NombreSucursal = Dr.GetString(Dr.GetOrdinal("nombreSucursal"));
                    }
                }
                Dr.Close();
                return Resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public int RemoverDescuentoCumpleaños(string Conexion, string IDVenta, string IDUsuario)
        {
            try
            {
                object[] Parametros = { IDVenta, IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Conexion, "Ventas.spCSLDB_set_RemoverDescuentoCumple", Parametros);
                int Resultado = 0;
                if (Result != null)
                {
                    int.TryParse(Result.ToString(), out Resultado);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
