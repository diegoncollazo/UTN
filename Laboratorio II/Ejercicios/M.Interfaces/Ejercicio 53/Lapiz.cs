using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_53
{
    public class Lapiz : IAcciones
    {
        private float tamanoMina;
        ConsoleColor IAcciones.Color 
        {
            get
            {
                return ConsoleColor.Gray;
            }
               
            set 
                => throw new NotImplementedException();
        }
        float IAcciones.UnidadesDeEscritura 
        { 
            get 
                => throw new NotImplementedException(); 
            set 
                => throw new NotImplementedException(); 
        }

        public Lapiz(int unidades)
        {
            this.tamanoMina = unidades;
        }

        public EscrituraWrapper Escribir(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                this.tamanoMina -= 0.1F;
            }
            return new EscrituraWrapper(texto, ((IAcciones)(this)).Color);
        }
        public bool Recargar()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Lapiz color "+ ((IAcciones)(this)).Color + ", nivel de tinta: " + this.tamanoMina;
        }
    }
}
