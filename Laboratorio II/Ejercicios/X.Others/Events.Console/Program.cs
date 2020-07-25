using System;

namespace Events
{
    class Program
    {
        // Program es la clase RECEPTORA
        static void Main(string[] args)
        {
            Blog<Articulo> blogJuegos = new Blog<Articulo>("Juegos", ConsoleColor.Magenta);
            Blog<Articulo> blogProgramacion = new Blog<Articulo>("Programacion", ConsoleColor.Red);

            // Agrego al EVENTO el MANEJADOR
            blogJuegos.ArticuloGenerado += ImprimirArticulo;
            // Agrego al EVENTO el MANEJADOR
            blogProgramacion.ArticuloGenerado += ImprimirArticulo;

            Console.ReadKey();
        }
        // Manejador (se declara en la clase RECEPTORA).
        private static void ImprimirArticulo(string contenido, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(contenido);
        }
    }
}
