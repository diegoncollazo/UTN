using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_16
{
    public class Alumno
    {
        private byte nota1;
        private byte nota2;
        private float notaFinal;
        public string apellido;
        public string nombre;
        public int legajo;

        public void CalcularFinal()
        {
            Random random = new Random();
            if (nota1 >= 4 && nota2 >= 4)
                this.notaFinal = random.Next(1, 10);
            else
                this.notaFinal = -1;
        }

        public void Estudiar(byte nota1, byte nota2)
        {
            this.nota1 = nota1;
            this.nota2 = nota2;
        }

        public string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Apellido: {0}\n", this.apellido);
            retorno.AppendFormat("Nombre:   {0}\n", this.nombre);
            retorno.AppendFormat("Legajo:   {0}\n", this.legajo);
            retorno.AppendFormat("Nota 1  : {0}\n", this.nota1);
            retorno.AppendFormat("Nota 2  : {0}\n", this.nota2);
            if (this.notaFinal != -1)
                retorno.AppendFormat("Final   : {0}\n", this.notaFinal);
            return retorno.ToString();
        }
    }
}
