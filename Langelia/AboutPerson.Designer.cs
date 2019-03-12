namespace Langelia
{
    partial class AboutPerson
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
            this.namePerson = new System.Windows.Forms.Label();
            this.typePerson = new System.Windows.Forms.Label();
            this.action = new System.Windows.Forms.Button();
            this.healthPerson = new System.Windows.Forms.Label();
            this.attackLabel = new System.Windows.Forms.Label();
            this.defensePerson = new System.Windows.Forms.Label();
            this.movePerson = new System.Windows.Forms.Label();
            this.infoName = new System.Windows.Forms.Label();
            this.infoType = new System.Windows.Forms.Label();
            this.infoMove = new System.Windows.Forms.Label();
            this.infoHealth = new System.Windows.Forms.Label();
            this.infoDefense = new System.Windows.Forms.Label();
            this.infoAttack = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // namePerson
            // 
            this.namePerson.AutoSize = true;
            this.namePerson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.namePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.namePerson.Location = new System.Drawing.Point(148, 9);
            this.namePerson.Name = "namePerson";
            this.namePerson.Size = new System.Drawing.Size(0, 20);
            this.namePerson.TabIndex = 0;
            // 
            // typePerson
            // 
            this.typePerson.AutoSize = true;
            this.typePerson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.typePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typePerson.Location = new System.Drawing.Point(148, 29);
            this.typePerson.Name = "typePerson";
            this.typePerson.Size = new System.Drawing.Size(0, 20);
            this.typePerson.TabIndex = 1;
            // 
            // action
            // 
            this.action.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.action.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.action.Location = new System.Drawing.Point(259, 12);
            this.action.Name = "action";
            this.action.Size = new System.Drawing.Size(148, 119);
            this.action.TabIndex = 2;
            this.action.UseVisualStyleBackColor = true;
            // 
            // healthPerson
            // 
            this.healthPerson.AutoSize = true;
            this.healthPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.healthPerson.Location = new System.Drawing.Point(199, 69);
            this.healthPerson.Name = "healthPerson";
            this.healthPerson.Size = new System.Drawing.Size(0, 20);
            this.healthPerson.TabIndex = 3;
            // 
            // attackLabel
            // 
            this.attackLabel.AutoSize = true;
            this.attackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attackLabel.Location = new System.Drawing.Point(170, 111);
            this.attackLabel.Name = "attackLabel";
            this.attackLabel.Size = new System.Drawing.Size(0, 20);
            this.attackLabel.TabIndex = 4;
            // 
            // defensePerson
            // 
            this.defensePerson.AutoSize = true;
            this.defensePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.defensePerson.Location = new System.Drawing.Point(185, 91);
            this.defensePerson.Name = "defensePerson";
            this.defensePerson.Size = new System.Drawing.Size(0, 20);
            this.defensePerson.TabIndex = 5;
            // 
            // movePerson
            // 
            this.movePerson.AutoSize = true;
            this.movePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.movePerson.Location = new System.Drawing.Point(176, 49);
            this.movePerson.Name = "movePerson";
            this.movePerson.Size = new System.Drawing.Size(0, 20);
            this.movePerson.TabIndex = 6;
            // 
            // infoName
            // 
            this.infoName.AutoSize = true;
            this.infoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoName.Location = new System.Drawing.Point(12, 9);
            this.infoName.Name = "infoName";
            this.infoName.Size = new System.Drawing.Size(130, 20);
            this.infoName.TabIndex = 7;
            this.infoName.Text = "Имя персонажа:";
            // 
            // infoType
            // 
            this.infoType.AutoSize = true;
            this.infoType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoType.Location = new System.Drawing.Point(12, 29);
            this.infoType.Name = "infoType";
            this.infoType.Size = new System.Drawing.Size(126, 20);
            this.infoType.TabIndex = 8;
            this.infoType.Text = "Тип персонажа:";
            // 
            // infoMove
            // 
            this.infoMove.AutoSize = true;
            this.infoMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoMove.Location = new System.Drawing.Point(12, 49);
            this.infoMove.Name = "infoMove";
            this.infoMove.Size = new System.Drawing.Size(158, 20);
            this.infoMove.TabIndex = 9;
            this.infoMove.Text = "Очки передвжения:";
            // 
            // infoHealth
            // 
            this.infoHealth.AutoSize = true;
            this.infoHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoHealth.Location = new System.Drawing.Point(12, 69);
            this.infoHealth.Name = "infoHealth";
            this.infoHealth.Size = new System.Drawing.Size(181, 20);
            this.infoHealth.TabIndex = 10;
            this.infoHealth.Text = "Количество здоровья:";
            // 
            // infoDefense
            // 
            this.infoDefense.AutoSize = true;
            this.infoDefense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoDefense.Location = new System.Drawing.Point(12, 91);
            this.infoDefense.Name = "infoDefense";
            this.infoDefense.Size = new System.Drawing.Size(167, 20);
            this.infoDefense.TabIndex = 11;
            this.infoDefense.Text = "Количество защиты:";
            // 
            // infoAttack
            // 
            this.infoAttack.AutoSize = true;
            this.infoAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoAttack.Location = new System.Drawing.Point(12, 111);
            this.infoAttack.Name = "infoAttack";
            this.infoAttack.Size = new System.Drawing.Size(152, 20);
            this.infoAttack.TabIndex = 12;
            this.infoAttack.Text = "Количество атаки:";
            // 
            // AboutPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 140);
            this.Controls.Add(this.infoAttack);
            this.Controls.Add(this.infoDefense);
            this.Controls.Add(this.infoHealth);
            this.Controls.Add(this.infoMove);
            this.Controls.Add(this.infoType);
            this.Controls.Add(this.infoName);
            this.Controls.Add(this.movePerson);
            this.Controls.Add(this.defensePerson);
            this.Controls.Add(this.attackLabel);
            this.Controls.Add(this.healthPerson);
            this.Controls.Add(this.action);
            this.Controls.Add(this.typePerson);
            this.Controls.Add(this.namePerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AboutPerson";
            this.Text = "AboutPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label namePerson;
        private System.Windows.Forms.Label typePerson;
        private System.Windows.Forms.Button action;
        private System.Windows.Forms.Label healthPerson;
        private System.Windows.Forms.Label attackLabel;
        private System.Windows.Forms.Label defensePerson;
        private System.Windows.Forms.Label movePerson;
        private System.Windows.Forms.Label infoName;
        private System.Windows.Forms.Label infoType;
        private System.Windows.Forms.Label infoMove;
        private System.Windows.Forms.Label infoHealth;
        private System.Windows.Forms.Label infoDefense;
        private System.Windows.Forms.Label infoAttack;
    }
}