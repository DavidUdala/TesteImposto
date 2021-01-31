using Imposto.Core.Domain;

namespace Imposto.Core.Service.Imposto
{
    public class ICMS : IRegra
    {
        public NotaFiscalItem Calcula(PedidoItem pedidoItem, Pedido pedido, NotaFiscalItem notaFiscalItem)
        {

            if (pedidoItem.Brinde || pedido.EstadoOrigem.Equals(pedido.EstadoDestino))
            {
                notaFiscalItem.TipoIcms = "60";
                notaFiscalItem.AliquotaIcms = 0.18;
            }
            else
            {
                notaFiscalItem.TipoIcms = "10";
                notaFiscalItem.AliquotaIcms = 0.17;
            }
            if (notaFiscalItem.Cfop.Equals("6.009"))
                notaFiscalItem.BaseIcms = pedidoItem.ValorItemPedido * 0.90; //redução de base
            else
                notaFiscalItem.BaseIcms = pedidoItem.ValorItemPedido;

            notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;

            return notaFiscalItem;
        }

        public string Realiza(string estadoOrigem, string estadoDestino)
        {
            throw new System.NotImplementedException();
        }
    }
}
