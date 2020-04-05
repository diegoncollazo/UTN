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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        #region Métodos de Formulario
        /// <summary>
        /// Botón para Operar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)).ToString();
            btnBinario.Enabled = true;
            btnDecimal.Enabled = false;
        }
        /// <summary>
        /// Botón para limpiar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Botón para el cierre del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }
        /// <summary>
        /// Boton binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBinario_Click(object sender, EventArgs e)
        {
            /*Controlo el resultado de la conversión a binario y habilito o no el boton "Convertir a decimal*/
            string resultado = Numero.DecimalABinario(lblResultado.Text);
            if (resultado != "Valor inválido")
                btnDecimal.Enabled = true;
            lblResultado.Text = resultado;
            btnBinario.Enabled = false;
        }
        /// <summary>
        /// Boton decimal a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioADecimal(lblResultado.Text);
            btnBinario.Enabled = true;
            btnDecimal.Enabled = false;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Funcion privada y estática para realizar calculos.
        /// </summary>
        /// <param name="numero1">Numero para operar</param>
        /// <param name="numero2">Numero para operar</param>
        /// <param name="operador">Tipo de operador</param>
        /// <returns>Retorno resultado de operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            //Instancio los operadores con valores string
            Numero operando1 = new Numero(numero1);
            Numero operando2 = new Numero(numero2);
            //Retorno directamente la operacion solicitada
            return Calculadora.Operar(operando1, operando2, operador);
        }
        /// <summary>
        /// Método para limpiar el formulario.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();
            lblResultado.ResetText();
            btnBinario.Enabled = false;
            btnDecimal.Enabled = false;
        }
        #endregion
    }
}
