using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiLavadero
{
    public partial class frmLavadero : Form
    {
        public frmLavadero()
        {
            InitializeComponent();
        }

        private void nuevoVehículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehículo nuevoVehiculo = new frmVehículo();
            nuevoVehiculo.MdiParent = this;
            nuevoVehiculo.StartPosition = FormStartPosition.CenterScreen;
            nuevoVehiculo.Show();
        }
    }
}
