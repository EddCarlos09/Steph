﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephSoft.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace CreativaSL.Dll.StephSoft.Datos
{
    public class Cita_Datos
    {

        public void CancelarCita(Cita Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDCita, Datos.MotivoCancelacion, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_CancelarCita", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    Datos.Completado = true;
                    Datos.Opcion = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ConcluirCita(Cita Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDCita, Datos.IDEmpleadoAtendio, Datos.Comentarios, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_ConcluirCita", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    Datos.Completado = true;
                    Datos.Opcion = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarNuevaCita(Cita Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCliente, Datos.IDSucursal, Datos.IDEmpleado, Datos.IDServicio,
                                         Datos.IDHorario, Datos.Periodos, Datos.Observaciones, Datos.FechaCita, Datos.IDUsuario};
                Datos.Completado = false;
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_alta_Citas", Parametros);
                if (Resultado != null)
                {
                    int AuxRes = 0;
                    int.TryParse(Resultado.ToString(), out AuxRes);
                    Datos.Completado = true;
                    Datos.Opcion = AuxRes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCitasBusqueda(Cita Datos)
        {
            try
            {
                object[] Parametros = { Datos.BusqSucursal, Datos.BusqFechaCita, Datos.BusqCliente,
                                        Datos.IDSucursal, Datos.FechaCita, Datos.NombreCliente};
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CitasBusqueda", Parametros);
                Datos.TablaDatos = new DataTable();
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCitasPendientesDiaActual(Cita Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CitasPendientesDelDia");
                Datos.TablaDatos = new DataTable();
                if (Ds != null)
                    if (Ds.Tables.Count == 1)
                        Datos.TablaDatos = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cita> ObtenerHorarioEmpleado(Cita Datos)
        {
            try
            {
                List<Cita> Lista = new List<Cita>();
                Cita Item;
                object[] Parametros = { Datos.IDSucursal, Datos.IDEmpleado, Datos.FechaCita };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_HorariosParaCita", Parametros);
                while (Dr.Read())
                {
                    Item = new Cita();
                    Item.IDHorario = Dr.IsDBNull(Dr.GetOrdinal("IDHorario")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDHorario"));
                    Item.HoraInicio = Dr.IsDBNull(Dr.GetOrdinal("HoraInicio")) ? DateTime.Today.TimeOfDay : Dr.GetTimeSpan(Dr.GetOrdinal("HoraInicio"));
                    Item.HoraFin = Dr.IsDBNull(Dr.GetOrdinal("HoraFin")) ? DateTime.Today.TimeOfDay : Dr.GetTimeSpan(Dr.GetOrdinal("HoraFin"));
                    Item.HorarioLibre = Dr.IsDBNull(Dr.GetOrdinal("HoraLibre")) ? false : Dr.GetBoolean(Dr.GetOrdinal("HoraLibre"));
                    Lista.Add(Item);
                }
                return Lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cita> ObtenerCitasPorSucursal(Cita Datos)
        {
            try
            {
                List<Cita> Lista = new List<Cita>();
                Cita Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CitasXSucursal", Datos.IDSucursal, false, Datos.FechaCita);
                while (Dr.Read())
                {
                    Item = new Cita();
                    Item.HoraInicio = Dr.GetTimeSpan(Dr.GetOrdinal("HoraInicio"));
                    Item.HoraFin = Dr.GetTimeSpan(Dr.GetOrdinal("HoraFin"));
                    Item.HoraCita = Item.HoraInicio.ToString(@"hh\:mm") + " - " + Item.HoraFin.ToString(@"hh\:mm");
                    Item.NombreEmpleado = Dr.GetString(Dr.GetOrdinal("Empleado")).ToUpper();
                    Item.IDServicio = Dr.GetString(Dr.GetOrdinal("Servicio"));
                    Item.NombreCliente = Dr.GetString(Dr.GetOrdinal("Cliente"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cita> ObtenerCitasPorSucursalXFechas(string Conexion, string IDSucursal, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                List<Cita> Lista = new List<Cita>();
                Cita Item;
                object[] Parametros = { IDSucursal, FechaInicio, FechaFin };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "spCSLDB_get_CitasXSucursalFechas", IDSucursal, FechaInicio, FechaFin);
                while (Dr.Read())
                {
                    Item = new Cita();
                    Item.FechaCita = !Dr.IsDBNull(Dr.GetOrdinal("Fecha")) ? Dr.GetDateTime(Dr.GetOrdinal("Fecha")) : DateTime.MinValue;
                    Item.HoraInicio = !Dr.IsDBNull(Dr.GetOrdinal("HoraInicio")) ? Dr.GetTimeSpan(Dr.GetOrdinal("HoraInicio")) : TimeSpan.MinValue;
                    Item.HoraFin = !Dr.IsDBNull(Dr.GetOrdinal("HoraFin")) ? Dr.GetTimeSpan(Dr.GetOrdinal("HoraFin")) : TimeSpan.MinValue;
                    Item.HoraCita = Item.HoraInicio.ToString(@"hh\:mm") + " - " + Item.HoraFin.ToString(@"hh\:mm");
                    Item.NombreEmpleado = !Dr.IsDBNull(Dr.GetOrdinal("Empleado")) ? Dr.GetString(Dr.GetOrdinal("Empleado")).ToUpper() : string.Empty;
                    Item.IDServicio = !Dr.IsDBNull(Dr.GetOrdinal("Servicio")) ? Dr.GetString(Dr.GetOrdinal("Servicio")).ToUpper() : string.Empty;
                    Item.NombreCliente = !Dr.IsDBNull(Dr.GetOrdinal("Cliente")) ? Dr.GetString(Dr.GetOrdinal("Cliente")).ToUpper() : string.Empty;
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cita ObtenerDatosCitaDetalle(Cita Datos)
        {
            try
            {
                Cita DatosGuardados = new Cita();
                DatosGuardados.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_DetalleCitaXID", Datos.IDCita);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        if (Ds.Tables[0] != null)
                        {
                            DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                            while (Dr.Read())
                            {
                                DatosGuardados.IDCita = Datos.IDCita;
                                DatosGuardados.NombreCliente = !Dr.IsDBNull(Dr.GetOrdinal("Cliente")) ? Dr.GetString(Dr.GetOrdinal("Cliente")) : string.Empty;
                                DatosGuardados.NombreSucursal = !Dr.IsDBNull(Dr.GetOrdinal("Sucursal")) ? Dr.GetString(Dr.GetOrdinal("Sucursal")) : string.Empty;
                                DatosGuardados.NombreEmpleado = !Dr.IsDBNull(Dr.GetOrdinal("Empleado")) ? Dr.GetString(Dr.GetOrdinal("Empleado")) : string.Empty;
                                DatosGuardados.FechaCita = !Dr.IsDBNull(Dr.GetOrdinal("FechaCita")) ? Dr.GetDateTime(Dr.GetOrdinal("Fechacita")) : DateTime.Today;
                                DatosGuardados.HoraCita = !Dr.IsDBNull(Dr.GetOrdinal("HoraCita")) ? Dr.GetString(Dr.GetOrdinal("HoraCita")) : string.Empty;
                                DatosGuardados.EstatusCita = !Dr.IsDBNull(Dr.GetOrdinal("Estatus")) ? Dr.GetString(Dr.GetOrdinal("Estatus")) : string.Empty;
                                DatosGuardados.Observaciones = !Dr.IsDBNull(Dr.GetOrdinal("Observaciones")) ? Dr.GetString(Dr.GetOrdinal("Observaciones")) : string.Empty;
                                DatosGuardados.EmpleadoCancela = !Dr.IsDBNull(Dr.GetOrdinal("EmpleadoCancela")) ? Dr.GetString(Dr.GetOrdinal("EmpleadoCancela")) : string.Empty;
                                DatosGuardados.FechaHoraCancelacion = !Dr.IsDBNull(Dr.GetOrdinal("FechaCancelacion")) ? Dr.GetString(Dr.GetOrdinal("FechaCancelacion")) : string.Empty;
                                DatosGuardados.MotivoCancelacion = !Dr.IsDBNull(Dr.GetOrdinal("MotivoCancelacion")) ? Dr.GetString(Dr.GetOrdinal("MotivoCancelacion")) : string.Empty;
                                DatosGuardados.EmpleadoAtendio = !Dr.IsDBNull(Dr.GetOrdinal("EmpleadoAtiende")) ? Dr.GetString(Dr.GetOrdinal("EmpleadoAtiende")) : string.Empty;
                                DatosGuardados.FechaHoraAtencion = !Dr.IsDBNull(Dr.GetOrdinal("FechaAtedio")) ? Dr.GetString(Dr.GetOrdinal("FechaAtedio")) : string.Empty;
                                DatosGuardados.Comentarios = !Dr.IsDBNull(Dr.GetOrdinal("ComentariosAtencion")) ? Dr.GetString(Dr.GetOrdinal("ComentariosAtencion")) : string.Empty;
                            }
                        }
                        DatosGuardados.Completado = true;
                    }
                }
                return DatosGuardados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
