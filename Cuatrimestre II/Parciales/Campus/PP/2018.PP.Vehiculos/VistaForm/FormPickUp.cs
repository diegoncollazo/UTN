using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace VistaForm
{
    public partial class FormPickUp : Form
    {
        public FormPickUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PickUp pickup = new PickUp(textBox1.Text, textBox2.Text);
            MessageBox.Show(pickup.ConsultarDatos());
        }
    }
}
