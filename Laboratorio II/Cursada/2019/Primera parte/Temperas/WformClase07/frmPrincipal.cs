using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WformClase07
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;//Formulario principal contiene a otros formularios.
            this.WindowState = FormWindowState.Maximized;//Inicia maximizado.
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaleta formularioPaleta = new frmPaleta();
            formularioPaleta.MdiParent = this;
            formularioPaleta.StartPosition = FormStartPosition.CenterScreen;
            formularioPaleta.Show();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea salir del programa?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
                e.Cancel = true;
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
