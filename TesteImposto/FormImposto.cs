using Imposto.Core.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imposto.Core.Domain;

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

            if (IsValid())
            {
                NotaFiscalService service = new NotaFiscalService();
                Pedido pedido = new Pedido();

                pedido.EstadoOrigem = txtEstadoOrigem.Text;
                pedido.EstadoDestino = txtEstadoDestino.Text;
                pedido.NomeCliente = textBoxNomeCliente.Text;

                DataTable table = (DataTable)dataGridViewPedidos.DataSource;

                foreach (DataRow row in table.Rows){
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
                CleanControls(this.Controls);
            }
        }

        public void CleanControls(Control.ControlCollection controls)
        {
            foreach (var ctrl in controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)(ctrl)).Text = string.Empty;
                if (ctrl is DataGridView){
                    DataTable table = (DataTable)((DataGridView)(ctrl)).DataSource;
                    table.Rows.Clear();
                }
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

            if (!string.IsNullOrEmpty(message)){
                MessageBox.Show(message, "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
