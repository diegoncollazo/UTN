using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BancoNacional : Banco
    {
        //BancoNacional(nombre, pais)
        public string pais;
        
        public BancoNacional(string nombre, string pais) : base(nombre)
        {
            this.pais = pais;
        }

        //Agregar en Banco el método Mostrar():string y Mostrar(Banco):string, ambos abstractos.
        //El método que no recibe parámetros, retornará el nombre, mientras que el otro
        //retornará todas las características de la instancia que recibe como parametro. REUTILIZAR CODIGO.
        public override string Mostrar()
        {
            return this.nombre;
        }
        public override string Mostrar(Banco banco)
        {
            return this.pais;
        }
    }
}
