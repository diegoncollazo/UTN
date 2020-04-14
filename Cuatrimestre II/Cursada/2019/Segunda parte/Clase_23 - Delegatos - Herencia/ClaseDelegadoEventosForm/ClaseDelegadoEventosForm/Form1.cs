using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaseDelegadoEventosForm
{
    public partial class Form1 : Form
    {
       public actualizarNombrePorDelegado MiDelegado;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void testDelegadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTestDelegado miFormDelegado = new FrmTestDelegado();
            miFormDelegado.Show(this);
            this.MiDelegado.Invoke("Probando mi amor por ti! baby baby baby");
        }

        private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDatos frmDatos = new FrmDatos();
            frmDatos.Show(this);
            this.MiDelegado += new actualizarNombrePorDelegado(frmDatos.ActualizarNombre);
        }
    }
}
