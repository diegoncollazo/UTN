using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDos
{
    public partial class frmTestDos : Form
    {
        public frmTestDos()
        {
            InitializeComponent();

            this.Load += new EventHandler(this.Inicializar);
            
        }

        public void Inicializar(object sender, EventArgs e)
        {

            this.btnBotonUno.Click += new EventHandler(this.MiManejador);

        }

        public void MiManejador(object sender, EventArgs e)
        {

            string s = ((Button)sender).Name;
            MessageBox.Show(s);

            if(s == "btnBotonUno")
            {
                this.btnBotonUno.Click -= new EventHandler(this.MiManejador);
                this.btnBotonDos.Click += new EventHandler(this.MiManejador);
            }
            else if(s == "btnBotonDos")
            {
                this.btnBotonDos.Click -= new EventHandler(this.MiManejador);
                this.btnBotonTres.Click += new EventHandler(this.MiManejador);
            }
            else
            {
                this.btnBotonTres.Click -= new EventHandler(this.MiManejador);
                this.btnBotonUno.Click += new EventHandler(this.MiManejador);
            }
       
        }

        public static void Sumar(int a,  int b)
        {
            a += b;
            MessageBox.Show(a.ToString());
        }

        public void Restar(int a, int b)
        {
            a -= b;
            MessageBox.Show(a.ToString());
        }

        public void Multiplicar (int a , int b)
        {
            a = a * b;
            MessageBox.Show(a.ToString());
        }

        public void OtraSuma(MiDelegado delegado,int a,int b)
        {
            delegado.Invoke(a, b);
        }

        private void brnOperar_Click(object sender, EventArgs e)
        {
            MiDelegado del = new MiDelegado(Sumar);
            //del.Invoke(3, 2);
            MiDelegado del2 = new MiDelegado(this.Restar);
            //del2(5, 2);
            MiDelegado del3 = (MiDelegado)MiDelegado.Combine(del, del2);
            del3.Invoke(10, 5);

            //MessageBox.Show(del3.Target.ToString());
            
            //MessageBox.Show(del3.Method.ToString());

            //foreach(MiDelegado d in del3.GetInvocationList())
            //{
            //    MessageBox.Show(d.Method.ToString());
            //}

            MiDelegado del4 = (MiDelegado)MiDelegado.Combine(del3, new MiDelegado(Multiplicar));
            del4.Invoke(5, 5);

            MiDelegado2 del5 = new MiDelegado2(OtraSuma);
            del5.Invoke(del, 8, 10);
        }
    }
}
