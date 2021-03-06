﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Entidades
{
    public class Ticketeadora
    {
        public static bool ImprimirTicket(Cartuchera<Goma> cartuchera)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\tickets.log", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine("Precio total de la cartuchera: $" + cartuchera.PrecioTotal);
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
