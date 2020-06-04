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
    public partial class FrmTestDelegado : Form
    {
        public FrmTestDelegado()
        {
            InitializeComponent();
            
        }

        private void ConfigurarOpenSaveFileDialog()
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string s = textBoxFromDelegado.Text;
            ((Form1)this.Owner).MiDelegado(s);
        }
    }
}
