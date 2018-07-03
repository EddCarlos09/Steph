using CreativaSL.Dll.StephSoft.Datos;
using CreativaSL.Dll.StephSoft.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Negocio
{
    public class Pedido_Negocio
    {
        public List<PedidoDetalle> ObtenerComboClavesProduccion(PedidoDetalle Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                return PD.ObtenerComboClavesProduccion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACPedidos(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ACPedidos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerPedidosTab(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ObtenerPedidosTab(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPedidosTabBusq(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ObtenerPedidosTabBusq(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerPedidosSurtidos(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ObtenerPedidosSurtidos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPedidosSurtidosBusq(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ObtenerPedidosSurtidosBusq(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerPedidosXIDEstatusXIDSucursal(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ObtenerPedidosXIDEstatusXIDSucursal(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoDetalle> ObtenerDetallePedido(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                return PD.ObtenerDetallePedido(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoDetalle> ObtenerDetallePedidoSurtido(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                return PD.ObtenerDetallePedidoSurtido(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarPedido(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.EnviarPedido(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RecibirPedido(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.RecibirPedido(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPedido(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.EliminarPedido(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
