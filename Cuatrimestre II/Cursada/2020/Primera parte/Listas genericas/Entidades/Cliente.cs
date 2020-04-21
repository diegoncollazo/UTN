using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private string _aliasParaIncognito;
        private string _nombre;
        private ETipoCliente _tipoDeCliente;

        private Cliente()
        {
            this._nombre = "NN";
            this._aliasParaIncognito = "Sin Alias";
            this._tipoDeCliente = ETipoCliente.SinTipo;
        }
        public Cliente(ETipoCliente tipoCliente) : this()
        {
            this._tipoDeCliente = tipoCliente;
        }
        public Cliente(ETipoCliente tipoCliente, string nombre) : this(tipoCliente)
        {
            this._nombre = nombre;
        }
        private void CrearAlias()
        {
            Random random = new Random();
            this._aliasParaIncognito = random.Next(1000, 9999).ToString() + _tipoDeCliente.ToString();
        }
        public string GetAlias()
        {
            if (this._aliasParaIncognito == "Sin Alias")
                CrearAlias();
            return this._aliasParaIncognito;
        }
        private string RetornarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Nombre: {0}\n", this._nombre);
            retorno.AppendFormat("Alias: {0}\n", this._aliasParaIncognito);
            retorno.AppendFormat("Tipo de cliente: {0}\n", this._tipoDeCliente.ToString());
            return retorno.ToString();
        }
        public static string RetornarDatos(Cliente cliente)
        {
            return cliente.RetornarDatos();
        }

    }
}
