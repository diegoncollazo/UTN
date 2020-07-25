namespace Events
{
    public class Articulo
    {
        private string titulo;
        private string contenido;

        public string Titulo
        {
            get
            {
                return this.titulo;
            }
        }
        public string Contenido
        {
            get
            {
                return this.contenido;
            }
        }

        public Articulo(string titulo, string contenido)
        {
            this.titulo = titulo;
            this.contenido = contenido;
        }
    }
}
