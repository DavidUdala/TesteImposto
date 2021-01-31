using Imposto.Core.Domain;
using Imposto.Core.Service;
using Imposto.Core.Service.Imposto;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TesteImpostoTeste.TesteServices
{
    public class TesteICMSService
    {
        ICMS ICMS = new ICMS();
        CFOP CFOP = new CFOP();

        [Fact]
        public void TesteRealizaICMSQuandoEstadosDiferentesECfopDiferenteDe6009()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem();
            Pedido pedido = new Pedido();

            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "MG";

            pedidoItem.ValorItemPedido = 1000.00;

            notaFiscalItem.Cfop = CFOP.Realiza("SP","MG");

            ICMS.Calcula(pedidoItem, pedido, notaFiscalItem);

            Assert.Equal("10" ,notaFiscalItem.TipoIcms);
            Assert.Equal(0.17, notaFiscalItem.AliquotaIcms );
            Assert.Equal(1000.00, notaFiscalItem.BaseIcms);
            Assert.Equal(170, notaFiscalItem.ValorIcms);
        }

        [Fact]
        public void TesteRealizaICMSQuandoEstadosSaoIguaisOuBrinde()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem();
            Pedido pedido = new Pedido();

            pedido.EstadoOrigem = "MG";
            pedido.EstadoDestino = "MG";

            pedidoItem.ValorItemPedido = 1000.00;

            notaFiscalItem.Cfop = CFOP.Realiza("MG", "MG");

            ICMS.Calcula(pedidoItem, pedido, notaFiscalItem);

            Assert.Equal("60", notaFiscalItem.TipoIcms);
            Assert.Equal(0.18, notaFiscalItem.AliquotaIcms);
            Assert.Equal(1000.00, notaFiscalItem.BaseIcms);
            Assert.Equal(180, notaFiscalItem.ValorIcms);
        }
        [Fact]
        public void TesteRealizaICMSQuandoCFOPIgualA6009ComBrindOuMesmoEstado()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem();
            Pedido pedido = new Pedido();

            pedido.EstadoOrigem = "MG";
            pedido.EstadoDestino = "SP";
            
            pedidoItem.ValorItemPedido = 1000.00;
            pedidoItem.Brinde = true;

            notaFiscalItem.Cfop = CFOP.Realiza("MG","SP");

            ICMS.Calcula(pedidoItem, pedido, notaFiscalItem);

            Assert.Equal("60", notaFiscalItem.TipoIcms);
            Assert.Equal(0.18, notaFiscalItem.AliquotaIcms);
            Assert.Equal(900, notaFiscalItem.BaseIcms);
            Assert.Equal(162, notaFiscalItem.ValorIcms);
        }
    }
}
