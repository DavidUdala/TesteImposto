using Imposto.Core.Domain;
using Imposto.Core.Data;

namespace Imposto.Core.Service
{
    public class NotaFiscalService
    {

        public void GerarNotaFiscal(Domain.Pedido pedido)
        {
            NotaFiscal notaFiscal = new NotaFiscal()
               .EmitirNotaFiscal(pedido)
               .GerarNotaFiscalXML();

            notaFiscal = new NotaFiscalRepository().P_Nota_Fiscal(notaFiscal);

            notaFiscal.ItensDaNotaFiscal
                .ForEach(t => new NotaFiscalItemRepository().P_Nota_Fiscal_Item(t, notaFiscal.Id));
        }
    }
}
