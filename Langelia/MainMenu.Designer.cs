namespace Langelia
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.NewGame = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LoadGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.NewGame.BackColor = System.Drawing.Color.MediumPurple;
            this.NewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGame.Location = new System.Drawing.Point(317, 64);
            this.NewGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(176, 52);
            this.NewGame.TabIndex = 0;
            this.NewGame.Text = "Новая игра";
            this.NewGame.UseVisualStyleBackColor = false;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumPurple;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(317, 302);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // LoadGame
            // 
            this.LoadGame.BackColor = System.Drawing.Color.MediumPurple;
            this.LoadGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadGame.Location = new System.Drawing.Point(317, 177);
            this.LoadGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadGame.Name = "LoadGame";
            this.LoadGame.Size = new System.Drawing.Size(176, 52);
            this.LoadGame.TabIndex = 2;
            this.LoadGame.Text = "Загрузить игру";
            this.LoadGame.UseVisualStyleBackColor = false;
            this.LoadGame.Visible = false;
            this.LoadGame.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(832, 420);
            this.Controls.Add(this.LoadGame);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.NewGame);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainMenu";
            this.Text = "Langelia (Главное меню)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button LoadGame;
    }
}

