using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ParaisoFiscal
    {
        private List<CuentaOffShore> _listadoCuentas;
        private EParaisosFiscales _lugar;

        private static int cantidadDeCuentas;
        private static DateTime fechaInicioActividades;

        static ParaisoFiscal()
        {
            cantidadDeCuentas = 0;
            fechaInicioActividades = DateTime.Now;
        }

        public ParaisoFiscal()
        {
            this._listadoCuentas = new List<CuentaOffShore>();
        }

        private ParaisoFiscal(EParaisosFiscales lugar) : this()
        {
            this._lugar = lugar;
        }

        public string MostrarParaiso()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Fecha de inicio: {0}\n", ParaisoFiscal.fechaInicioActividades);
            retorno.AppendFormat("Locación: {0}\n", this._lugar.ToString());
            retorno.AppendFormat("Cantidad de 'cuentitas': {0}\n", ParaisoFiscal.cantidadDeCuentas);
            retorno.Append("***********Listado de cuentas offshores***********\n");
            foreach(CuentaOffShore item in this._listadoCuentas)
            {
                retorno.AppendFormat("\nFecha de inicio: {0}", Cliente.RetornarDatos(item.Dueño));
                retorno.AppendFormat("Numero de cuenta: {0}\n", (int)(item));
                retorno.AppendFormat("Saldo: {0}\n", item.Saldo);
            }
            return retorno.ToString();
        }

        public static implicit operator ParaisoFiscal(EParaisosFiscales epf)
        {
            ParaisoFiscal retorno = new ParaisoFiscal(epf);
            return retorno;
        }

        public static bool operator ==(ParaisoFiscal pf, CuentaOffShore cos)
        {
            bool retorno = false;
            foreach (CuentaOffShore item in pf._listadoCuentas)
            {
                if (cos == item)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(ParaisoFiscal pf, CuentaOffShore cos)
        {
            return !(pf == cos);
        }
        public static ParaisoFiscal operator +(ParaisoFiscal pf, CuentaOffShore cos)
        {
            if (pf != cos)
            {
                pf._listadoCuentas.Add(cos);
                ParaisoFiscal.cantidadDeCuentas++;
                Console.WriteLine("Se agrego la cuenta al paraiso...");
            }
            else
            {
                foreach (CuentaOffShore item in pf._listadoCuentas)
                    if (item == cos)
                    {
                        item.Saldo += cos.Saldo;
                        Console.WriteLine("Se actualizó el saldo de la cuenta...");
                    }
            }
                
            return pf;
        }
        public static ParaisoFiscal operator -(ParaisoFiscal pf, CuentaOffShore cos)
        {
            if (pf == cos)
            {
                pf._listadoCuentas.Remove(cos);
                ParaisoFiscal.cantidadDeCuentas--;
                Console.WriteLine("Se quitó la cuenta al paraiso...");
            }
            else
            {
                Console.WriteLine("La cuenta no existe en el paraiso...");
            }
            return pf;
        }

    }
}
