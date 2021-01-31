using Imposto.Core.Data;
using Imposto.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Imposto.Core.Service
{
    public class DescontoService
    {
        internal enum EstadosSudeste
        {
            SP,
            RJ,
            MG,
            ES
        }

        public void RealizarDesconto(NotaFiscalItem notaFiscalItem, PedidoItem pedidoItem, string estadoDestino)
        {
            EstadosSudeste getSudeste;

            bool chkDescontoSudeste =  EstadosSudeste.TryParse(estadoDestino, out getSudeste);

            if(chkDescontoSudeste)
                notaFiscalItem.Desconto = pedidoItem.ValorItemPedido * 0.1;
        }
    }
}
