﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephSoft.Global
{
    public class MotivoCanc
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

        private int _IDMotivo;

        public int IDMotivo
        {
            get { return _IDMotivo; }
            set { _IDMotivo = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private bool _RequiereDatos;

        public bool RequiereDatos
        {
            get { return _RequiereDatos; }
            set { _RequiereDatos = value; }
        }
        
        
    }
}
