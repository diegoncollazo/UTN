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
            Paquete paqueteUno = new Paquete("Marco Avellaneda", "1532-254-240");
            Paquete paqueteDos = new Paquete("Jose Leon Suarez", "1532-254-240");
            correo += paqueteUno;
            correo += paqueteDos;
        }

    }
}
