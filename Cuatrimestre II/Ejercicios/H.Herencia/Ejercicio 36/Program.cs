using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automovilismo;

namespace Ejercicio_36
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoF1 hamilton = new AutoF1(44, "Mercedes", 1000);
            AutoF1 hamilton2 = new AutoF1(44, "Mercedes", 1000);
            AutoF1 bottas = new AutoF1(77, "Mercedes", 1000);
            MotoCross moto = new MotoCross(22, "Honda", 250);
            Competencia competencia = new Competencia(70, 10, Competencia.ETipoCompetencia.MotoCross);
            if (hamilton != bottas)
                Console.WriteLine("Funciona");
            if (hamilton == hamilton2)
                Console.WriteLine("Iguales");
            if (competencia + hamilton)
                Console.WriteLine("Hamilton");
            if (competencia + bottas)
                Console.WriteLine("Bottas");
            if (competencia + moto)
                Console.WriteLine("MotoCross");
            Console.WriteLine(competencia.MostrarDatos());
            
            Console.ReadKey();



        }
    }
}
