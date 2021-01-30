using Imposto.Core.Data;
using Imposto.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Imposto.Core.Service
{
    public class DescontoService
    {
        public void RealizarDesconto(NotaFiscalItem notaFiscalItem, PedidoItem pedidoItem, string estadoDestino)
        {
            List<Estado> lsEstado = new EstadoRepository().P_ESTADOS_SEL();
            if (lsEstado.Any(t => t.Uf == estadoDestino && t.Regiao == "SUDESTE")) 
                notaFiscalItem.Desconto = pedidoItem.ValorItemPedido * 0.1;
        }
    }
}
