using Imposto.Core.Service;
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



        public NotaFiscal EmitirNotaFiscal(Pedido pedido)
        {
            NumeroNotaFiscal = 99999;
            Serie = new Random().Next(Int32.MaxValue);
            NomeCliente = pedido.NomeCliente;

            EstadoDestino = pedido.EstadoDestino;
            EstadoOrigem = pedido.EstadoOrigem;


            foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
            {
                NotaFiscalItem notaFiscalItem = new NotaFiscalItem();

                new CFOFService().RealizaCFO(notaFiscalItem, EstadoDestino);

                new ICMSService().RealizaICMS(notaFiscalItem, itemPedido, EstadoDestino, EstadoOrigem);

                new IPIService().RealizaIPI(notaFiscalItem, itemPedido);

                new DescontoService().RealizarDesconto(notaFiscalItem, itemPedido, EstadoDestino);

                notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;
                
                ItensDaNotaFiscal.Add(notaFiscalItem);
            }

            return this;
        }

        public NotaFiscal GerarNotaFiscalXML()
        {
            Utils.XmlDownload(Utils.ObjectToXML(this), ConfigurationManager.AppSettings["PathXML"], NumeroNotaFiscal.ToString());

            return this;
        }
    }
}
