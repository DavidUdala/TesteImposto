using Imposto.Core.Domain;
using Imposto.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TesteImpostoTeste.TesteServices
{
    public class TesteICMSService
    {
        ICMSService srvICMS = new ICMSService();

        [Fact]
        public void TesteRealizaICMSQuandoEstadosDiferentesECfopDiferenteDe6009()
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem();

            pedidoItem.ValorItemPedido = 1000.00;
            new CFOFService().RealizaCFO(notaFiscalItem, "MG");

            srvICMS.RealizaICMS(notaFiscalItem,pedidoItem,"MG","SP");


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

            pedidoItem.ValorItemPedido = 1000.00;
            new CFOFService().RealizaCFO(notaFiscalItem, "MG");

            srvICMS.RealizaICMS(notaFiscalItem, pedidoItem, "MG", "MG");

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

            pedidoItem.ValorItemPedido = 1000.00;
            new CFOFService().RealizaCFO(notaFiscalItem, "SP");

            srvICMS.RealizaICMS(notaFiscalItem, pedidoItem, "SP", "SP");

            Assert.Equal("60", notaFiscalItem.TipoIcms);
            Assert.Equal(0.18, notaFiscalItem.AliquotaIcms);
            Assert.Equal(900, notaFiscalItem.BaseIcms);
            Assert.Equal(162, notaFiscalItem.ValorIcms);
        }
        [Fact]
        public void TesteRealizaICMSQuandoCFOPIgualA6009SemBrindOuDiferenteEstado()
        {

            NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
            PedidoItem pedidoItem = new PedidoItem();

            pedidoItem.ValorItemPedido = 1000.00;
            new CFOFService().RealizaCFO(notaFiscalItem, "SP");

            srvICMS.RealizaICMS(notaFiscalItem, pedidoItem, "SP", "RJ");

            Assert.Equal("10", notaFiscalItem.TipoIcms);
            Assert.Equal(0.17, notaFiscalItem.AliquotaIcms);
            Assert.Equal(900, notaFiscalItem.BaseIcms);
            Assert.Equal(153, notaFiscalItem.ValorIcms);
        }


    }
}
