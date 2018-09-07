using CreativaSL.Dll.StephSoft.Datos;
using CreativaSL.Dll.StephSoft.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Venta_Negocio
    {
        public void InsertarNuevaVentaAbierta(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.InsertarNuevaVentaAbierta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerVentasXFecha(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.ObtenerVentasXFecha(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerServiciosXIDVenta(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.ObtenerServiciosXIDVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerProductosXIDVentaServicio(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.ObtenerProductosXIDVentaServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void ObtenerUsosXIDVentaServicio(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.ObtenerUsosXIDVentaServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoDetalle> LlenarComboClavesProduccion(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.LlenarComboClavesProduccion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarClaveAServicio(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.AgregarClaveAServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void QuitarClaveAServicio(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.QuitarClaveAServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void AgregarServicioAVenta(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.AgregarServicioAVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarProductoAServicio(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.AgregarProductoAServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ConcluirServicio(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.ConcluirServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void QuitarServicio(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.QuitarServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDatosCobroXIDVenta(Cobro Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.ObtenerDatosCobroXIDVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cobro AplicarVale(Vales Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.AplicarVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cobro RemoverVale(Vales Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.RemoverVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void QuitarProductoServicio(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.QuitarProductoServicio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TieneVale(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.TieneVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CobroVentaServicios(Cobro Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.CobroVentaServicios(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void CobroVentaServiciosCortesia(Cobro Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.CobroVentaServiciosCortesia(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public void InsertarNuevaVenta(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.InsertarNuevaVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VentaDetalle ObtenerProductoXClaveProducto(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.ObtenerProductoXClaveProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VentaDetalle ObtenerProductoXIDProducto(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.ObtenerProductoXIDProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPuntosVenta(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.ObtenerPuntosVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CobroVenta(Cobro Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.CobroVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void QuitarProductoVenta(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.QuitarProductoVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VentaDetalle CambiarCantidadVenta(VentaDetalle Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.CambiarCantidadVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void QuitarVenta(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.QuitarVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerVentasXFolio(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.ObtenerVentasXFolio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void BusquedaVentasGarantia(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.BusquedaVentasGarantia(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BusquedaVentasTicket(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.BusquedaVentasTicket(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleVenta(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.ObtenerDetalleVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<MotivoCanc> ObtenerComboMotivoCanc(MotivoCanc Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.ObtenerComboMotivoCanc(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelarVenta(Venta Datos)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                VD.CancelarVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<Producto> ObtenerPromocionesDelDia(bool IncluirSelect, string Conexion, string IDSucursal)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.ObtenerPromocionesDelDia(IncluirSelect, Conexion, IDSucursal);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public bool AgregarPromocionAVenta(PromocionVenta Datos, string Conexion, string IDSucursal, string IDUsuario)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.AgregarPromocionAVenta(Datos, Conexion, IDSucursal, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IniciarServicio(VentaDetalle Datos, string Conexion, string IDUsuario)
        {
            try
            {
                Venta_Datos VD = new Venta_Datos();
                return VD.IniciarServicio(Datos, Conexion, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venta AplicarDescuentoCumpleaños(string Conexion, string IDVenta, string IDCliente, string IDSucursal, string IDUsuario)
        {
            try
            {
                Venta_Datos VentDatos = new Venta_Datos();
                return VentDatos.AplicarDescuentoCumpleaños(Conexion, IDVenta, IDCliente, IDSucursal, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int RemoverDescuentoCumpleaños(string Conexion, string IDVenta, string IDUsuario)
        {
            try
            {
                Venta_Datos VentDatos = new Venta_Datos();
                return VentDatos.RemoverDescuentoCumpleaños(Conexion, IDVenta, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
