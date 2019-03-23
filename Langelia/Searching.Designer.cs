namespace Langelia
{
    partial class Searching
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rightOne = new System.Windows.Forms.Button();
            this.rightAll = new System.Windows.Forms.Button();
            this.leftOne = new System.Windows.Forms.Button();
            this.leftAll = new System.Windows.Forms.Button();
            this.startSearching = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 278);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбранные таблицы";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 19);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(215, 253);
            this.treeView1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(285, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 278);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбранные атрибуты";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(6, 21);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(215, 251);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Игрок",
            "Город",
            "Список построек",
            "Здание",
            "Тип здания",
            "Клетка",
            "Производство",
            "Изображение",
            "Тип очков правителя"});
            this.comboBox1.Location = new System.Drawing.Point(12, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Доступные таблицы";
            // 
            // rightOne
            // 
            this.rightOne.Location = new System.Drawing.Point(245, 108);
            this.rightOne.Name = "rightOne";
            this.rightOne.Size = new System.Drawing.Size(34, 34);
            this.rightOne.TabIndex = 4;
            this.rightOne.Text = ">";
            this.rightOne.UseVisualStyleBackColor = true;
            this.rightOne.Click += new System.EventHandler(this.rightOne_Click);
            // 
            // rightAll
            // 
            this.rightAll.Location = new System.Drawing.Point(245, 148);
            this.rightAll.Name = "rightAll";
            this.rightAll.Size = new System.Drawing.Size(34, 34);
            this.rightAll.TabIndex = 5;
            this.rightAll.Text = ">>";
            this.rightAll.UseVisualStyleBackColor = true;
            this.rightAll.Click += new System.EventHandler(this.rightAll_Click);
            // 
            // leftOne
            // 
            this.leftOne.Location = new System.Drawing.Point(245, 188);
            this.leftOne.Name = "leftOne";
            this.leftOne.Size = new System.Drawing.Size(34, 34);
            this.leftOne.TabIndex = 6;
            this.leftOne.Text = "<";
            this.leftOne.UseVisualStyleBackColor = true;
            this.leftOne.Click += new System.EventHandler(this.leftOne_Click);
            // 
            // leftAll
            // 
            this.leftAll.Location = new System.Drawing.Point(245, 228);
            this.leftAll.Name = "leftAll";
            this.leftAll.Size = new System.Drawing.Size(34, 34);
            this.leftAll.TabIndex = 7;
            this.leftAll.Text = "<<";
            this.leftAll.UseVisualStyleBackColor = true;
            this.leftAll.Click += new System.EventHandler(this.leftAll_Click);
            // 
            // startSearching
            // 
            this.startSearching.Location = new System.Drawing.Point(245, 268);
            this.startSearching.Name = "startSearching";
            this.startSearching.Size = new System.Drawing.Size(34, 34);
            this.startSearching.TabIndex = 5;
            this.startSearching.Text = "OK";
            this.startSearching.UseVisualStyleBackColor = true;
            this.startSearching.Click += new System.EventHandler(this.startSearching_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 348);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(494, 98);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // Searching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 458);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.startSearching);
            this.Controls.Add(this.leftAll);
            this.Controls.Add(this.leftOne);
            this.Controls.Add(this.rightAll);
            this.Controls.Add(this.rightOne);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Searching";
            this.Text = "Searching";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rightOne;
        private System.Windows.Forms.Button rightAll;
        private System.Windows.Forms.Button leftOne;
        private System.Windows.Forms.Button leftAll;
        private System.Windows.Forms.Button startSearching;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}