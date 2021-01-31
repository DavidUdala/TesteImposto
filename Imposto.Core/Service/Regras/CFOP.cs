using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service.Imposto
{
    public class CFOP : IRegra
    {
        Dictionary<string, string> dictCFOP = new Dictionary<string, string>()
        {
           { "RJ", "6.000" },
           { "PE", "6.001" },
           { "MG", "6.002" },
           { "PB", "6.003" },
           { "PR", "6.004" },
           { "PI", "6.005" },
           { "RO", "6.006" },
           { "SE", "6.007" },
           { "TO", "6.008" },
           { "SP", "6.009" },
           { "PA", "6.010" }
         };
        public string Realiza(string estadoOrigem, string estadoDestino)
        {
            string cfop = "";

            if (estadoOrigem.ToUpper().Equals("SP") || estadoOrigem.ToUpper().Equals("MG"))
                dictCFOP.TryGetValue(estadoDestino.ToUpper(), out cfop);

            return cfop;
        }
        public NotaFiscalItem Calcula(PedidoItem pedidoItem, Pedido pedido, NotaFiscalItem notaFiscalItem)
        {
            throw new NotImplementedException();
        }
    }
}
