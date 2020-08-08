using System;
using System.IO;
using System.Windows.Forms;

namespace Entidades
{
    public class Ticketeadora
    {
        public static bool ImprimirTicket(Caja<Fosforo> caja)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\tickets.log", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine("Precio total de la cartuchera: $" + caja.PrecioTotal);
                    MessageBox.Show("Se supero el precio. Archivo escrito con exito.");
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al escribir en el archivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
        }
    }
}
