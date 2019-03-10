namespace Langelia
{
    partial class GameProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameProcess));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.сохранитьИгруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокГородовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CitiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PersonsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отношенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllianceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttitudesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.развитиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CultureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MilitaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToMainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EndTurnByButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьИгруToolStripMenuItem,
            this.AboutPlayerToolStripMenuItem,
            this.списокГородовToolStripMenuItem,
            this.SearchToolStripMenuItem,
            this.отношенияToolStripMenuItem,
            this.развитиеToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1278, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // сохранитьИгруToolStripMenuItem
            // 
            this.сохранитьИгруToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAsToolStripMenuItem,
            this.SaveToolStripMenuItem});
            this.сохранитьИгруToolStripMenuItem.Name = "сохранитьИгруToolStripMenuItem";
            this.сохранитьИгруToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.сохранитьИгруToolStripMenuItem.Text = "Сохранить игру";
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.SaveAsToolStripMenuItem.Text = "Сохранить как...";
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            // 
            // AboutPlayerToolStripMenuItem
            // 
            this.AboutPlayerToolStripMenuItem.Name = "AboutPlayerToolStripMenuItem";
            this.AboutPlayerToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.AboutPlayerToolStripMenuItem.Text = "Об игроке";
            this.AboutPlayerToolStripMenuItem.Click += new System.EventHandler(this.AboutPlayerToolStripMenuItem_Click);
            // 
            // списокГородовToolStripMenuItem
            // 
            this.списокГородовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CitiesToolStripMenuItem1,
            this.PersonsToolStripMenuItem1,
            this.PlayersToolStripMenuItem1});
            this.списокГородовToolStripMenuItem.Name = "списокГородовToolStripMenuItem";
            this.списокГородовToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.списокГородовToolStripMenuItem.Text = "Списки";
            // 
            // CitiesToolStripMenuItem1
            // 
            this.CitiesToolStripMenuItem1.Name = "CitiesToolStripMenuItem1";
            this.CitiesToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.CitiesToolStripMenuItem1.Text = "Список городов";
            this.CitiesToolStripMenuItem1.Click += new System.EventHandler(this.CitiesToolStripMenuItem1_Click);
            // 
            // PersonsToolStripMenuItem1
            // 
            this.PersonsToolStripMenuItem1.Name = "PersonsToolStripMenuItem1";
            this.PersonsToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.PersonsToolStripMenuItem1.Text = "Список персонажей";
            this.PersonsToolStripMenuItem1.Click += new System.EventHandler(this.PersonsToolStripMenuItem1_Click);
            // 
            // PlayersToolStripMenuItem1
            // 
            this.PlayersToolStripMenuItem1.Name = "PlayersToolStripMenuItem1";
            this.PlayersToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.PlayersToolStripMenuItem1.Text = "Список игроков";
            this.PlayersToolStripMenuItem1.Click += new System.EventHandler(this.PlayersToolStripMenuItem1_Click);
            // 
            // SearchToolStripMenuItem
            // 
            this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            this.SearchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.SearchToolStripMenuItem.Text = "Поиск";
            // 
            // отношенияToolStripMenuItem
            // 
            this.отношенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AllianceToolStripMenuItem,
            this.TradeToolStripMenuItem,
            this.AttitudesToolStripMenuItem1});
            this.отношенияToolStripMenuItem.Name = "отношенияToolStripMenuItem";
            this.отношенияToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.отношенияToolStripMenuItem.Text = "Дипломатия";
            // 
            // AllianceToolStripMenuItem
            // 
            this.AllianceToolStripMenuItem.Name = "AllianceToolStripMenuItem";
            this.AllianceToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.AllianceToolStripMenuItem.Text = "Союзы";
            this.AllianceToolStripMenuItem.Click += new System.EventHandler(this.AllianceToolStripMenuItem_Click);
            // 
            // TradeToolStripMenuItem
            // 
            this.TradeToolStripMenuItem.Name = "TradeToolStripMenuItem";
            this.TradeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.TradeToolStripMenuItem.Text = "Торговые соглашения";
            this.TradeToolStripMenuItem.Click += new System.EventHandler(this.TradeToolStripMenuItem_Click);
            // 
            // AttitudesToolStripMenuItem1
            // 
            this.AttitudesToolStripMenuItem1.Name = "AttitudesToolStripMenuItem1";
            this.AttitudesToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.AttitudesToolStripMenuItem1.Text = "Отношения";
            this.AttitudesToolStripMenuItem1.Click += new System.EventHandler(this.AttitudesToolStripMenuItem1_Click);
            // 
            // развитиеToolStripMenuItem
            // 
            this.развитиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CultureToolStripMenuItem,
            this.MilitaryToolStripMenuItem,
            this.ProductionToolStripMenuItem});
            this.развитиеToolStripMenuItem.Name = "развитиеToolStripMenuItem";
            this.развитиеToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.развитиеToolStripMenuItem.Text = "Развитие";
            // 
            // CultureToolStripMenuItem
            // 
            this.CultureToolStripMenuItem.Name = "CultureToolStripMenuItem";
            this.CultureToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.CultureToolStripMenuItem.Text = "Культура";
            // 
            // MilitaryToolStripMenuItem
            // 
            this.MilitaryToolStripMenuItem.Name = "MilitaryToolStripMenuItem";
            this.MilitaryToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.MilitaryToolStripMenuItem.Text = "Военное ремесло";
            // 
            // ProductionToolStripMenuItem
            // 
            this.ProductionToolStripMenuItem.Name = "ProductionToolStripMenuItem";
            this.ProductionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ProductionToolStripMenuItem.Text = "Производство";
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToMainMenuToolStripMenuItem,
            this.ExitGameToolStripMenuItem});
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выйтиToolStripMenuItem.Text = "Выход";
            // 
            // ExitToMainMenuToolStripMenuItem
            // 
            this.ExitToMainMenuToolStripMenuItem.Name = "ExitToMainMenuToolStripMenuItem";
            this.ExitToMainMenuToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.ExitToMainMenuToolStripMenuItem.Text = "Выход в главное меню";
            this.ExitToMainMenuToolStripMenuItem.Click += new System.EventHandler(this.ExitToMainMenuToolStripMenuItem_Click);
            // 
            // ExitGameToolStripMenuItem
            // 
            this.ExitGameToolStripMenuItem.Name = "ExitGameToolStripMenuItem";
            this.ExitGameToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.ExitGameToolStripMenuItem.Text = "Выход из игры";
            // 
            // EndTurnByButton
            // 
            this.EndTurnByButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.EndTurnByButton.FlatAppearance.BorderSize = 0;
            this.EndTurnByButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndTurnByButton.Location = new System.Drawing.Point(998, 477);
            this.EndTurnByButton.Name = "EndTurnByButton";
            this.EndTurnByButton.Size = new System.Drawing.Size(81, 62);
            this.EndTurnByButton.TabIndex = 1;
            this.EndTurnByButton.TabStop = false;
            this.EndTurnByButton.Text = "Завершить ход";
            this.EndTurnByButton.UseVisualStyleBackColor = false;
            this.EndTurnByButton.Click += new System.EventHandler(this.EndTurnByButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1278, 544);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManagePers);
            // 
            // GameProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1278, 568);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EndTurnByButton);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "GameProcess";
            this.Text = "Langelia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingThis);
            this.Load += new System.EventHandler(this.FormLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EndTurnByKey);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИгруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокГородовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CitiesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem PersonsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem PlayersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToMainMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отношенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AllianceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttitudesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem развитиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CultureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MilitaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProductionToolStripMenuItem;
        private System.Windows.Forms.Button EndTurnByButton;
        public System.Windows.Forms.PictureBox pictureBox1;
    }
}