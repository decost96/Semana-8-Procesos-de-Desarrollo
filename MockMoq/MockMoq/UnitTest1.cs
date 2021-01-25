using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace MockMoq
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var especie = new Mock<ISerVivo>();
            especie.SetupGet(p => p.Nombre).Returns("Juan");
            especie.SetupGet(p => p.Edad).Returns(18);
            especie.SetupGet(p => p.Especie).Returns("Humano");
            Assert.AreEqual("Juan", especie.Object.Nombre);
            Assert.AreEqual(18, especie.Object.Edad);
            Assert.AreEqual("Humano", especie.Object.Especie);

            string mensaje = "Mi nombre es: " + especie.Object.Nombre + ". tengo " + especie.Object.Edad + ". años de edad y soy un " + especie.Object.Especie + ".";
            Console.WriteLine(mensaje);
        }
    }
}
