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

namespace WindowsForms
{
    public partial class FrmListado : Form
    {
        private List<Persona> _personas;
        private DataTable _tabla;

        public FrmListado()
        {
            InitializeComponent();
        }

        private void FrmListado_Load(object sender, EventArgs e)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this._personas = accesoDatos.TraerTodo();
            this._tabla = accesoDatos.TraerTablaPersona();

            dataGridView1.DataSource = this._tabla;

        }
    }
}
