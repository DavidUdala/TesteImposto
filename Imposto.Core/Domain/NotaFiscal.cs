﻿using Imposto.Core.Service;
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

        Dictionary<string, string> dictCFOP = new Dictionary<string, string>();


        public NotaFiscal EmitirNotaFiscal(Pedido pedido)
        {
            try
            {
                NumeroNotaFiscal = 99999;
                Serie = new Random().Next(Int32.MaxValue);
                NomeCliente = pedido.NomeCliente;

                EstadoDestino = pedido.EstadoDestino;
                EstadoOrigem = pedido.EstadoOrigem;

                string cfop = new CFOFService().RealizaCFO(EstadoOrigem, EstadoDestino);

                foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
                {
                    NotaFiscalItem notaFiscalItem = new NotaFiscalItem();

                    notaFiscalItem.Cfop = cfop;

                    new ICMSService().RealizaICMS(notaFiscalItem, itemPedido, EstadoOrigem, EstadoDestino);

                    new IPIService().RealizaIPI(notaFiscalItem, itemPedido);

                    new DescontoService().RealizarDesconto(notaFiscalItem, itemPedido, EstadoDestino);


                    notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                    notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;

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
