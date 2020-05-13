using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public class ClaseConstructores
    {
        //Crear una clase (ClaseConstructores) que al instanciarse:
        //    1)pase por un constructor estático
        //    2)pase por un constructor que reciba 2 parámetros (privado)
        //    3)pase por un constructor publico (default)
        //    4)pase por una propiedad de sólo escritura
        //    5)pase por una propiedad de sólo lectura
        //    6)pase por un método de instancia
        //    7)pase por un método de clase
        //NOTA: el orden no se puede alterar.
        //NOTA: por cada lugar que pase, mostrar con un MessageBox.Show dicho lugar
        //NOTA: agregar la referencia a System.Windows.Form; para poder acceder a la clase MessageBox.
        //NOTA: NO MAS DE 2 LINEAS DE CODIGO POR METODO/PROPIEDAD/CONSTRUCTOR
        private int privado1;
        private int privado2;

        static ClaseConstructores() 
        {
            MessageBox.Show("Constructor estatico");
        }

        public ClaseConstructores() : this(1, 2)
        {
            MessageBox.Show("Constructor por defecto");
            this.Privado1 = this.Privado2;
            this.Instancia();
            ClaseConstructores.Clase();
        }

        private ClaseConstructores(int privado1, int privado2) 
        {
            MessageBox.Show("Constructor privado con parametros");
        }

        public int Privado1
        {
            set
            {
                MessageBox.Show("Propiedad solo escritura");
                this.privado1 = value;
            }
        }

        public int Privado2
        {
            get
            {
                MessageBox.Show("Propiedad solo lectura");
                return this.privado1;
            }
        }

        public void Instancia()
        {
            MessageBox.Show("Metodo de intancia");
        }

        public static void Clase()
        {
            MessageBox.Show("Metodo de clase");
        }
    }
}
