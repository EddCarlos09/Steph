using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephSoft.Global;
using CreativaSL.Dll.StephSoft.Datos;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Producto_Negocio
    {

        public void ABCCatProductos(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ABCCatProductos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatProductos(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerCatProductos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatProductosBusqueda(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerCatProductosBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatTipoMonederoXIDProducto(TipoMonedero Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerCatTipoMonederoXIDProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Producto ObtenerDatosProductoXID(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                return PD.ObtenerDatosProductoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Proveedor> ObtenerProveedoresDisponiblesXIDProducto(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                return PD.ObtenerProveedoresDisponiblesXIDProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Proveedor> ObtenerProveedorXIDProducto(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                return PD.ObtenerProveedorXIDProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerBusquedaProductosServicios(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerBusquedaProductosServicios(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDatosProductoCompraXID(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerDatosProductoCompraXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Producto> ObtenerProductosBusqueda(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                return PD.ObtenerProductosBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerProductosInventario(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerProductosInventario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerProductosInventarioMatrizXIDSUCURSALCAJA(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerProductosInventarioMatrizXIDSUCURSALCAJA(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AInventarioEXCEL(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.AInventarioEXCEL(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Producto ObtenerExistentes(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                return PD.ObtenerExistentes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarExistenciaProductoXSucusal(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ActualizarExistenciaXProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
