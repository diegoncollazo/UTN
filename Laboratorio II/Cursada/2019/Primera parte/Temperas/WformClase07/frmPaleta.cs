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
    public partial class frmPaleta : Form
    {
        Paleta p; //Defino paleta

        public frmPaleta(sbyte cantidad)
        {
            InitializeComponent();
            this.p = cantidad;
        }

        public frmPaleta() : this(5)
        {
            
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            //Nuevo formulario tempera.
            frmTempera nuevaTempera = new frmTempera();
            nuevaTempera.Text = "Nueva tempera";
            nuevaTempera.StartPosition = FormStartPosition.CenterScreen;
            nuevaTempera.ShowDialog();
            //¿Agrega igualmente la tempera aunque sea nula?
            p += nuevaTempera.myTempera;
            RefrescarColores(nuevaTempera);
            //Validar para cuando llegue a 5 no puede ingresar mas
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            int indice = this.listBox1.SelectedIndex;//Paso el índice de la tempera seleccionada.
            btnMenos.Enabled = true;            
            frmTempera borrarTempera = new frmTempera(this.p.myTemperas[indice], false);
            borrarTempera.Text = "Eliminar tempera";
            borrarTempera.ShowDialog();
            if (borrarTempera.DialogResult == DialogResult.OK)
            {
                this.p -= borrarTempera.myTempera;
                RefrescarColores(borrarTempera);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Cuando se selecciona, se tiene que modificar
            int indice = this.listBox1.SelectedIndex;
            if (indice != -1)
            {
                frmTempera modificarTempera = new frmTempera(this.p.myTemperas[indice], true);
                modificarTempera.Text = "Modificar tempera";
                modificarTempera.ShowDialog();
                if (modificarTempera.DialogResult == DialogResult.OK)
                {
                    this.p.myTemperas[indice] = modificarTempera.myTempera;
                    RefrescarColores(modificarTempera);
                }
            }
        }

        private void RefrescarColores(frmTempera formulario)
        {
            int i = 0;
            listBox1.Items.Clear();
            foreach (Tempera t in p.myTemperas)
            {
                if (formulario.DialogResult == DialogResult.OK && t != null)
                {
                    listBox1.Items.Add(Tempera.Mostrar(t));
                    i++;
                }
            }
        }

    }
}
