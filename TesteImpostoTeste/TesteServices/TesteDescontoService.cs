using Imposto.Core.Domain;
using Imposto.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TesteImpostoTeste
{
    public class TesteDescontoService
    {
        DescontoService descontoservice = new DescontoService();

        [Fact]
        public void RealizaDescontoSeSudeste()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem();

            pedidoItem.ValorItemPedido = 1000;

            descontoservice.RealizarDesconto(notaFiscalItem, pedidoItem, "SP");

            Assert.Equal(100, notaFiscalItem.Desconto);
        }
    }
}
