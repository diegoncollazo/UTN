using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LoremNET;

namespace Events
{
    public class Blog<T> where T: Articulo
    {
        // Blog es la clase EMISORA

        // Delegado
        public delegate void ArticuloGeneradoEventHandler(string contenido, ConsoleColor color);
        // Evento (se declara en la clase EMISORA).
        public event ArticuloGeneradoEventHandler ArticuloGenerado;

        private List<T> articulos;
        private string nombre;
        private ConsoleColor color;
        private Thread hilo;
        
        public Blog(string nombre, ConsoleColor color)
        {
            this.articulos = new List<T>();
            this.nombre = nombre;
            this.color = color;
            //this.hilo = new Thread(new ThreadStart(this.GenerarArticuloRandom));
            /* Instancia un delegado asociado con el metodo */
            this.hilo = new Thread(this.GenerarArticuloRandom);
            this.hilo.Start();
        }

        private void GenerarArticuloRandom()
        {
            while (true)
            {
                Thread.Sleep((int)Lorem.Number(3000, 10000));
                StringBuilder builder = new StringBuilder();
                // Coleccion de strings
                IEnumerable<string> parrafos = Lorem.Paragraphs(13, 4, 5);
                string titulo = Lorem.Words(1, 5, true, false);

                foreach (string item in parrafos)
                {
                    builder.AppendLine(item);
                }
                // Nuevo Articulo.
                Articulo articulo = new Articulo(titulo , builder.ToString());
                // Agrego el Articulo a la coleccion.
                this.articulos.Add((T)articulo);
                // Metodo que lanza el evento
                this.GenerarNovedad(articulo); 
            }
        }
        private void GenerarNovedad(Articulo articulo)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(DateTime.Now.ToString("dd/MM - HH:mm:ss"));
            builder.AppendLine($"------------------ BLOG {this.nombre} || NOVEDAD #{this.articulos.Count} ------------------");
            builder.AppendLine($"{articulo.Titulo.ToUpper()}");
            builder.AppendLine();
            builder.AppendLine(articulo.Contenido);
            // Lanzo el EVENTO, compruebo que el evento se "ESTE" escuchando.
            if (this.ArticuloGenerado != null)
            {
                this.ArticuloGenerado.Invoke(builder.ToString(), this.color);
            }
        }
    }
}
