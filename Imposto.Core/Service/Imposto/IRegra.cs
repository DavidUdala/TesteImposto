using Imposto.Core.Domain;

namespace Imposto.Core.Service.Imposto
{
    interface IRegra
    {
        NotaFiscalItem Calcula(PedidoItem pedidoItem, Pedido pedido, NotaFiscalItem notaFiscalItem);
        NotaFiscalItem Realiza(Pedido pedido);
    }
}
