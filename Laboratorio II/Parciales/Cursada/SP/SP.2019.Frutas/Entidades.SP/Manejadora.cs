using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Entidades.SP
{
    public class Manejadora<Fruta>
    {
        public void ManejadorEventoPrecio(double precio, Cajon<Fruta> cajon)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\cajon.txt"))
                {
                    escritor.WriteLine(DateTime.Now);
                    escritor.WriteLine("$ " + precio);
                    MessageBox.Show("Se creo el archivo cajon.txt en el escritorio.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al escribir archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
