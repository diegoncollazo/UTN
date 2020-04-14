using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_16
{
    public class Alumno
    {
        private byte nota1;
        private byte nota2;
        private byte notaFinal;
        public string apellido;
        public string nombre;
        public int legajo;

        public void CalcularFinal()
        {
            Random random = new Random();
            if (nota1 >= 4 && nota2 >= 4)
            {
                this.notaFinal = (byte)random.Next(1, 10);
            }
        }

        public void Estudiar(byte nota1, byte nota2)
        {
            this.nota1 = nota1;
            this.nota2 = nota2;
        }

        public string Mostrar()
        {
            string retorno = "";
            if (notaFinal != 0)
            {
                retorno = apellido + nombre + legajo + nota1.ToString() + nota2.ToString() + notaFinal.ToString();
            }
            return retorno;
        }
    }
}
