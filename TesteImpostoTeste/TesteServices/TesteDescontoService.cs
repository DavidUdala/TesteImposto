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
        Desconto desconto = new Desconto();

        [Fact]
        public void RealizaDescontoSeEstadoSudeste()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem();
            Pedido pedido = new Pedido();

            pedido.EstadoDestino = "SP";
            pedidoItem.ValorItemPedido = 1000;

            desconto.Calcula(pedidoItem, pedido, notaFiscalItem);

            Assert.Equal(100, notaFiscalItem.Desconto);
        }
        [Fact]
        public void RealizaDescontoSeEstadoNaoForSudeste()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem();
            Pedido pedido = new Pedido();

            pedido.EstadoDestino = "PE";
            pedidoItem.ValorItemPedido = 1000;

            desconto.Calcula(pedidoItem, pedido, notaFiscalItem);

            Assert.Equal(0, notaFiscalItem.Desconto);
        }
    }
}
