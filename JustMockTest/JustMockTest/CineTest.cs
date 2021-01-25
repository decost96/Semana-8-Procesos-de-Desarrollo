using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace JustMockTest
{
    [TestClass]
    public partial class CineTest
    {
        [TestMethod]
        public void SiHayEntradasLibresPuedesAccederAComprarTickets()
        {
            string pelicula = "La Vida es Bella";
            var cine = Mock.Create<ICine>();
            cine.Arrange(cine1 => cine1.ButacasLibres(pelicula)).Returns(new List<string> { "E1", "E2" });
            int cantidadEntradas = 2;


            Persona persona = new Persona();
            persona.CompraEntradas(cine, cantidadEntradas, pelicula);

            Assert.IsTrue(persona.ObtuvoEntradas);
            cine.Assert(cine1 => cine1.ButacasLibres(pelicula));
            cine.Assert(cine1 => cine1.Descargar(pelicula, cantidadEntradas));

        }

        [TestMethod]
        public void DadoQueNoHayButacasCuandoComproEntradasEntoncesNoSeReservoButacas()
        {
            string pelicula = "La vida es Bella";
            int cantidadEntrda = 2;

            var cine = Mock.Create<ICine>();
            cine.Arrange(cineN => cineN.ButacasLibres(pelicula)).Returns(0);

            Persona persona = new Persona();
            persona.CompraEntradas(cine, cantidadEntrda, pelicula);

            Assert.IsFalse(persona.ObtuvoEntradas);
            cine.Assert(cineN => cineN.ButacasLibres(pelicula));

        }

        [TestMethod]
        public void DadoQueNoHayButacasCuandoComproEntradasEntoncesNoSeReservoButacas()
        {
            string pelicula = "La vida es Bella";
            int cantidadEntrda = 2;
            int entradasDisponibles = 5;

            var cine = Mock.Create<ICine>();
            cine.Arrange(cineN => cineN.ButacasLibres(pelicula)).Returns(entradasDisponibles);
            cine.Arrange(cineN => cineN.Descargar(pelicula)).Returns(entradasDisponibles);

            Persona persona = new Persona();
            persona.CompraEntradas(cine, cantidadEntrda, pelicula);

            Assert.IsFalse(persona.ObtuvoEntradas);
            cine.Assert(cineN => cineN.ButacasLibres(pelicula));

        }


        [TestMethod]
        public void DadoQueNoHayTodasButacasQueQuieroCuandoComproConsiguoSoloUna()
        {
            string pelicula = "La vida es Bella";
            int cantidadEntrda = 2;
            int entradasDisponibles = 5;
            int entradasEsperadas = 1;

            var cine = Mock.Create<ICine>();
            cine.Arrange(cineN => cineN.ButacasLibres(pelicula)).Returns(entradasDisponibles);
            cine.Arrange(cineN => cineN.Descargar(pelicula)).Returns(entradasDisponibles);

            Persona persona = new Persona();
            persona.CompraEntradas(cine, cantidadEntrda, pelicula);

            Assert.IsFalse(persona.ObtuvoEntradas);
            Assert.AreEqual(entradasEsperadas, persona.Entradas.Count);
            cine.Assert(cineG => cineG.ButacasLibres(pelicula));
            cine.Assert(cineG => cineG.Descargar(pelicula, entradasEsperadas));

        }
    }
}


