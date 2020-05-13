using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public class Banco
    {
        public string nombre;

        public Banco(string nombre)
        {
            this.nombre = nombre;
        }

        public virtual string Mostrar()
        {
            return this.nombre;
        }
        public virtual string Mostrar(Banco banco)
        {
            return banco.Mostrar();
        }
        
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is Banco)
            {
                if ((Banco)obj == this)
                {
                    MessageBox.Show("Mismo nombre");
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            return retorno;
        }
    }
}
