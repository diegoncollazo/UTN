using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BancoProvincial : BancoNacional
    {
        //BancoProvincial(bancoNacional, provincia)
        
        public string provincia;

        public BancoProvincial(BancoNacional banco, string provincia) : base(banco.nombre, banco.pais)
        {
            this.provincia = provincia;
        }

        public override string Mostrar(Banco banco) 
        {
            //return base.Mostrar(banco) + " " + this.provincia;
            return "Provincial";
        }
    }
}
