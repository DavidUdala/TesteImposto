using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public class DescontoService
    {
        public void RealizarDesconto(NotaFiscalItem notaFiscalItem, PedidoItem pedidoItem, string estadoDestino)
        {
            string[] UF = {"SP","RJ","MG","ES" };
            if(UF.Contains(estadoDestino))
                notaFiscalItem.Desconto = pedidoItem.ValorItemPedido * 0.1;
        }
    }
}
