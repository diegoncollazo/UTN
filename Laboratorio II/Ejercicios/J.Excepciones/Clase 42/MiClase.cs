using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_42
{
    public class MiClase
    {
        private string nombre;

        public MiClase()
        {
            this.nombre = "Objeto final";
        }
        public MiClase(string nombre)
        {
            try
            {
                MiClase.Estatico();
            }
            catch(DivideByZeroException e)
            {
                new MiClase(e);
            }
        }
        public MiClase(Exception e)
        {
            try
            {
                new MiClase();
            }
            catch
            {
                
            }
        }
        public static void Estatico()
        {
            throw new DivideByZeroException();
        }

    }
}
