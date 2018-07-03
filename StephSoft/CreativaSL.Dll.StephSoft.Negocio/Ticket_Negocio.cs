using CreativaSL.Dll.StephSoft.Datos;
using CreativaSL.Dll.StephSoft.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Ticket_Negocio
    {

        public void ObtenerDetalleVenta(Venta Datos)
        {
            try
            {
                Ticket_Datos TD = new Ticket_Datos();
                TD.ObtenerDetalleVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
