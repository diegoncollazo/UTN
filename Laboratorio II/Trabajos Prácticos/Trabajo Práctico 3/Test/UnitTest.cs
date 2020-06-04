using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Test de coleccion no null.
        /// </summary>
        [TestMethod]
        public void UniversidadDefault()
        {
            //Arrange
            Universidad universidad = new Universidad();
            //Act
            List<Alumno> alumnos = universidad.Alumnos;
            //Assert
            Assert.IsNotNull(alumnos);
        }
        /// <summary>
        /// Test de excepcion de Nacionalidad.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalido()
        {
            _ = new Profesor(1810, "Juan Bautista", "Alberdi", "100000000", Persona.ENacionalidad.Argentino);
        }
        /// <summary>
        /// Test de excepcion de DNI.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalido()
        {
            _ = new Profesor(1811, "Domingo", "Sarmiento", "654f621", Persona.ENacionalidad.Argentino);
        }
        /// <summary>
        /// Test de atributos no null.
        /// </summary>
        [TestMethod]
        public void TestIsNotNull()
        {
            //Arrange + Act
            Profesor profesor = new Profesor(1843, "Julio", "Roca", "1", Persona.ENacionalidad.Argentino);
            
            //Assert
            Assert.IsNotNull(profesor.Apellido);
            Assert.IsNotNull(profesor.Nombre);
            Assert.IsNotNull(profesor.DNI);
            Assert.IsNotNull(profesor.Nacionalidad);
        }
        /// <summary>
        /// Test excepcion de Profesor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesor()
        {
            Universidad universidad = new Universidad();
            universidad += Universidad.EClases.Laboratorio;
        }
        /// <summary>
        /// Test añadir mismo alumno.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetido()
        {
            //Arrange
            Universidad universidad = new Universidad();
            Alumno alumno1 = new Alumno(1, "Roberto", "Gimenez", "92537186", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
            Alumno alumno2 = new Alumno(2, "Roberto", "Gimenez", "92537186", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
            //Assert
            universidad += alumno1;
            universidad += alumno2;
        }
        /// <summary>
        /// Test excepcion lectura de XML.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivo()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            _ = xml.Leer("UniversidadNoExite.xml", out Universidad universidad);
        }

    }
}