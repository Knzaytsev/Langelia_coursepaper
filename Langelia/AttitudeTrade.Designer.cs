namespace Langelia
{
    partial class AttitudeTrade
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NameTrader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeTrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameTrader,
            this.TimeTrade,
            this.Money});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(541, 253);
            this.dataGridView1.TabIndex = 0;
            // 
            // NameTrader
            // 
            this.NameTrader.HeaderText = "Государство";
            this.NameTrader.Name = "NameTrader";
            this.NameTrader.ReadOnly = true;
            // 
            // TimeTrade
            // 
            this.TimeTrade.HeaderText = "Время окончания соглашения";
            this.TimeTrade.Name = "TimeTrade";
            this.TimeTrade.ReadOnly = true;
            // 
            // Money
            // 
            this.Money.HeaderText = "Доход с торговли";
            this.Money.Name = "Money";
            this.Money.ReadOnly = true;
            // 
            // AttitudeTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 250);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AttitudeTrade";
            this.Text = "Торговые соглашения";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameTrader;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeTrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
    }
}