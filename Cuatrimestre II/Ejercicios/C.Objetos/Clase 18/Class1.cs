using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Punto
    {
        private int x;
        private int y;
        //Constructor
        public Punto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        //Getters
        public int GetX {
            get
            {
                return this.x;
            }
        }
        public int GetY
        {
            get
            {
                return this.y;
            }
        }
    }
    public class Rectangulo
    {
        private float area;
        private float perimetro;
        private Punto vertice1;
        private Punto vertice2;
        private Punto vertice3;
        private Punto vertice4;

        public Rectangulo(Punto vertice1, Punto vertice3)
        {
            this.vertice1 = vertice1;
            this.vertice3 = vertice3;
        }

        public float Area()
        {

            return 0;
        }

        public float Perimetro()
        {
            Math.Abs();
            this.vertice1.GetX;

            return 0;
        }

        
    }
}

namespace PruebGeometria
{

}
