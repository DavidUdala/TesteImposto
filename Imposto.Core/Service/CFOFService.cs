using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public class CFOFService
    {
        public void RealizaCFO(NotaFiscalItem notaFiscalItem, string estadoDestino)
        {
            string[] estados = { "RJ", "PE", "MG", "PB", "PR", "PI", "RO", "SE", "TO", "PA", "SP" };

            if (!estados.Contains(estadoDestino))
                throw new Exception("Não existe uma regra de CFO para o destino informado!");

            switch (estadoDestino)
            {
                case "RJ":
                    notaFiscalItem.Cfop = "6.000";
                    break;
                case "PE":
                    notaFiscalItem.Cfop = "6.001";
                    break;
                case "MG":
                    notaFiscalItem.Cfop = "6.002";
                    break;
                case "PB":
                    notaFiscalItem.Cfop = "6.003";
                    break;
                case "PR":
                    notaFiscalItem.Cfop = "6.004";
                    break;
                case "PI":
                    notaFiscalItem.Cfop = "6.005";
                    break;
                case "RO":
                    notaFiscalItem.Cfop = "6.006";
                    break;
                case "SE":
                    notaFiscalItem.Cfop = "6.007";
                    break;
                case "TO":
                    notaFiscalItem.Cfop = "6.008";
                    break;
                case "SP":
                    notaFiscalItem.Cfop = "6.009";
                    break;
                case "PA":
                    notaFiscalItem.Cfop = "6.010";
                    break;
                default:
                    break;
            }
        }
    }
}
