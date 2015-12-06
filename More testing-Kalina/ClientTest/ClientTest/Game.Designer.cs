namespace ClientTest
{
    partial class Game
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
            this.lbOpponentName = new System.Windows.Forms.Label();
            this.lbPlayerName = new System.Windows.Forms.Label();
            this.lbAttacks = new System.Windows.Forms.ListBox();
            this.lbOpponentHealth = new System.Windows.Forms.Label();
            this.lbPlayerHealth = new System.Windows.Forms.Label();
            this.btnAttack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbOpponentName
            // 
            this.lbOpponentName.AutoSize = true;
            this.lbOpponentName.Location = new System.Drawing.Point(12, 9);
            this.lbOpponentName.Name = "lbOpponentName";
            this.lbOpponentName.Size = new System.Drawing.Size(42, 13);
            this.lbOpponentName.TabIndex = 0;
            this.lbOpponentName.Text = "Player2";
            // 
            // lbPlayerName
            // 
            this.lbPlayerName.AutoSize = true;
            this.lbPlayerName.Location = new System.Drawing.Point(12, 317);
            this.lbPlayerName.Name = "lbPlayerName";
            this.lbPlayerName.Size = new System.Drawing.Size(42, 13);
            this.lbPlayerName.TabIndex = 1;
            this.lbPlayerName.Text = "Player1";
            // 
            // lbAttacks
            // 
            this.lbAttacks.Enabled = false;
            this.lbAttacks.FormattingEnabled = true;
            this.lbAttacks.Location = new System.Drawing.Point(403, 12);
            this.lbAttacks.Name = "lbAttacks";
            this.lbAttacks.Size = new System.Drawing.Size(178, 264);
            this.lbAttacks.TabIndex = 2;
            // 
            // lbOpponentHealth
            // 
            this.lbOpponentHealth.AutoSize = true;
            this.lbOpponentHealth.Location = new System.Drawing.Point(43, 47);
            this.lbOpponentHealth.Name = "lbOpponentHealth";
            this.lbOpponentHealth.Size = new System.Drawing.Size(38, 13);
            this.lbOpponentHealth.TabIndex = 3;
            this.lbOpponentHealth.Text = "Health";
            // 
            // lbPlayerHealth
            // 
            this.lbPlayerHealth.AutoSize = true;
            this.lbPlayerHealth.Location = new System.Drawing.Point(43, 263);
            this.lbPlayerHealth.Name = "lbPlayerHealth";
            this.lbPlayerHealth.Size = new System.Drawing.Size(38, 13);
            this.lbPlayerHealth.TabIndex = 4;
            this.lbPlayerHealth.Text = "Health";
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(220, 317);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(75, 23);
            this.btnAttack.TabIndex = 5;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 442);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.lbPlayerHealth);
            this.Controls.Add(this.lbOpponentHealth);
            this.Controls.Add(this.lbAttacks);
            this.Controls.Add(this.lbPlayerName);
            this.Controls.Add(this.lbOpponentName);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOpponentName;
        private System.Windows.Forms.Label lbPlayerName;
        private System.Windows.Forms.ListBox lbAttacks;
        private System.Windows.Forms.Label lbOpponentHealth;
        private System.Windows.Forms.Label lbPlayerHealth;
        private System.Windows.Forms.Button btnAttack;
    }
}