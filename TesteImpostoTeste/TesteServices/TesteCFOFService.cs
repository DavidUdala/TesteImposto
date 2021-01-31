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

            Assert.Equal("6.000", CFOP.Realiza("SP","RJ"));
        }
    }
}
