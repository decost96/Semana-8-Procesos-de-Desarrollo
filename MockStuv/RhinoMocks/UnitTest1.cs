using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;

namespace RhinoMocks
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LaOrdenSeLLenSiHaySuficienteEnLaBodega()
        {
            const string JugoMora = "Jugo de Mora";
            const string JugoGuanabana = "Jugo de Guanabana";
            var bodega = MockRepository.GenerateMock<Bodega>();

            Bodega bodega = new Bodega();

            {
                int existenciaJugoMora = 0;
                bodega.Add(JugoMora, 50);

                Pedido pedido = new Pedido(JugoMora, 50);
                pedido.Llenar(bodega);

                Assert.IsTrue(pedido.SeLleno);
                Assert.AreEqual(existenciaJugoMora, bodega.Existencia(JugoMora));

            }
        }
    }
}
