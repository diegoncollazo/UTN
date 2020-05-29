using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics._2020;

namespace TestGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            //STRING
            Mensaje<string> tipoTexto = new Mensaje<string>();
            tipoTexto.MiAtributo = "Hola";

            Console.WriteLine(tipoTexto.MiAtributo);
            Console.WriteLine(tipoTexto.ToString());

            //MICLASE
            Mensaje<MiClase> tipoMio = new Mensaje<MiClase>();
            tipoMio.MiAtributo = new MiClase();

            Console.WriteLine(tipoMio.MiAtributo);
            Console.WriteLine(tipoMio.ToString());

            Console.ReadLine();

            //STRING - INT
            Mensajero<string, int> tipoTextoEntero = new Mensajero<string, int>();
            tipoTextoEntero.miAtr1 = "cadena";
            tipoTextoEntero.miAtr2 = 3;

            //CHAR - MICLASE
            Mensajero<char, MiClase> tipoLetraMio = new Mensajero<char, MiClase>();
            tipoLetraMio.miAtr1 = 'L';
            tipoLetraMio.miAtr2 = new MiClase();

            Console.WriteLine(tipoTextoEntero.ToString());
            Console.WriteLine(tipoLetraMio.ToString());

            Console.ReadLine();

            //RESTRICTIVA
            Restrictiva<MiClase> res = new Restrictiva<MiClase>();
            res.miLista.Add(new MiClase());

            Console.WriteLine(res.ToString());

            //ERROR, NO ES DE TIPO MICLASE
            //Restrictiva<string> res2 = new Restrictiva<string>();

            //DERIVADA
            Restrictiva<MiClase> res2 = new Restrictiva<MiClase>();
            res2.miLista.Add(new MiClaseDerivada());

            Console.WriteLine(res2.ToString());

            //TIPOS CON RESTRICCIONES
            RestrictivaVarios<MiClase, MiClaseDerivada> res3 = new RestrictivaVarios<MiClase, MiClaseDerivada>();

            //TIPO CON MULTIPLES RESTRICCIONES
            RestrictivaMultiple<MiClaseDerivada> res4 = new RestrictivaMultiple<MiClaseDerivada>();

            //ERROR, NO CUMPLE CON RESTRICCIONES
            //RestrictivaMultiple<MiClaseSinDefecto> res5 = new RestrictivaMultiple<MiClaseSinDefecto>();

            //RESTRICTIVA CON UNMANAGED
            RestrictivaUnmanaged<int> res5 = new RestrictivaUnmanaged<int>();

            RestrictivaUnmanaged<ConsoleColor> res6 = new RestrictivaUnmanaged<ConsoleColor>();

            Console.WriteLine(res5.ToString());
            Console.WriteLine(res6.ToString());

            //ERROR, NO ES UN TIPO UNMANAGED
            //RestrictivaUnmanaged<string> res7 = new RestrictivaUnmanaged<string>();

            Console.ReadLine();

            //METODOS GENERICS
            OtraClase oc = new OtraClase();

            //ESTATICO Y RESTRICTIVO (CLASEDERIVADA)
            MiClaseDerivada mcd = new MiClaseDerivada();
            string parametro = "hola, que tal?";

            Console.WriteLine(OtraClase.MetodoEstatico<MiClaseDerivada>(mcd, parametro));

            Console.WriteLine(OtraClase.MetodoEstatico(mcd, parametro));

            //ERROR, NO CUMPLE CON RESTRICCION
            //Console.WriteLine(OtraClase.MetodoEstatico(3, "hola"));

            //DE INSTANCIA, SIN RESTRICCIONES
            oc.MetodoInstancia<int>(3);

            oc.MetodoInstancia<string>("cadena");

            oc.MetodoInstancia<MiClase>(mcd);

            oc.MetodoInstancia(88.9f);

            //DE INSTANCIA, CON RETORNO Y RESTRICCIONES
            MiClaseDerivada retorno;

            retorno = oc.OtroMetodo<MiClaseDerivada, MiClase>(mcd, new MiClase());

            //ERROR, NO CUMPLE CON RESTRICCION
            //oc.OtroMetodo<MiClaseSinDefecto, MiClase>(new MiClaseSinDefecto(0), new MiClase());

            Console.ReadLine();
        }
    }
}
