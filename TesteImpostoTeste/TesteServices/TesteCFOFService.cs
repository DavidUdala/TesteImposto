using Imposto.Core.Domain;
using Imposto.Core.Service;
using Xunit;

namespace TesteImpostoTeste
{
    public class TesteCFOFService
    {
        [Fact]
        public void RealizaCFOSeOrigemCorreta()
        {
            string cfop = new CFOFService().RealizaCFO("SP","RJ");

            Assert.Equal("6.000", cfop);
        }
    }
}
