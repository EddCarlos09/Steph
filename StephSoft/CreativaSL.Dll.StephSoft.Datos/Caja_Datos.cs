using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Datos;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSL.Dll.StephSoft.Datos
{
    public class Caja_Datos
    {

        public void AgregarDeposito(DepositoRetiro deposito)
        {
            try
            {
                if (SqlHelper.ExecuteNonQuery(deposito.Conexion, "spCSLDB_abc_Depositos", deposito.Opcion, deposito.IDDepositoRetiro, deposito.IDCaja, deposito.IDUsuario, deposito.Monto, deposito.Motivo, deposito.IDSucursal) <= 0)
                {
                    deposito.Validador = false;
                }
                else
                {
                    deposito.Validador = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarRetiro(DepositoRetiro retiro)
        {
            try
            {
                if (SqlHelper.ExecuteNonQuery(retiro.Conexion, "spCSLDB_abc_Retiros", retiro.Opcion, retiro.IDDepositoRetiro, retiro.IDCaja, retiro.IDUsuario, retiro.IDTipoDepositoRetiro, retiro.Monto, retiro.Motivo, retiro.IDSucursal) <= 0)
                {
                    retiro.Validador = false;
                }
                else
                {
                    retiro.Validador = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AsignarCajaMac(Caja Datos)
        {
            try
            {
                Datos.Completado = false;
                object [] Parametros = { Datos.Opcion, Datos.IDCajaCat, Datos.Mac, Datos.NombreCaja, Datos.IDSucursal };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_CajaMac", Parametros);
                if (Resultado != null)
                {
                    int Result = 0;
                    if (int.TryParse(Resultado.ToString(), out Result))
                    {
                        Datos.Resultado = Result;
                        if (Datos.Resultado >= 1)
                        {
                            Datos.Completado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarAperturaCaja(Caja Datos)
        {
            try
            {
                object [] Parametros = { Datos.IDCaja, Datos.IDCajaCat,
                                       Datos.IDSucursal, Datos.Apertura,
                                       Datos.IDUsuario};
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_AperturaCaja", Parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int Aux = 0;
                    if (int.TryParse(Resultado.ToString(), out Aux))
                    {
                        if(Aux > 0)
                            Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarCierreCaja(Caja Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCaja, Datos.IDCajaCat,
                                       Datos.IDSucursal, Datos.Cierre,
                                       Datos.IDUsuario};
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_CierreCaja", Parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int Aux = 0;
                    if (int.TryParse(Resultado.ToString(), out Aux))
                    {
                        if (Aux > 0)
                            Datos.Completado = true;
                    }
                    Datos.Resultado = Aux;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Caja> LlenarComboCatCajas(Caja Datos)
        {
            try
            {
                List<Caja> Lista = new List<Caja>();
                Caja Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatCajas", Datos.Opcion);
                while (Dr.Read())
                {
                    Item = new Caja();
                    Item.IDCajaCat = Dr.IsDBNull(Dr.GetOrdinal("IDCajaCat")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDCajaCat"));
                    Item.CajaCat = Dr.IsDBNull(Dr.GetOrdinal("CajaCat")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("CajaCat"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Caja obtenerDatosConfiguracionLocal(Caja datos)
        {
            try
            {
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.Conexion, "spCSLDB_get_CatCajaxMAC", datos.Mac);
                datos.Mac = "";
                while (dr.Read())
                {
                    datos.Mac = dr["MacAddress"].ToString();
                    datos.NombreCaja = dr["NombreCaja"].ToString();
                    datos.NombreImpresora = dr["NombreImpresora"].ToString();
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void actualizarConfiguracionLocal(Caja Datos)
        {
            try
            {
                object[] Parametros = { Datos.NombreCaja , Datos.Mac,
                                       Datos.NombreImpresora, Datos.IDUsuario};
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_ConfiguracionLocal", Parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int Aux = 0;
                    if (int.TryParse(Resultado.ToString(), out Aux))
                    {
                        if (Aux > 0)
                            Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerReporteTicketCaja(Caja Datos)
        {
            try
            {
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_RptTicketCaja", Datos.IDCaja, Datos.IDUsuario);
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        int Resultado = 0;
                        int.TryParse(Ds.Tables[0].Rows[0][0].ToString(), out Resultado);
                        if (Resultado == 1)
                        {
                            Datos.Completado = true;
                            if (Ds.Tables.Count == 5)
                            {
                                DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                                while (Dr.Read())
                                {
                                    Datos.FolioTicket = Dr.GetInt32(Dr.GetOrdinal("Folio"));
                                    Datos.FechaTicket = Dr.GetDateTime(Dr.GetOrdinal("FechaHora"));
                                }

                                DataTableReader Dr2 = Ds.Tables[2].CreateDataReader();
                                List<FormaPago> ListaFP = new List<FormaPago>();
                                FormaPago Item01;
                                while (Dr2.Read())
                                {
                                    Item01 = new FormaPago();
                                    Item01.Descripcion = Dr2.GetString(Dr2.GetOrdinal("FormaPago"));
                                    Item01.MontoTotal = Dr2.GetDecimal(Dr2.GetOrdinal("MontoTotal"));
                                    ListaFP.Add(Item01);
                                }
                                Datos.ListaFormasPago = ListaFP;

                                DataTableReader Dr3 = Ds.Tables[3].CreateDataReader();
                                List<Usuario> ListaUser = new List<Usuario>();
                                Usuario Item02;
                                while (Dr3.Read())
                                {
                                    Item02 = new Usuario();
                                    Item02.IDEmpleado = Dr3.GetString(Dr3.GetOrdinal("IDEmpleado"));
                                    Item02.Nombre = Dr3.GetString(Dr3.GetOrdinal("Nombre"));
                                    Item02.TotalVentas = Dr3.GetDecimal(Dr3.GetOrdinal("Total"));
                                    ListaUser.Add(Item02);
                                }
                                Datos.ListaEmpleados = ListaUser;

                                DataTableReader Dr4 = Ds.Tables[4].CreateDataReader();
                                List<VentaDetalle> ListaVD = new List<VentaDetalle>();
                                VentaDetalle Item03;
                                while (Dr4.Read())
                                {
                                    Item03 = new VentaDetalle();
                                    Item03.IDEmpleado = Dr4.GetString(Dr4.GetOrdinal("IDEmpleado"));
                                    Item03.Descripcion = Dr4.GetString(Dr4.GetOrdinal("Servicio"));
                                    Item03.CantidadVenta = Dr4.GetDecimal(Dr4.GetOrdinal("Cantidad"));
                                    Item03.Total = Dr4.GetDecimal(Dr4.GetOrdinal("Monto"));
                                    ListaVD.Add(Item03);
                                }
                                Datos.ListaServicios = ListaVD;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerReporteResumenCaja(Caja Datos)
        {
            try
            {
                Datos.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_RptResumenCaja", Datos.IDCaja);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Datos.Cajero = Dr.GetString(Dr.GetOrdinal("Cajero"));
                            Datos.FechaHoraApertura = Dr.GetDateTime(Dr.GetOrdinal("FechaApertura")).ToString("dd:MM:yyyy HH:mm:ss");
                            Datos.FechaHoraCierre = Dr.IsDBNull(Dr.GetOrdinal("FechaCierre")) ? string.Empty : Dr.GetDateTime(Dr.GetOrdinal("FechaCierre")).ToString("dd:MM:yyyy HH:mm:ss");
                            Datos.TotalDepositos = Dr.GetDecimal(Dr.GetOrdinal("TotalDepositos"));
                            Datos.TotalRetirosCajaLlena = Dr.GetDecimal(Dr.GetOrdinal("TotalRetiros"));
                            Datos.TotalVentas = Dr.GetDecimal(Dr.GetOrdinal("TotalCobros"));
                            Datos.TotalCancelaciones = Dr.GetDecimal(Dr.GetOrdinal("TotalCancelaciones"));
                            Datos.Penalizaciones = Dr.GetDecimal(Dr.GetOrdinal("TotalPenalizaciones"));
                            Datos.Saldo = Dr.GetDecimal(Dr.GetOrdinal("TotalCaja"));
                            Datos.Cierre = Dr.GetDecimal(Dr.GetOrdinal("Cierre"));
                            Datos.Apertura = Dr.GetDecimal(Dr.GetOrdinal("Apertura"));
                        }

                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        List<FormaPago> ListaFP = new List<FormaPago>();
                        FormaPago Item01;
                        while (Dr2.Read())
                        {
                            Item01 = new FormaPago();
                            Item01.Descripcion = Dr2.GetString(Dr2.GetOrdinal("FormaPago"));
                            Item01.MontoTotal = Dr2.GetDecimal(Dr2.GetOrdinal("Monto"));
                            ListaFP.Add(Item01);
                        }
                        Datos.ListaFormasPago = ListaFP;

                        Datos.Completado = true;
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
