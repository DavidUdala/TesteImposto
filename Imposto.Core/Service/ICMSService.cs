using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public class ICMSService
    {
        public void RealizaICMS(NotaFiscalItem notaFiscalItem, PedidoItem pedidoItem, string estadoDestino, string estadoOrigem)
        {
            if (estadoDestino == estadoOrigem || pedidoItem.Brinde){
                notaFiscalItem.TipoIcms = "60";
                notaFiscalItem.AliquotaIcms = 0.18;
            }
            else{
                notaFiscalItem.TipoIcms = "10";
                notaFiscalItem.AliquotaIcms = 0.17;
            }
            if (notaFiscalItem.Cfop == "6.009")
                notaFiscalItem.BaseIcms = pedidoItem.ValorItemPedido * 0.90; //redução de base
            else
                notaFiscalItem.BaseIcms = pedidoItem.ValorItemPedido;
            
            notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;
        }
    }
}
