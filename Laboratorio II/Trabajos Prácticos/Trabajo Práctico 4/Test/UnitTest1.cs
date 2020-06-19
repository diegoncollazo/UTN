using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InstanciaDeCorreo()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingiDRepetidoException))]
        public void PaqueteRepetido()
        {
            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("Juan Alberdi", "1551-111-555");
            Paquete paqueteDos = new Paquete("Jose Alberdi", "1551-111-555");
            correo += paqueteUno;
            correo += paqueteDos;
        }
    }
}
