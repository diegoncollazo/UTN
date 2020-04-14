using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.Estacionamientos.starter;

namespace UnitTest_Estacionamiento
{
    [TestClass] //Es una clase que sive para generar testeo unitarios
    public class UnitTest1
    {
        [TestMethod] //Permite hacer metodos unitarios
        public void TestMethod1()
        {
            //Assert: Posee varios metodos static, que permite hacer distintos tipos de evaluaciones
            Estacionamiento estacionamiento = new Estacionamiento(5);

            //Verifica que la lista sea distinta de null
            Assert.IsNotNull(estacionamiento.Autos);
        }

        [TestMethod]
        public void EspacioEstacionamientoIncorrecto()
        {
            Estacionamiento estacionamiento = new Estacionamiento(101);
            Estacionamiento estacionamiento2 = new Estacionamiento(0);

            //MANERA INCORRECTA
            if (estacionamiento.EspacioDisponible != 101) //Tambien el tester puede estar mal no solo el codigo
            {
                Assert.Fail(" El espacio es incorrecto {0}", estacionamiento.EspacioDisponible);
            }

            //Chequea entre dos valores si son o no iguales
            Assert.AreNotEqual(estacionamiento2.EspacioDisponible, 1);

            if (estacionamiento2.EspacioDisponible != 0)
            {
                Assert.Fail(" El espacio es incorrecto {0}", estacionamiento2.EspacioDisponible);
            }
        }

        [TestMethod]
        public void AgregarAutosEstacionamiento()
        {
            Estacionamiento estacionamiento = new Estacionamiento(2);
            Auto autoUno = new Auto("ABD 456", ConsoleColor.Black);
            Auto autoDos = new Auto("HJK 486", ConsoleColor.Cyan);
            Auto autoTres = new Auto("KLO 152", ConsoleColor.DarkMagenta);

            try
            {
                estacionamiento += autoUno;
                estacionamiento += autoDos;
                estacionamiento += autoTres;
                Assert.Fail(" Pudo agregar 3 autos");
            }

            catch (Exception exception)
            {
                //Es con exception general, SIEMPRE
                Assert.IsInstanceOfType(exception, typeof(EstacionamientoLlenoException));
            }
        }

        [TestMethod]
        public void AgregarAutoEspacioDisponible()
        {
            Estacionamiento estacionamiento = new Estacionamiento(2);
            Auto autoUno = new Auto("JKO 486", ConsoleColor.DarkGreen);
            Auto autoDos = new Auto("PLO 695", ConsoleColor.Magenta);

            estacionamiento += autoUno;
            Assert.AreEqual(estacionamiento.EspacioDisponible, 1);

            estacionamiento += autoDos;
            Assert.AreEqual(estacionamiento.EspacioDisponible, 0);
        }
    }
}
