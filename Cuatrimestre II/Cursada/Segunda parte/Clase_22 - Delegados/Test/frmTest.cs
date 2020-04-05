using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            Manejadora man = new Manejadora();

            this.lblEtiqueta.Click += new  System.EventHandler(man.ManejadorDos);
            this.txtCuadroTexto.Click += new System.EventHandler(man.ManejadorDos);
            this.btnBoton.Click += new System.EventHandler(man.ManejadorDos);
        }

        private void MostrarMensaje(object sender, EventArgs e)
        {
            MessageBox.Show("Evento click del boton");
              
        }

        private void lblEtiqueta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Evento click en el label");

        }

        private void txtCuadroTexto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Evento click cuadro de texto");
        }

        private void btnBoton_Click(object sender, EventArgs e)
        {

        }
    }
}
