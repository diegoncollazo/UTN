using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Events
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUnMensaje_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Primer boton");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* Asociar eventos a manejadores */
            this.btnEnFoco.Click += ManejadorDos;
            this.textBox1.TextChanged += ManejadorDos;

            this.btnDosMensajes.Click += ManejadorDos;
            this.btnDosMensajes.Click += ManejadorTres ;
        }

        private void ManejadorDos(object sender, EventArgs e)
        {
            MessageBox.Show("Segundo manejador");
        }

        private void ManejadorTres(object sender, EventArgs e)
        {
            MessageBox.Show("Tercer manejador");
        }
    }
}
