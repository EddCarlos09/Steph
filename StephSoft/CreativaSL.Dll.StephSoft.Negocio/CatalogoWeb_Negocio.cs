﻿using CreativaSL.Dll.StephSoft.Datos;
using CreativaSL.Dll.StephSoft.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class CatalogoWeb_Negocio
    {
        public List<CatalogoWeb> ObtenerCatalogoWeb(CatalogoWeb Datos)
        {
            try
            {
                CatalogoWeb_Datos CWD = new CatalogoWeb_Datos();
                return CWD.ObtenerCatalogoWeb(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatalogoWeb> ObtenerCatalogoWebBusq(CatalogoWeb Datos)
        {
            try
            {
                CatalogoWeb_Datos CWD = new CatalogoWeb_Datos();
                return CWD.ObtenerCatalogoWebBusq(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarCatalogoWeb(CatalogoWeb Datos)
        {
            try
            {
                CatalogoWeb_Datos CWD = new CatalogoWeb_Datos();
                CWD.EliminarCatalogoWeb(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACCatalogoWeb(CatalogoWeb Datos)
        {
            try
            {
                CatalogoWeb_Datos CWD = new CatalogoWeb_Datos();
                CWD.ACCatalogoWeb(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarImagen(CatalogoWeb Datos)
        {
            try
            {
                CatalogoWeb_Datos CWD = new CatalogoWeb_Datos();
                CWD.GuardarImagen(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
