using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public class IPIService
    {
        public void RealizaIPI(NotaFiscalItem notaFiscalItem, PedidoItem pedidoItem)
        {
            notaFiscalItem.BaseIpi = pedidoItem.ValorItemPedido;

            if (pedidoItem.Brinde)
                notaFiscalItem.AliquotaIpi = 0;
            else
                notaFiscalItem.AliquotaIpi = 10;

            notaFiscalItem.ValorIpi = notaFiscalItem.BaseIpi * (notaFiscalItem.AliquotaIpi / 100);
        }
    }
}
