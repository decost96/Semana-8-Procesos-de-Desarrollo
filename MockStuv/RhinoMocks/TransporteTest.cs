using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoMocks
{
    [TestClass]
    public class TransporteTest
    {
        [TestMethod]
        public void SiElTRansporteEstaLlenoLaMitadOMasPuedePartirMock()
        {
            var transporte = MockRepository.GenerateStub<ITransporte>();
            transporte.Stub(t => t.PorcentajeCarga()).Return(0.5);

            var mercaderia = new Mercancia();
            mercaderia.Peso = 15;
            mercaderia.Enviar(transporte);

            Assert.IsTrue(mercaderia.SeEnvio);
            transporte.AssertWasCalled(t => t.PorcentajeCarga());
            transporte.AssertWasCalled(t => t.Cargar(mercaderia.Peso));
        }

        [TestMethod]
        public void SiElTransporteEstaLlenoLaMitadOMasPuedePartir()
        {
            var transporte = new Transporte();
            transporte.Capacidad = 100 ; 
            transporte.Cargar(500);

            var mercaderia = new Mercancia();
            mercaderia.Peso = 15;
            mercaderia.Enviar(transporte);

            Assert.IsTrue(mercaderia.SeEnvio);
        }

        [TestMethod]
        public void SiLaCargaExedeLaCapacidadDelTransporteNoPuedePartir()
        {
            var transporte = new Transporte();
            transporte.Capacidad = 400;
            transporte.Cargar(500);

            var mercaderia = new Mercancia();
            mercaderia.Peso = 15;
            mercaderia.Enviar(transporte);

            Assert.IsTrue(mercaderia.SeEnvio);
        }
    }
}
