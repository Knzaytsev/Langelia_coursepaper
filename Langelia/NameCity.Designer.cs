namespace Langelia
{
    partial class NameCity
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
            this.DoneName = new System.Windows.Forms.Button();
            this.CityName = new System.Windows.Forms.TextBox();
            this.InfoName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DoneName
            // 
            this.DoneName.Location = new System.Drawing.Point(89, 49);
            this.DoneName.Name = "DoneName";
            this.DoneName.Size = new System.Drawing.Size(75, 23);
            this.DoneName.TabIndex = 0;
            this.DoneName.Text = "Задать имя";
            this.DoneName.UseVisualStyleBackColor = true;
            this.DoneName.Click += new System.EventHandler(this.DoneName_Click);
            // 
            // CityName
            // 
            this.CityName.Location = new System.Drawing.Point(12, 23);
            this.CityName.Name = "CityName";
            this.CityName.Size = new System.Drawing.Size(238, 20);
            this.CityName.TabIndex = 1;
            // 
            // InfoName
            // 
            this.InfoName.AutoSize = true;
            this.InfoName.Location = new System.Drawing.Point(9, 7);
            this.InfoName.Name = "InfoName";
            this.InfoName.Size = new System.Drawing.Size(95, 13);
            this.InfoName.TabIndex = 2;
            this.InfoName.Text = "Название города";
            // 
            // NameCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 82);
            this.Controls.Add(this.InfoName);
            this.Controls.Add(this.CityName);
            this.Controls.Add(this.DoneName);
            this.Name = "NameCity";
            this.Text = "NameCity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneName;
        private System.Windows.Forms.Label InfoName;
        public System.Windows.Forms.TextBox CityName;
    }
}