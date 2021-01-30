namespace TesteImposto
{
    partial class FormImposto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            textBoxNomeCliente = new System.Windows.Forms.TextBox();
            txtEstadoOrigem = new System.Windows.Forms.TextBox();
            txtEstadoDestino = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            dataGridViewPedidos = new System.Windows.Forms.DataGridView();
            buttonGerarNotaFiscal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(dataGridViewPedidos)).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 13);
            label1.TabIndex = 0;
            label1.Text = "Nome do Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 34);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 13);
            label2.TabIndex = 1;
            label2.Text = "Estado Origem";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 61);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 13);
            label3.TabIndex = 2;
            label3.Text = "Estado Destino";
            // 
            // textBoxNomeCliente
            // 
            textBoxNomeCliente.Location = new System.Drawing.Point(95, 9);
            textBoxNomeCliente.Name = "textBoxNomeCliente";
            textBoxNomeCliente.Size = new System.Drawing.Size(939, 20);
            textBoxNomeCliente.TabIndex = 3;
            // 
            // txtEstadoOrigem
            // 
            txtEstadoOrigem.Location = new System.Drawing.Point(95, 31);
            txtEstadoOrigem.Name = "txtEstadoOrigem";
            txtEstadoOrigem.Size = new System.Drawing.Size(939, 20);
            txtEstadoOrigem.TabIndex = 4;
            // 
            // txtEstadoDestino
            // 
            txtEstadoDestino.Location = new System.Drawing.Point(95, 53);
            txtEstadoDestino.Name = "txtEstadoDestino";
            txtEstadoDestino.Size = new System.Drawing.Size(939, 20);
            txtEstadoDestino.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(2, 93);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(80, 13);
            label4.TabIndex = 6;
            label4.Text = "Itens do pedido";
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.AllowUserToOrderColumns = true;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Location = new System.Drawing.Point(6, 109);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.Size = new System.Drawing.Size(1028, 325);
            dataGridViewPedidos.TabIndex = 7;
            // 
            // buttonGerarNotaFiscal
            // 
            buttonGerarNotaFiscal.Location = new System.Drawing.Point(907, 440);
            buttonGerarNotaFiscal.Name = "buttonGerarNotaFiscal";
            buttonGerarNotaFiscal.Size = new System.Drawing.Size(127, 23);
            buttonGerarNotaFiscal.TabIndex = 8;
            buttonGerarNotaFiscal.Text = "Gerar Nota Fiscal";
            buttonGerarNotaFiscal.UseVisualStyleBackColor = true;
            buttonGerarNotaFiscal.Click += new System.EventHandler(buttonGerarNotaFiscal_Click);
            // 
            // FormImposto
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1043, 477);
            Controls.Add(buttonGerarNotaFiscal);
            Controls.Add(dataGridViewPedidos);
            Controls.Add(label4);
            Controls.Add(txtEstadoDestino);
            Controls.Add(txtEstadoOrigem);
            Controls.Add(textBoxNomeCliente);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormImposto";
            Text = "Calculo de imposto";
            ((System.ComponentModel.ISupportInitialize)(dataGridViewPedidos)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNomeCliente;
        private System.Windows.Forms.TextBox txtEstadoOrigem;
        private System.Windows.Forms.TextBox txtEstadoDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewPedidos;
        private System.Windows.Forms.Button buttonGerarNotaFiscal;
    }
}

