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
        public NotaFiscalItem Realiza(Pedido pedido)
        {
            var output = new NotaFiscalItem();

            string cfop = "";

            if (pedido.EstadoOrigem.ToUpper().Equals("SP") || pedido.EstadoOrigem.ToUpper().Equals("MG"))
            {
                Dictionary<string, string> dictCFOP = new Dictionary<string, string>();

                dictCFOP.Add("RJ", "6.000");
                dictCFOP.Add("PE", "6.001");
                dictCFOP.Add("MG", "6.002");
                dictCFOP.Add("PB", "6.003");
                dictCFOP.Add("PR", "6.004");
                dictCFOP.Add("PI", "6.005");
                dictCFOP.Add("RO", "6.006");
                dictCFOP.Add("SE", "6.007");
                dictCFOP.Add("TO", "6.008");
                dictCFOP.Add("SP", "6.009");
                dictCFOP.Add("PA", "6.010");

                dictCFOP.TryGetValue(pedido.EstadoDestino.ToUpper(), out cfop);

                output.Cfop = cfop;
            }
            else
                output.Cfop = "";
            return output;
        }
        public NotaFiscalItem Calcula(PedidoItem pedidoItem, Pedido pedido, NotaFiscalItem notaFiscalItem)
        {
            throw new NotImplementedException();
        }
    }
}
