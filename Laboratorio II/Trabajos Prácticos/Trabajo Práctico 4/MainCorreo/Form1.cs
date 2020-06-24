using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        private Correo correo;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(textBoxDireccion.Text, maskedTextBox.Text);
            paquete.InformarEstado += paq_InformarEstado;
            try
            {
                correo += paquete;
            }
            catch (Exception exception)
            {
                MessageBox.Show("No se puede guardar el paquete. " + exception.Message);
            }
            finally
            {
                this.ActualizarEstados();
            }
        }
        public void ActualizarEstados()
        {
            listBoxEntregado.Items.Clear();
            listBoxEnViaje.Items.Clear();
            listBoxIngresado.Items.Clear();
            foreach (Paquete auxPaquete in correo.Paquetes)
                switch (auxPaquete.Estado)
                {
                    case Paquete.EEstado.Entregado:
                        listBoxEntregado.Items.Add(auxPaquete.ToString());
                        break;
                    case Paquete.EEstado.EnViaje:
                        listBoxEnViaje.Items.Add(auxPaquete.ToString());
                        break;
                    case Paquete.EEstado.Ingresado:
                        listBoxIngresado.Items.Add(auxPaquete.ToString());
                        break;
                }
        }
        private void paq_InformarEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformarEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.correo = new Correo();

        }
        private void buttonMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                this.richTextBox.Text = elemento.MostrarDatos(elemento);
                this.richTextBox.Text.Guardar("Salida.txt");
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox.Text = listBoxEntregado.SelectedItem.ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}
