using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//System.IO nos deja escribir en archivos de texto de manera sencilla y no como en C

namespace Clase_15
{
    public partial class FrmPrincipal : Form
    {
        string path = "";

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //Solo se configura el buscar en el LOAD 

            this.Buscar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //Establezco el directorio inicial
            this.Buscar.Title = "Seleccione un archivo"; //Titulo de la ventana
            this.Buscar.Multiselect = true; //Para que pueda seleccionar mas de un archivo
            this.Buscar.DefaultExt = ".txt"; //NO SE QUE HACE!!
            this.Buscar.AddExtension = true; //Supuestamente tiene que mostrar la extension del archivo
            this.Buscar.Filter =  "Archivos *.txt|*.TXT"; //Solo muestra las extensiones .txt
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {
            //path = AppDomain.CurrentDomain.BaseDirectory + @"\miArchivo.txt";
            //path = @"C:\Users\alumno\Desktop\miArchivo.txt";
            //path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\miArchivo.txt";

            //StreamReader lectura = new StreamReader(path, true);
            this.lstVisor.Items.Clear();

            if (path != "")
            {
                StreamReader lectura = new StreamReader(path, true);
                this.lstVisor.Items.Add(lectura.ReadLine()); 

                while(!lectura.EndOfStream)
                {
                    this.lstVisor.Items.Add(lectura.ReadLine());
                }

                lectura.Close();
            }

            else
            {
                MessageBox.Show("No se ha seleccionado una ruta valida");
            }

            //lectura.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try //Tiene que estar adentro de un try porque
            {
                
                //path = AppDomain.CurrentDomain.BaseDirectory + @"\miArchivo.txt"; //Devuelve la carpeta donde esta el proyecto
                //path = @"C:\Users\alumno\Desktop\miArchivo.txt"; Solo lo podria gusardar en mi maquina sin pasarlo a otra
                //path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\miArchivo.txt"; //Podria ser en cualquier maquina

                if(path != "")
                {
                    StreamWriter escritura = new StreamWriter(path, true);
                    string valor = this.txtValor.Text; //Paso el valor del texto, lo que se va a escribir a un atributo
                    escritura.WriteLine("{0}", valor); //Una vez que recibe el valor lo copia en miArchivo.txt
                    escritura.Close();//Una vez que termina de escribir o leer se tiene que cerrar
                }

                else
                {
                    MessageBox.Show("No se ha seleccionado una ruta valida. ");
                }

                //Parametros de StreamWrite(path, append)
                //Path(donde se guarda el texto), Append(true agrega informacion, false sobreescribe)
                //"@" Indica que ningun caracter de a cadena sera de escap
            }

            //Si hay alguna excepcion apararecera algun error
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                /*Los errores que pueden salir son:
                 * Puede suceder que no tenga permiso para el path
                 * Que el path no exista
                 * Que la longitud supera 200 caracteres
                 */ 
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(this.Buscar.ShowDialog() == DialogResult.OK)//Si da cancelar lo cierra
            {
                path = this.Buscar.FileName; //Selecciona el archivo
                MessageBox.Show(this.Buscar.FileName); //Devuelve el path de donde esta en archivo
            }
        }

    }
}
