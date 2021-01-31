using Imposto.Core.Data;
using Imposto.Core.Domain;
using Imposto.Core.Service.Imposto;
using System.Collections.Generic;
using System.Linq;

namespace Imposto.Core.Service
{
    public class Desconto : IRegra
    {
        internal enum EstadosSudeste
        {
            SP, RJ, MG, ES
        }

        public NotaFiscalItem Calcula(PedidoItem pedidoItem, Pedido pedido, NotaFiscalItem notaFiscalItem)
        {
            EstadosSudeste getSudeste;

            bool chkDescontoSudeste = EstadosSudeste.TryParse(pedido.EstadoDestino, out getSudeste);

            if (chkDescontoSudeste)
                notaFiscalItem.Desconto = pedidoItem.ValorItemPedido * 0.1;

            return notaFiscalItem;
        }

        public NotaFiscalItem Realiza(Pedido pedido)
        {
            throw new System.NotImplementedException();
        }
    }
}
