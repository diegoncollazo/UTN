using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics._2020
{
    public class OtraClase
    {
        public string atributo;

        public OtraClase()
        {
            this.atributo = "sin valor";
        }

        public static string MetodoEstatico<T>(T param1, string param2)
            where T : MiClaseDerivada
        {
            return param1.ToString() + " - " + param2;
        }

        public void MetodoInstancia<U>(U param)
        {
            Console.WriteLine(param.GetType().Name);
        }

        public A OtroMetodo<A, B>(A param1, B param2)
            where A : new()
            where B : MiClase
        {
            this.atributo = param2.ToString();
            return param1; 
        }
    }
}
