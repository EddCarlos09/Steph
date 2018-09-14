using CreativaSL.Dll.StephSoft.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Notificacion_Negocio
    {
        public DataTable ObtenerNotificaciones(string Conexion, string IDSucursal)
        {
            try
            {
                Notificacion_Datos Datos = new Notificacion_Datos();
                return Datos.ObtenerNotificaciones(Conexion, IDSucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarNotificacionVisto(string Conexion, string IDSucursal, bool Visto, int IDTipoNotificacion, string IDUsuario)
        {
            try
            {
                Notificacion_Datos Datos = new Notificacion_Datos();
                Datos.ActualizarNotificacionVisto(Conexion, IDSucursal, Visto, IDTipoNotificacion, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
