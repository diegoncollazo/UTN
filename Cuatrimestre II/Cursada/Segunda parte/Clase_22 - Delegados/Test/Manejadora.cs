using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public class Manejadora
    {

        public static void Manejador (object sender, EventArgs e)
        {
            MessageBox.Show("Clase Manejadora");
        }

        public void ManejadorDos (object sender,EventArgs e)
        {
            MessageBox.Show("Estoy en instancia manejadora");

            if(sender is Button)
            {
                MessageBox.Show("Fue Boton");
            }
            else if(sender is TextBox)
            {
                MessageBox.Show("Fue TextBox");
            }
            else
            {
                MessageBox.Show("Fue Label");
            }
        }

    }
}
