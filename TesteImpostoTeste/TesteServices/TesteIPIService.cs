using System;
using System.Collections.Generic;
using System.Text;
using Imposto.Core.Domain;
using Imposto.Core.Service;
using Xunit;

namespace TesteImpostoTeste.TesteServices
{
    public class TesteIPIService
    {
        IPIService ipiservice = new IPIService();
        [Fact]
        public void RealizaIPISemBrinde()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();

            PedidoItem pedidoItem = new PedidoItem();

            pedidoItem.Brinde = false;
            pedidoItem.ValorItemPedido = 1000;

            ipiservice.RealizaIPI(notaFiscalItem, pedidoItem);

            Assert.Equal(1000, notaFiscalItem.BaseIpi);
            Assert.Equal(10, notaFiscalItem.AliquotaIpi);
            Assert.Equal(100, notaFiscalItem.ValorIpi);

        }
        [Fact]
        public void RealizaIPIComBrinde()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();

            PedidoItem pedidoItem = new PedidoItem();

            pedidoItem.Brinde = true;
            pedidoItem.ValorItemPedido = 1000;
            
            ipiservice.RealizaIPI(notaFiscalItem, pedidoItem);

            Assert.Equal(1000, notaFiscalItem.BaseIpi);
            Assert.Equal(0, notaFiscalItem.AliquotaIpi);
            Assert.Equal(0, notaFiscalItem.ValorIpi);
        }
    }
}
