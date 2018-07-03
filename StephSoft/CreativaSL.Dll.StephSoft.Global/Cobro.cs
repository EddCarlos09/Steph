using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class Cobro
    {
        private bool _Completado;
        private string _Conexion;
        private string _IDSucursal;
        private string _IDUsuario;
        private bool _IncluirSelect;
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
        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }
        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
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

        private string _IDVenta;

        public string IDVenta
        {
            get { return _IDVenta; }
            set { _IDVenta = value; }
        }
        

        private string _IDCliente;

        public string IDCliente
        {
            get { return _IDCliente; }
            set { _IDCliente = value; }
        }

        private string _IDTarjeta;

        public string IDTarjeta
        {
            get { return _IDTarjeta; }
            set { _IDTarjeta = value; }
        }

        private string _Cliente;

        public string Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private int _IDTipoMonedero;

        public int IDTipoMonedero
        {
            get { return _IDTipoMonedero; }
            set { _IDTipoMonedero = value; }
        }

        private string _NumTarjeta;

        public string NumTarjeta
        {
            get { return _NumTarjeta; }
            set { _NumTarjeta = value; }
        }

        private decimal _Saldo;

        public decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private decimal _Monto;

        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        private decimal _Descuento;

        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        private decimal _Subtotal;

        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private decimal _Iva;

        public decimal Iva
        {
            get { return _Iva; }
            set { _Iva = value; }
        }

        private decimal _TotalAPagar;

        public decimal TotalAPagar
        {
            get { return _TotalAPagar; }
            set { _TotalAPagar = value; }
        }

        private decimal _PuntosVenta;

        public decimal PuntosVenta
        {
            get { return _PuntosVenta; }
            set { _PuntosVenta = value; }
        }

        private decimal _Pago;

        public decimal Pago
        {
            get { return _Pago; }
            set { _Pago = value; }
        }

        private decimal _Cambio;

        public decimal Cambio
        {
            get { return _Cambio; }
            set { _Cambio = value; }
        }

        private List<FormaPago> _ListaCobroDetalle;

        public List<FormaPago> ListaCobroDetalle
        {
            get { return _ListaCobroDetalle; }
            set { _ListaCobroDetalle = value; }
        }

        private string _FolioVale;

        public string FolioVale
        {
            get { return _FolioVale; }
            set { _FolioVale = value; }
        }

        private string _IDVale;

        public string IDVale
        {
            get { return _IDVale; }
            set { _IDVale = value; }
        }

        private int _Resultado;

        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        private decimal _Comision;

        public decimal Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }

        private string _IDCaja;

        public string IDCaja
        {
            get { return _IDCaja; }
            set { _IDCaja = value; }
        }

        private string _IDCajero;

        public string IDCajero
        {
            get { return _IDCajero; }
            set { _IDCajero = value; }
        }

        private bool _RequiereFactura;

        public bool RequiereFactura
        {
            get { return _RequiereFactura; }
            set { _RequiereFactura = value; }
        }

        private string _CodigoEmpleado;

        public string CodigoEmpleado
        {
            get { return _CodigoEmpleado; }
            set { _CodigoEmpleado = value; }
        }
        
    }
}
