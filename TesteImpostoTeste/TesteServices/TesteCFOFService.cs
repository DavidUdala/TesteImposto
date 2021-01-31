using Imposto.Core.Domain;
using Imposto.Core.Service;
using Imposto.Core.Service.Imposto;
using Xunit;

namespace TesteImpostoTeste
{
    public class TesteCFOFService
    {
        CFOP CFOP = new CFOP();

        [Fact]
        public void RealizaCFOSeOrigemCorreta()
        {
            Pedido pedido = new Pedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            NotaFiscalItem notaFiscalItem = CFOP.Realiza(pedido);

            Assert.Equal("6.000", notaFiscalItem.Cfop);
        }
    }
}
