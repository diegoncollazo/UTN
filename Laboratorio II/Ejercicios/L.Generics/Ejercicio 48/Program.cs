using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_48
{
    class Program
    {
        static void Main(string[] args)
        {
            Contabilidad<Factura, Recibo> contabilidad = new Contabilidad<Factura, Recibo>();
            Recibo recibo1 = new Recibo();
            Recibo recibo2 = new Recibo(3000);

            Factura factura1 = new Factura(2000);
            Factura factura2 = new Factura(3000);

            _ = contabilidad + recibo1;
            _ = contabilidad + recibo2;
            _ = contabilidad + factura1;
            _ = contabilidad + factura2;

            foreach (var item in contabilidad.Ingresos)
            {
                Console.WriteLine(item.Numero);
            }
            Console.ReadKey();
        }
    }
}
