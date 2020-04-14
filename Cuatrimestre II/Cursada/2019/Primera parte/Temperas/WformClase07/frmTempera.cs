using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase06;

namespace WformClase07
{
    public partial class frmTempera : Form
    {
        //Constructor para agregar.
        public frmTempera()
        {
            InitializeComponent();
            //Inicializo el comboBox, con todos los colores.
            foreach(ConsoleColor item in Enum.GetValues(typeof(ConsoleColor)))
                cmbColor.Items.Add(item);            
            this.cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;//Inhabilita edición del comboBox.
            this.cmbColor.SelectedItem = ConsoleColor.Blue;//Color por defecto.
        }
        //Constructor para borrar.
        public frmTempera(Tempera tempera, bool opcion) : this() 
        {
            //Atributos Implicit se cargan en las variables.
            sbyte mySbyte = tempera;
            ConsoleColor myColor = tempera;
            txtMarca.Text = tempera;
            txtCantidad.Text = mySbyte.ToString();//Hay que convertirlo en string para poder mostrarlo
            cmbColor.Text = myColor.ToString();   //Hay que convertirlo en string para poder mostrarlo
            txtCantidad.Enabled = opcion;
            txtMarca.Enabled = opcion;
            cmbColor.Enabled = opcion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Tempera nuevaTempera = new Tempera((ConsoleColor)this.cmbColor.SelectedItem, txtMarca.Text, sbyte.Parse(txtCantidad.Text));
            this.tempera = nuevaTempera;
            this.DialogResult = DialogResult.OK;
        }

        //¿Modifica la clase?
        private Tempera tempera;
        public Tempera myTempera
        {
            get
            {
                return tempera;
            }
            set
            {
                tempera = value;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmTempera_Load(object sender, EventArgs e)
        {

        }
    }
}
