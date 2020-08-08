using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//Agregar usings necesarios
using Entidades;
using System.IO;

namespace RSP.LabII._2020
{
    //Agregar manejo de excepciones en TODOS los lugares críticos!!!

    public partial class RSP : Form
    {
        private Zapato zapato;
        private Fosforo fosforo;
        private Remedio remedio;

        private Caja<Zapato> c_zapatos;
        private Caja<Fosforo> c_fosforos;
        private Caja<Remedio> c_remedios;

        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;

        public RSP()
        {
            InitializeComponent();

            this.dt = new DataTable("almacen");
            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;

            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //Cambiar por su apellido y nombre
        private void RSP_Load(object sender, EventArgs e)
        {
            this.Text = "Collazo Diego";
            MessageBox.Show(this.Text);          
        }

        //Crear, en un class library, las siguientes clases:
        //Zapato-> tipo:string (público); marca:string; (público); precio:float (público); 
        //ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
        //Fosforo-> tipo:string (público); marca:string; (público); precio:float (público); 
        //ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
        //Remedio-> tipo:string (público); marca:string; (público); precio:float (público); 
        //ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            //Crear una instancia de cada clase e inicializar los atributos del form zapato, fosforo y remedio. 
            this.zapato = new Zapato("Náutico", "Kickers", 500);
            this.fosforo = new Fosforo("Madera", "3 patitos", 65);
            this.remedio = new Remedio("Aspirina", "Bayer", 100);

            MessageBox.Show(this.zapato.ToString());
            MessageBox.Show(this.fosforo.ToString());
            MessageBox.Show(this.remedio.ToString());
        }

        //Crear, en class library, la clase Caja<T> 
        //atributos: capacidad:int y elementos:List<T> (TODOS protegidos)        
        //Propiedades:
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total de la caja (la suma de los precios de sus elementos).
        //Constructor
        //Caja(), Caja(int); 
        //El constructor por default es el único que se encargará de inicializar la lista.
        //Métodos:
        //ToString: Mostrará en formato de tipo string: 
        //el tipo de caja, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        //de todos los elementos contenidos en la misma. Reutilizar código.
        //Sobrecarga de operadores:
        //(+) Será el encargado de agregar elementos a la caja, 
        //siempre y cuando no supere la capacidad máxima de la misma.
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.c_zapatos = new Caja<Zapato>(3);
            this.c_fosforos = new Caja<Fosforo>(3);
            this.c_remedios = new Caja<Remedio>(2);

            this.c_zapatos += new Zapato("Mocasín", "Moscato", 850); 
            this.c_zapatos += new Zapato("Charol", "Carlota", 600); 
            this.c_zapatos += this.zapato;

            this.c_fosforos += this.fosforo;
            this.c_fosforos += new Fosforo("Cera", "Cerúmen", 50);

            this.c_remedios += this.remedio;
            this.c_remedios += this.remedio;

            MessageBox.Show(this.c_zapatos.ToString());
            MessageBox.Show(this.c_fosforos.ToString());
            MessageBox.Show(this.c_remedios.ToString());
        }

        //Agregar un elemento a la caja de zapatos, al superar la cantidad máxima, 
        //lanzará un CajaLlenaException (diseñarla), cuyo mensaje explicará lo sucedido.
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            try
            {
                this.c_zapatos += this.zapato;
            }
            catch (CajaLlenaException ex)
            {
                //Agregar, para la clase CajaLlenaException, un método de extensión (InformarNovedad():string)
                //que retorne el mensaje de error
                MessageBox.Show(ex.InformarNovedad());
            }
        }

        //Si el precio total de la caja supera los 120 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase caja. 
        //Adaptar la sobrecarga del operador +, para que lance el evento, según lo solicitado.
        //Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total de la caja (en un nuevo renglón). 
        //Se deben acumular los mensajes. 
        //El archivo se guardará con el nombre 'tickets.log' en la carpeta 'Mis documentos' del cliente.
        //El manejador de eventos (c_fosforos_EventoPrecio) invocará al método (de clase) 
        //ImprimirTicket (se alojará en la clase Ticketeadora), que retorna un booleano 
        //indicando si se pudo escribir o no.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            //Asociar manejador de eventos (c_fosforos_EventoPrecio) aquí     
            this.c_fosforos.EventoPrecio += new Caja<Fosforo>.DelegadoEventoPrecio(this.c_fosforos_EventoPrecio);

            this.c_fosforos += new Fosforo("Madera", "Fragata", 60);
        }

        private void c_fosforos_EventoPrecio(object sender, EventArgs e)
        {
            bool retorno = Ticketeadora.ImprimirTicket(this.c_fosforos);

            if (retorno)
                MessageBox.Show("Ticket impreso.");
            else
                MessageBox.Show("No se pudo imprimir el ticket.");
        }

        //Configurar el OpenFileDialog, para poder seleccionar el log de tickets
        private void btnVerLog_Click(object sender, EventArgs e)
        {
            //titulo -> 'Abrir archivo de tickets'
            //directorio por defecto -> Mis documentos
            //tipo de archivo (filtro) -> .log
            //extensión por defecto -> .log
            //nombre de archivo (defecto) -> tickets
            this.openFileDialog1.Title = "Abrir archivo de tickets";
            this.openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.openFileDialog1.Filter = ".log | *.log";
            this.openFileDialog1.DefaultExt = "log";
            this.openFileDialog1.FileName = "tickets";

            DialogResult rta = this.openFileDialog1.ShowDialog();//Reemplazar por la llamada al método correspondiente del OpenFileDialog

            if (rta == DialogResult.OK)
            {
                try
                {
                    FileInfo info = new FileInfo(this.openFileDialog1.FileName);
                    using (StreamReader sr = new StreamReader(info.DirectoryName + @"\" + info.Name))
                    {
                        this.txtVisorTickets.Text = sr.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Error");
                }
            }
        }

        //Crear las interfaces (en class library): 
        //#.-ISerializa -> Xml() : bool
        //              -> Path{ get; } : string
        //#.-IDeserializa -> Xml(out zapato) : bool
        //Implementar (implícitamente) ISerializa zapato
        //Implementar (explícitamente) IDeserializa en zapato
        //El archivo .xml guardarlo en el escritorio del cliente, con el nombre formado con su apellido.nombre.zapato.xml
        //Ejemplo: Alumno Juan Pérez -> perez.juan.zapato.xml
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            Zapato aux = null;

            if (this.zapato.Xml())
            {
                MessageBox.Show("Zapato serializado OK");
            }
            else
            {
                MessageBox.Show("Zapato NO serializado");
            }

            if (((IDeserializa)this.zapato).Xml(out aux))
            {
                MessageBox.Show("Zapato deserializado OK");
                MessageBox.Show(aux.ToString());
            }
            else
            {
                MessageBox.Show("Zapato NO deserializado");
            }
        }

        //Obtener de la base de datos (rsp_lab_II) el listado de elementos:
        //Tabla - elementos { id(autoincremental - numérico) - marca(cadena) - precio(numérico) - tipo(cadena) }.
        private void btnPunto6_Click(object sender, EventArgs e)
        {
            //Configurar el SqlConnection
            this.cn = new SqlConnection(Properties.Settings.Default.Conexion);

            //Configurar el SqlDataAdapter (y su selectCommand)     
            string comando = "SELECT * FROM [rsp_lab_II].[dbo].[elementos]";
            this.da = new SqlDataAdapter(comando, this.cn);

            this.da.Fill(this.dt);
            this.dataGridView1.DataSource = this.dt;
        }

        //Agregar en el dataTable los elementos del formulario (zapato, fosforo y remedio).
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            //Configurar el insertCommand del SqlDataAdapter y sus parametros
            string comando = "SELECT * FROM [rsp_lab_II].[dbo].[elementos] VALUES(@p1, @p2, @p3)";
            this.da.InsertCommand = new SqlCommand(comando, this.cn);

            this.da.InsertCommand.Parameters.Add("@p1", SqlDbType.VarChar, 50, "marca");
            this.da.InsertCommand.Parameters.Add("@p2", SqlDbType.Float, 10, "precio");
            this.da.InsertCommand.Parameters.Add("@p3", SqlDbType.VarChar, 50, "tipo");

            //Agregar los utiles del formulario al dataTable
            DataRow fila = this.dt.NewRow();

            fila[1] = this.zapato.marca;
            fila[2] = this.zapato.precio;
            fila[3] = "zapato";
            this.dt.Rows.Add(fila);

            fila = this.dt.NewRow();
            fila[1] = this.fosforo.marca;
            fila[2] = this.fosforo.precio;
            fila[3] = "fosforo";
            this.dt.Rows.Add(fila);

            fila = this.dt.NewRow();
            fila[1] = this.remedio.marca;
            fila[2] = this.remedio.precio;
            fila[3] = "remedio";
            this.dt.Rows.Add(fila);
        }

        //Eliminar del dataTable el primer registro
        private void btnPunto8_Click(object sender, EventArgs e)
        {
            //Configurar el deleteCommand del SqlDataAdapter y sus parametros
            this.da.DeleteCommand = new SqlCommand("DELETE FROM [rsp_lab_II].[dbo].[elementos] WHERE id = @p1", this.cn);

            this.da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int, 10, "id");
            //Borrar el primer registro del dataTable

            DataRow fila = this.dt.Rows[0];
            fila.Delete();
        }

        //Modificar del dataTable el último registro, cambiarlo por: marca:JohnFoos; precio:720
        private void btnPunto9_Click(object sender, EventArgs e)
        {
            //Configurar el updateCommand del SqlDataAdapter y sus parametros
            this.da.UpdateCommand = new SqlCommand("UPDATE [rsp_lab_II].[dbo].[elementos] SET marca = @p2, precio = @p3, tipo = @p4 WHERE id = @p1", this.cn);

            this.da.UpdateCommand.Parameters.Add("@p1", SqlDbType.Int, 10, "id");
            this.da.UpdateCommand.Parameters.Add("@p2", SqlDbType.VarChar, 50, "marca");
            this.da.UpdateCommand.Parameters.Add("@p3", SqlDbType.Float, 10, "precio");
            this.da.UpdateCommand.Parameters.Add("@p4", SqlDbType.VarChar, 50, "tipo");

            //Modificar el ultimo registro del dataTable

            this.dt.Rows[this.dt.Rows.Count - 1]["marca"] = "JohnFoos";
            this.dt.Rows[this.dt.Rows.Count - 1]["precio"] = 720;
        }

        //Sincronizar los cambios (sufridos en el dataTable) con la base de datos
        private void btnPunto10_Click(object sender, EventArgs e)
        {
            try
            {
                // Sincronizar el SqlDataAdapter con la DataBase
                this.da.Update(this.dt);
                MessageBox.Show("Datos sincronizados con éxito.");
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo sincronizar.\n" + error.Message);
            }
        }

        //Threads
        //Iniciar un nuevo hilo que ejecute los manejadores de eventos de los botones del formulario
        //(RSP_Load, btnPunto1_Click, y btnPunto2_Click)
        private void btnHilos_Click(object sender, EventArgs e)
        {

        }

        private void ProbarTodo()//para el thread
        {

        }

    }
}
