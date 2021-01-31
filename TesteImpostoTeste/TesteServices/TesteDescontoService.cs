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
        public void RealizaDescontoSeEstadoSudeste()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem();
            pedidoItem.ValorItemPedido = 1000;

            descontoService.RealizarDesconto(notaFiscalItem, pedidoItem, "SP");

            Assert.Equal(100, notaFiscalItem.Desconto);
        }
        [Fact]
        public void RealizaDescontoSeEstadoNaoForSudeste()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem();
            pedidoItem.ValorItemPedido = 1000;

            descontoService.RealizarDesconto(notaFiscalItem, pedidoItem, "PE");

            Assert.Equal(0, notaFiscalItem.Desconto);
        }
    }
}
