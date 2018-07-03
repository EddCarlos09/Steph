using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Datos;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Genero_Negocio 
    {
        public void ObtenerGenero(Genero Datos)
        {
            try
            {
                Genero_Datos GD = new Genero_Datos();
                GD.ObtenerCatGeneros(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
