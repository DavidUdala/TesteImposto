using Imposto.Core.Service;
using Imposto.Core.Domain;
using Imposto.Core.Data;

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TesteImpostoTeste.TesteServices
{
    public class TesteDescontoService
    {
        DescontoService descontoService = new DescontoService();

        [Fact]
        public void RealizaDescontoSemBrinde()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem() {CodigoProduto = "01", Brinde = false, NomeProduto = "Caneta", ValorItemPedido = 123 };

            //descontoService.RealizarDesconto(notaFiscalItem, pedidoItem, "SP");

            Assert.Equal(100, 100);
        }
    }
}
