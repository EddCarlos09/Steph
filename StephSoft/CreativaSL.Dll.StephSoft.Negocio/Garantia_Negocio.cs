using CreativaSL.Dll.StephSoft.Datos;
using CreativaSL.Dll.StephSoft.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Garantia_Negocio
    {
        public void AplicarNuevaGarantia(Garantia Datos)
        {
            try
            {
                Garantia_Datos GD = new Garantia_Datos();
                GD.AplicarNuevaGarantia(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BusquedaGarantias(Garantia Datos)
        {
            try
            {
                Garantia_Datos GD = new Garantia_Datos();
                GD.BusquedaGarantias(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Garantia ObtenerDetalleGarantia(Garantia Datos)
        {
            try
            {
                Garantia_Datos GD = new Garantia_Datos();
                return GD.ObtenerDetalleGarantia(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
