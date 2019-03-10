namespace Langelia
{
    partial class ListObjects
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
            this.NameCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberCitizen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NaumberProduction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCity,
            this.NumberCitizen,
            this.AmountMoney,
            this.NaumberProduction});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(442, 207);
            this.dataGridView1.TabIndex = 0;
            // 
            // NameCity
            // 
            this.NameCity.HeaderText = "Название";
            this.NameCity.Name = "NameCity";
            this.NameCity.ReadOnly = true;
            // 
            // NumberCitizen
            // 
            this.NumberCitizen.HeaderText = "Количество жителей";
            this.NumberCitizen.Name = "NumberCitizen";
            this.NumberCitizen.ReadOnly = true;
            // 
            // AmountMoney
            // 
            this.AmountMoney.HeaderText = "Деньги города";
            this.AmountMoney.Name = "AmountMoney";
            this.AmountMoney.ReadOnly = true;
            // 
            // NaumberProduction
            // 
            this.NaumberProduction.HeaderText = "Количество производства";
            this.NaumberProduction.Name = "NaumberProduction";
            this.NaumberProduction.ReadOnly = true;
            // 
            // ListObjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 336);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ListObjects";
            this.Text = "Список";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberCitizen;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn NaumberProduction;
    }
}