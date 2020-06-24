using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_53
{
    public class Boligrafo : IAcciones
    {
        private ConsoleColor colorTinta;
        private float tinta;

        public ConsoleColor Color
        {
            get
            {
                return this.colorTinta;
            }
            set
            { 
                throw new NotImplementedException();
            }
        }
        public float UnidadesDeEscritura
        { 
            get
            { 
                return this.tinta;
            } 
            set
            { 
                this.tinta = value;
            }
        }

        public Boligrafo(int unidades, ConsoleColor color)
        {
            this.tinta = unidades;
            this.colorTinta = color;
        }

        public EscrituraWrapper Escribir(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
                this.tinta -= 0.3F;
            return new EscrituraWrapper(texto, this.Color);
        }
        public bool Recargar(int unidades)
        {
            this.tinta += unidades;
            return true;
        }

        public override string ToString()
        {
            return "Boligrafo color " + this.Color + ", nivel de tinta: " + this.UnidadesDeEscritura;
        }
    }
}
