using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class Venta
    {
        private bool _Completado;
        private string _Conexion;
        private string _Descripcion;
        private string _IDCliente;
        private string _IDUsuario;
        private int _Opcion;
        private bool _Seleccionado; private DataTable _TablaDatos;

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
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string IDCliente
        {
            get { return _IDCliente; }
            set { _IDCliente = value; }
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
        public bool Seleccionado
        {
            get { return _Seleccionado; }
            set { _Seleccionado = value; }
        }
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private string _IDVenta;

        public string IDVenta
        {
            get { return _IDVenta; }
            set { _IDVenta = value; }
        }

        private string _FolioVenta;

        public string FolioVenta
        {
            get { return _FolioVenta; }
            set { _FolioVenta = value; }
        }

        private string _NombreCliente;

        public string NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; }
        }

        private DateTime _HoraInicio;

        public DateTime HoraInicio
        {
            get { return _HoraInicio; }
            set { _HoraInicio = value; }
        }

        private int _TiempoTranscurridoSegundos;

        public int TiempoTranscurridoSegundos
        {
            get { return _TiempoTranscurridoSegundos; }
            set { _TiempoTranscurridoSegundos = value; }
        }

        private decimal _Subtotal;

        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }


        private decimal _Descuento;

        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        private decimal _Iva;

        public decimal Iva
        {
            get { return _Iva; }
            set { _Iva = value; }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private string _IDCaja;

        public string IDCaja
        {
            get { return _IDCaja; }
            set { _IDCaja = value; }
        }

        private string _IDSucursal;

        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }

        private int _IDEstatusVenta;

        public int IDEstatusVenta
        {
            get { return _IDEstatusVenta; }
            set { _IDEstatusVenta = value; }
        }

        private bool _Actual;

        public bool Actual
        {
            get { return _Actual; }
            set { _Actual = value; }
        }

        private DateTime _FechaVenta;

        public DateTime FechaVenta
        {
            get { return _FechaVenta; }
            set { _FechaVenta = value; }
        }

        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }


        private string _IDCajero;

        public string IDCajero
        {
            get { return _IDCajero; }
            set { _IDCajero = value; }
        }

        private decimal _Comision;

        public decimal Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }

        private decimal _TotalAPagar;

        public decimal TotalAPagar
        {
            get { return _TotalAPagar; }
            set { _TotalAPagar = value; }
        }

        private decimal _PuntosObtenidos;

        public decimal PuntosObtenidos
        {
            get { return _PuntosObtenidos; }
            set { _PuntosObtenidos = value; }
        }

        private string _CodigoVale;

        public string CodigoVale
        {
            get { return _CodigoVale; }
            set { _CodigoVale = value; }
        }

        private List<VentaDetalle> _ListaDetalle;

        public List<VentaDetalle> ListaDetalle
        {
            get { return _ListaDetalle; }
            set { _ListaDetalle = value; }
        }

        private decimal _Saldo;

        public decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private decimal _PuntosVenta;

        public decimal PuntosVenta
        {
            get { return _PuntosVenta; }
            set { _PuntosVenta = value; }
        }

        private decimal _TotalPago;

        public decimal TotalPago
        {
            get { return _TotalPago; }
            set { _TotalPago = value; }
        }

        private decimal _TotalCambio;

        public decimal TotalCambio
        {
            get { return _TotalCambio; }
            set { _TotalCambio = value; }
        }

        private DateTime _FechaHoraSistema;

        public DateTime FechaHoraSistema
        {
            get { return _FechaHoraSistema; }
            set { _FechaHoraSistema = value; }
        }

        private DateTime _FechaCanc;

        public DateTime FechaCanc
        {
            get { return _FechaCanc; }
            set { _FechaCanc = value; }
        }

        private int _IDMotivoCanc;

        public int IDMotivoCan
        {
            get { return _IDMotivoCanc; }
            set { _IDMotivoCanc = value; }
        }

        private string _ComentariosCanc;

        public string ComentariosCanc
        {
            get { return _ComentariosCanc; }
            set { _ComentariosCanc = value; }
        }

        private decimal _MontoPenalizacionCanc;

        public decimal MontoPenalizacionCanc
        {
            get { return _MontoPenalizacionCanc; }
            set { _MontoPenalizacionCanc = value; }
        }

        private List<Producto> _ListaProductos;

        public List<Producto> ListaProductos
        {
            get { return _ListaProductos; }
            set { _ListaProductos = value; }
        }

        private List<FormaPago> _ListaFormasPago;

        public List<FormaPago> ListaFormasPago
        {
            get { return _ListaFormasPago; }
            set { _ListaFormasPago = value; }
        }


        private bool _Band;

        public bool Band
        {
            get { return _Band; }
            set { _Band = value; }
        }
        private int _IDTipoVenta;

        public int IDTipoVenta
        {
            get { return _IDTipoVenta; }
            set { _IDTipoVenta = value; }
        }

        private string _TextoVenta;

        public string TextoVenta
        {
            get { return _TextoVenta; }
            set { _TextoVenta = value; }
        }

        private string _NombreSucursal;

        public string NombreSucursal
        {
            get { return _NombreSucursal; }
            set { _NombreSucursal = value; }
        }


    }
	
}