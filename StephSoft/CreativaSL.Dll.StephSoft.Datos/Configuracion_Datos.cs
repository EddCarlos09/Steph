using CreativaSL.Dll.StephSoft.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Datos
{
    public class Configuracion_Datos
    {
        public Configuracion ObtenerDatosConfiguracion(string Conexion)
        {
            try
            {
                Configuracion Datos = new Configuracion();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "spCSLDB_get_Configuracion");
                while (Dr.Read())
                {
                    Datos.Completado = true;
                    Datos.RazonSocial = Dr.IsDBNull(Dr.GetOrdinal("RazonSocial")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RazonSocial"));
                    Datos.NombreComercial = Dr.IsDBNull(Dr.GetOrdinal("NombreComercial")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreComercial"));
                    Datos.Eslogan = Dr.IsDBNull(Dr.GetOrdinal("Eslogan")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Eslogan"));
                    Datos.RFC = Dr.IsDBNull(Dr.GetOrdinal("RFC")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RFC"));
                    Datos.Representante = Dr.IsDBNull(Dr.GetOrdinal("RepresentanteLegal")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("RepresentanteLegal"));
                    Datos.UrlLogo = Dr.IsDBNull(Dr.GetOrdinal("UrlLogo")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("UrlLogo"));
                    Datos.PorcentajeIva = Dr.IsDBNull(Dr.GetOrdinal("PorcentajeIva")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("PorcentajeIva"));
                    Datos.BandFecha01 = Dr.IsDBNull(Dr.GetOrdinal("BandFechaCorte01")) ? false : Dr.GetBoolean(Dr.GetOrdinal("BandFechaCorte01"));
                    Datos.BandFecha02 = Dr.IsDBNull(Dr.GetOrdinal("BandFechaCorte02")) ? false : Dr.GetBoolean(Dr.GetOrdinal("BandFechaCorte02"));
                    Datos.BandFecha03 = Dr.IsDBNull(Dr.GetOrdinal("BandFechaCorte03")) ? false : Dr.GetBoolean(Dr.GetOrdinal("BandFechaCorte03"));
                    Datos.Fecha01 = Dr.IsDBNull(Dr.GetOrdinal("FechaCorte01")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaCorte01"));
                    Datos.Fecha02 = Dr.IsDBNull(Dr.GetOrdinal("FechaCorte02")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaCorte02"));
                    Datos.Fecha03 = Dr.IsDBNull(Dr.GetOrdinal("FechaCorte03")) ? DateTime.Today : Dr.GetDateTime(Dr.GetOrdinal("FechaCorte03"));
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarDatosConfiguracion(Configuracion Datos)
        {
            try
            {
                object [] Parametros = { Datos.RazonSocial, Datos.NombreComercial, Datos.Eslogan, Datos.RFC,
                                       Datos.Representante, Datos.BandLogo, Datos.UrlLogo, Datos.BufferImagen,
                                       Datos.PorcentajeIva, Datos.BandFecha01, Datos.BandFecha02, Datos.BandFecha03,
                                       Datos.Fecha01, Datos.Fecha02, Datos.Fecha03, Datos.IDUsuario};
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_Configuracion", Parametros);
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

        public Configuracion ObtenerLogoImagen(string Conexion)
        {
            try
            {
                Configuracion Datos = new Configuracion();
                object Result = SqlHelper.ExecuteScalar(Conexion, "spCSLDB_get_LogoBuffer");
                if (Result != null)
                {
                    Datos.Completado = true;
                    Datos.BufferImagen = (byte[]) Result;
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LogoActualizado(Configuracion Datos)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Datos.Conexion, "spCSLDB_set_LogoActualizado", Datos.IDSucursal, Comun.IDProyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
