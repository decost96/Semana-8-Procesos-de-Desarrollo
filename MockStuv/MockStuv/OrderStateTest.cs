using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MockStub
{
    [TestClass]
    public class OrderStateTest
    {
        const string JugoMora = "Jugo de Mora";
        const string JugoGuanabana = "Jugo de Guanabana";
        Bodega bodega = new Bodega();

        [TestMethod]
        public void LaOrdenSeLlenaSiHaySuficienteEnLaBodega()
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
