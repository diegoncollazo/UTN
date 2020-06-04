using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BancoMunicipal : BancoProvincial
    {
        //BancoMunicipal(bancoProvincial, municipio)
        public string municipio;

        public BancoMunicipal(BancoProvincial banco, string municipio) : base(banco, banco.provincia)
        {
            this.municipio = municipio;
        }

        public override string Mostrar(Banco banco)
        {
            //return base.Mostrar(banco) + " " + this.municipio;
            return "Municipal";
        }

        //public static implicit operator string(BancoMunicipal banco)
        //{
        //    return banco.Mostrar(banco);
        //}

    }
}