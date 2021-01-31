using Imposto.Core.Service;
using Imposto.Core.Service.Imposto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Domain
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public int Serie { get; set; }
        public string NomeCliente { get; set; }
        public string EstadoDestino { get; set; }
        public string EstadoOrigem { get; set; }

        public List<NotaFiscalItem> ItensDaNotaFiscal { get; set; }

        public NotaFiscal()
        {
            ItensDaNotaFiscal = new List<NotaFiscalItem>();
        }


        IRegra cfop = new CFOP();
        IRegra icms = new ICMS();
        IRegra ipi = new IPI();
        IRegra desconto = new Desconto();

        public NotaFiscal EmitirNotaFiscal(Pedido pedido)
        {
            try
            {
                NumeroNotaFiscal = 99999;
                Serie = new Random().Next(Int32.MaxValue);
                NomeCliente = pedido.NomeCliente;

                EstadoDestino = pedido.EstadoDestino;
                EstadoOrigem = pedido.EstadoOrigem;

                string _cfop = cfop.Realiza(EstadoOrigem, EstadoDestino);

                foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
                {
                    NotaFiscalItem notaFiscalItem = new NotaFiscalItem(itemPedido);

                    notaFiscalItem.Cfop = _cfop;

                    icms.Calcula(itemPedido, pedido, notaFiscalItem);
                    ipi.Calcula(itemPedido, pedido, notaFiscalItem);
                    desconto.Calcula(itemPedido, pedido, notaFiscalItem);

                    ItensDaNotaFiscal.Add(notaFiscalItem);
                }

                return this;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public NotaFiscal GerarNotaFiscalXML()
        {
            Utils.XmlDownload(Utils.ObjectToXML(this), ConfigurationManager.AppSettings["PathXML"], NumeroNotaFiscal.ToString());

            return this;
        }
    }
}
