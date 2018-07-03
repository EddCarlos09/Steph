using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Datos;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Catalogo_Negocio
    {
      
        public void ObtenerCatFamiliaProductos(FamiliaProducto Datos)
        {
            try
            {
                Catalogo_Datos cd = new Catalogo_Datos();
                cd.ObtenerCatFamiliaProductos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatTipoMetrica(TipoMetrica Datos)
        {
            try
            {
                Catalogo_Datos cd = new Catalogo_Datos();
                cd.ObtenerCatTipoMetrica(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatTipoUso(TipoUso Datos)
        {
            try
            {
                Catalogo_Datos cd = new Catalogo_Datos();
                cd.ObtenerCatTipoUso(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerCatUnidadMedida(UnidadMedida Datos)
        {
            try
            {
                Catalogo_Datos cd = new Catalogo_Datos();
                cd.ObtenerCatUnidadMedida(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TipoRegistro> ObtenerCatTipoRegistro(TipoRegistro Datos)
        {
            try
            {
                Catalogo_Datos CD = new Catalogo_Datos();
                return CD.ObtenerCatTipoRegistro(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime ObtenerFechaSistema(string Conexion)
        {
            try
            {
                Catalogo_Datos CD = new Catalogo_Datos();
                return CD.ObtenerFechaSistema(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<TipoIdentificacion> ObtenerComboTipoIdentificacion(TipoIdentificacion Datos)
        {
            try
            {
                Catalogo_Datos CD = new Catalogo_Datos();
                return CD.ObtenerComboTipoIdentificacion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Banco> ObtenerComboBancos(Banco Datos)
        {
            try
            {
                Catalogo_Datos CD = new Catalogo_Datos();
                return CD.ObtenerComboBancos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
