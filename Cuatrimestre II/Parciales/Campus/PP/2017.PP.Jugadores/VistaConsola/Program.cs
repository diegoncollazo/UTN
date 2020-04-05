using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace VistaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorTecnico directorTecnico = new DirectorTecnico("Jorge", "Habbeger");
            Equipo miEquipo = new Equipo("Huracán de San Rafael Futbol", directorTecnico);
            Jugador Jugador1 = new Jugador("Fernandi", "Pandolfi", false, 11);
            Jugador Jugador2 = new Jugador("Julio", "Marchant", false, 8);
            Jugador Jugador3 = new Jugador("Ezequiel", "Medran", false, 12);
            Jugador Jugador4 = new Jugador("José", "Perada", false, 24);

            miEquipo += Jugador1;
            miEquipo += Jugador2;
            miEquipo += Jugador3;
            miEquipo += Jugador4;

            Console.WriteLine(miEquipo);

            
            Console.ReadKey();
        }
    }
}
