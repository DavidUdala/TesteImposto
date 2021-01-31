using Imposto.Core.Service;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Imposto.Core.Domain;
using Imposto.Core;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {

        public FormImposto()
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width / dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (int i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }
        }

        private object GetTablePedidos()
        {
            DataTable table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(decimal)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));

            table.Columns[3].DefaultValue = false;

            return table;
        }

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    NotaFiscalService service = new NotaFiscalService();
                    Pedido pedido = new Pedido();

                    pedido.EstadoOrigem = txtEstadoOrigem.Text;
                    pedido.EstadoDestino = txtEstadoDestino.Text;
                    pedido.NomeCliente = textBoxNomeCliente.Text;

                    DataTable table = (DataTable)dataGridViewPedidos.DataSource;

                    foreach (DataRow row in table.Rows)
                    {
                        pedido.ItensDoPedido.Add(
                            new PedidoItem()
                            {
                                Brinde = Convert.ToBoolean(row["Brinde"]),
                                CodigoProduto = row["Codigo do produto"].ToString(),
                                NomeProduto = row["Nome do produto"].ToString(),
                                ValorItemPedido = Convert.ToDouble(row["Valor"].ToString())
                            });
                    }
                    service.GerarNotaFiscal(pedido);
                    MessageBox.Show("Operação efetuada com sucesso", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Utils.CleanControls(this.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public bool IsValid()
        {
            string message = "";
            string[] UF = {
                "AC", "AL", "AP", "AM", "BA",
                "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB",
                "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP",
                "SE", "TO"
            };

            if (string.IsNullOrEmpty(txtEstadoOrigem.Text) || !UF.Contains(txtEstadoOrigem.Text.ToUpper()))
                message = "Digite um estado de origem válido.\r\n";
            if (string.IsNullOrEmpty(txtEstadoDestino.Text) || !UF.Contains(txtEstadoDestino.Text.ToUpper()))
                message = message + "Digite um estado de destino válido.\r\n";

            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
