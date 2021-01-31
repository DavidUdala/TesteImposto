﻿using Imposto.Core.Domain;
using System;

namespace Imposto.Core.Service.Imposto
{
    public class IPI : IRegra
    {
        public NotaFiscalItem Calcula(PedidoItem pedidoItem, Pedido pedido, NotaFiscalItem notaFiscalItem)
        {
            notaFiscalItem.BaseIpi = pedidoItem.ValorItemPedido;

            if (pedidoItem.Brinde)
                notaFiscalItem.AliquotaIpi = 0;
            else
                notaFiscalItem.AliquotaIpi = 10;

            notaFiscalItem.ValorIpi = notaFiscalItem.BaseIpi * (notaFiscalItem.AliquotaIpi / 100);

            return notaFiscalItem;
        }

        public NotaFiscalItem Realiza(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}