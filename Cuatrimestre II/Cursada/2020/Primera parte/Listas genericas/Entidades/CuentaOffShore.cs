using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CuentaOffShore
    {
        private Cliente _dueño;
        private int _numeroDeCuenta;
        private double _saldo;

        public Cliente Dueño
        {
            get
            {
                return this._dueño;
            }
        }
        public double Saldo
        {
            get
            {
                return this._saldo;
            }
            set
            {
                this._saldo = value;
            }
        }
        public CuentaOffShore(Cliente dueño, int numero, double saldoInicial)
        {
            this._dueño = dueño;
            this._numeroDeCuenta = numero;
            this._saldo = saldoInicial;
        }
        public CuentaOffShore(string nombre, ETipoCliente tipo, int numero, double saldoInicial) 
            : this(new Cliente(tipo, nombre), numero, saldoInicial)
        {

        }

        public static explicit operator int(CuentaOffShore cos)
        {
            return cos._numeroDeCuenta;
        }
        public static bool operator ==(CuentaOffShore cos1, CuentaOffShore cos2)
        {
            return (cos1._numeroDeCuenta == cos2._numeroDeCuenta && cos1.Dueño == cos2.Dueño);
        }
        public static bool operator !=(CuentaOffShore cos1, CuentaOffShore cos2)
        {
            return !(cos1 == cos2);
        }

    }
}
