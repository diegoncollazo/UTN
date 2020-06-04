using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_16;

namespace Ejercicio_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alumno1 = new Alumno();
            alumno1.nombre = "Pepito";
            alumno1.apellido = "Pepito";
            alumno1.legajo = 123456;

            Alumno alumno2 = new Alumno();
            alumno2.nombre = "Pepito";
            alumno2.apellido = "Pepito";
            alumno2.legajo = 123456;

            Alumno alumno3 = new Alumno();
            alumno3.nombre = "Pepito";
            alumno3.apellido = "Pepito";
            alumno3.legajo = 123456;

            alumno1.Estudiar(2, 4);
            alumno2.Estudiar(6, 2);
            alumno3.Estudiar(7, 6);

            alumno1.CalcularFinal();
            alumno2.CalcularFinal();
            alumno3.CalcularFinal();

            Console.WriteLine(alumno1.Mostrar());
            Console.WriteLine(alumno2.Mostrar());
            Console.WriteLine(alumno3.Mostrar());

            Console.ReadKey();
        }
    }
}
