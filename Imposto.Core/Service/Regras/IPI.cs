using Imposto.Core.Domain;
using System;

namespace Imposto.Core.Service.Imposto
{
    public class IPI : IRegra
    {
        public void Calcula(PedidoItem pedidoItem, Pedido pedido, NotaFiscalItem notaFiscalItem)
        {
            notaFiscalItem.BaseIpi = pedidoItem.ValorItemPedido;

            if (pedidoItem.Brinde)
                notaFiscalItem.AliquotaIpi = 0;
            else
                notaFiscalItem.AliquotaIpi = 10;

            notaFiscalItem.ValorIpi = notaFiscalItem.BaseIpi * (notaFiscalItem.AliquotaIpi / 100);

            //return notaFiscalItem;
        }

        public string Realiza(string estadoOrigem, string estadoDetino)
        {
            throw new NotImplementedException();
        }
    }
}
