using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class PedidoDetalle
    {

        private bool _Completado;
        private string _Conexion;
        private string _IDUsuario;
        private int _Opcion;
        private DataTable _TablaDatos;

        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }
        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }


        private string _IDPedidoDetalle;

        public string IDPedidoDetalle
        {
            get { return _IDPedidoDetalle; }
            set { _IDPedidoDetalle = value; }
        }

        private string _IDPedido;

        public string IDPedido
        {
            get { return _IDPedido; }
            set { _IDPedido = value; }
        }

        private string _IDProducto;

        public string IDProducto
        {
            get { return _IDProducto; }
            set { _IDProducto = value; }
        }

        private string _NombreProducto;

        public string NombreProducto
        {
            get { return _NombreProducto; }
            set { _NombreProducto = value; }
        }

        private bool _Completo;

        public bool Completo
        {
            get { return _Completo; }
            set { _Completo = value; }
        }

        private decimal _Cantidad;

        public decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private string _IDEmpleado;

        public string IDEmpleado
        {
            get { return _IDEmpleado; }
            set { _IDEmpleado = value; }
        }

        private string _NombreEmpleado;

        public string NombreEmpleado
        {
            get { return _NombreEmpleado; }
            set { _NombreEmpleado = value; }
        }

        private decimal _CantidadSurtida;

        public decimal CantidadSurtida
        {
            get { return _CantidadSurtida; }
            set { _CantidadSurtida = value; }
        }

        private decimal _CantidadPendiente;

        public decimal CantidadPendiente
        {
            get { return _CantidadPendiente; }
            set { _CantidadPendiente = value; }
        }

        private string _ClaveProducto;

        public string ClaveProducto
        {
            get { return _ClaveProducto; }
            set { _ClaveProducto = value; }
        }

        private string _ClaveProduccion;

        public string ClaveProduccion
        {
            get { return _ClaveProduccion; }
            set { _ClaveProduccion = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private string _IDAsignacion;

        public string IDAsignacion
        {
            get { return _IDAsignacion; }
            set { _IDAsignacion = value; }
        }

        private string _IDPedidoDetalleRecepcion;

        public string IDPedidoDetalleRecepcion
        {
            get { return _IDPedidoDetalleRecepcion; }
            set { _IDPedidoDetalleRecepcion = value; }
        }

        private decimal _CantidadRecibida;

        public decimal CantidadRecibida
        {
            get { return _CantidadRecibida; }
            set { _CantidadRecibida = value; }
        }

        private decimal _CantidadARecibir;

        public decimal CantidadARecibir
        {
            get { return _CantidadARecibir; }
            set { _CantidadARecibir = value; }
        }

        private string _IDPedidoSurtidoDetalle;

        public string IDPedidoSurtidoDetalle
        {
            get { return _IDPedidoSurtidoDetalle; }
            set { _IDPedidoSurtidoDetalle = value; }
        }

        private bool _EsEmpleado;

        public bool EsEmpleado
        {
            get { return _EsEmpleado; }
            set { _EsEmpleado = value; }
        }
        
    }
}