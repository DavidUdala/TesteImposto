using Imposto.Core.Domain;
using Imposto.Core.Service;
using Xunit;

namespace TesteImpostoTeste
{
    public class TesteCFOFService
    {
        [Fact]
        public void TesteRealizaCFO()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();

            new CFOFService().RealizaCFO(notaFiscalItem,"RJ");

            Assert.Equal("6.000", notaFiscalItem.Cfop);
        }
    }
}
