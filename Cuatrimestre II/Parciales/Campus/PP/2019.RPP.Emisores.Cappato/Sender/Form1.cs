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

namespace Sender
{
    public partial class FrmSender : Form
    {
        public FrmSender()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Emisor.EProducto producto;
            Enum.TryParse(this.comboBoxProductos.SelectedItem.ToString(), out producto);

            this.comboBoxProductos.DataSource = Enum.GetNames(typeof(Emisor.EProducto));
        }
    }
}
