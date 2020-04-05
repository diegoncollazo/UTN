using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Clase_23
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //Creo empleado
            Empleado empleado = new Empleado();
            //Asigno evento
            empleado._limiteSueldo += new DelegadoSueldo(LimiteSueldoEmpleado);
            empleado._limiteSueldo += new DelegadoSueldo(program.GuardarLog);

            empleado.Nombre = "Diego Collazo";
            empleado.Legajo = 12345;
            empleado.Sueldo = 20000f;

            Console.WriteLine(empleado.ToString());

            Console.ReadKey();
        }

        public static void LimiteSueldoEmpleado(Empleado empleado, float sueldo)
        {
            Console.WriteLine("Al empleado {0}, con legajo {1} se le quizo asignar el sueldo: ${2}", empleado.Nombre, empleado.Legajo, empleado.Sueldo);
        }

        public void GuardarLog(Empleado empleado, float sueldo)
        {
            //Guardar archivo de texto 
            //fecha hora minuto segundo
            //nombre + legajo + sueldo a asignar
            //incidentes.log
            Console.WriteLine("Aca guardo el archivo");
        }
    }
}
