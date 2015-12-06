namespace ClientTest
{
    partial class CharacterCreation
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
            this.tbCharacterName = new System.Windows.Forms.TextBox();
            this.rbWater = new System.Windows.Forms.RadioButton();
            this.rbFire = new System.Windows.Forms.RadioButton();
            this.rbAir = new System.Windows.Forms.RadioButton();
            this.rbWarrior = new System.Windows.Forms.RadioButton();
            this.rbWizard = new System.Windows.Forms.RadioButton();
            this.rbArcher = new System.Windows.Forms.RadioButton();
            this.rbEarth = new System.Windows.Forms.RadioButton();
            this.lbCharacterName = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.gbElement = new System.Windows.Forms.GroupBox();
            this.gbClass = new System.Windows.Forms.GroupBox();
            this.gbElement.SuspendLayout();
            this.gbClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbCharacterName
            // 
            this.tbCharacterName.Location = new System.Drawing.Point(60, 8);
            this.tbCharacterName.Name = "tbCharacterName";
            this.tbCharacterName.Size = new System.Drawing.Size(100, 20);
            this.tbCharacterName.TabIndex = 0;
            // 
            // rbWater
            // 
            this.rbWater.AutoSize = true;
            this.rbWater.Location = new System.Drawing.Point(17, 19);
            this.rbWater.Name = "rbWater";
            this.rbWater.Size = new System.Drawing.Size(54, 17);
            this.rbWater.TabIndex = 1;
            this.rbWater.TabStop = true;
            this.rbWater.Text = "Water";
            this.rbWater.UseVisualStyleBackColor = true;
            // 
            // rbFire
            // 
            this.rbFire.AutoSize = true;
            this.rbFire.Location = new System.Drawing.Point(17, 42);
            this.rbFire.Name = "rbFire";
            this.rbFire.Size = new System.Drawing.Size(42, 17);
            this.rbFire.TabIndex = 2;
            this.rbFire.TabStop = true;
            this.rbFire.Text = "Fire";
            this.rbFire.UseVisualStyleBackColor = true;
            // 
            // rbAir
            // 
            this.rbAir.AutoSize = true;
            this.rbAir.Location = new System.Drawing.Point(17, 65);
            this.rbAir.Name = "rbAir";
            this.rbAir.Size = new System.Drawing.Size(37, 17);
            this.rbAir.TabIndex = 3;
            this.rbAir.TabStop = true;
            this.rbAir.Text = "Air";
            this.rbAir.UseVisualStyleBackColor = true;
            // 
            // rbWarrior
            // 
            this.rbWarrior.AutoSize = true;
            this.rbWarrior.Location = new System.Drawing.Point(13, 19);
            this.rbWarrior.Name = "rbWarrior";
            this.rbWarrior.Size = new System.Drawing.Size(59, 17);
            this.rbWarrior.TabIndex = 4;
            this.rbWarrior.TabStop = true;
            this.rbWarrior.Text = "Warrior";
            this.rbWarrior.UseVisualStyleBackColor = true;
            // 
            // rbWizard
            // 
            this.rbWizard.AutoSize = true;
            this.rbWizard.Location = new System.Drawing.Point(13, 42);
            this.rbWizard.Name = "rbWizard";
            this.rbWizard.Size = new System.Drawing.Size(58, 17);
            this.rbWizard.TabIndex = 5;
            this.rbWizard.TabStop = true;
            this.rbWizard.Text = "Wizard";
            this.rbWizard.UseVisualStyleBackColor = true;
            // 
            // rbArcher
            // 
            this.rbArcher.AutoSize = true;
            this.rbArcher.Location = new System.Drawing.Point(13, 65);
            this.rbArcher.Name = "rbArcher";
            this.rbArcher.Size = new System.Drawing.Size(56, 17);
            this.rbArcher.TabIndex = 6;
            this.rbArcher.TabStop = true;
            this.rbArcher.Text = "Archer";
            this.rbArcher.UseVisualStyleBackColor = true;
            // 
            // rbEarth
            // 
            this.rbEarth.AutoSize = true;
            this.rbEarth.Location = new System.Drawing.Point(17, 88);
            this.rbEarth.Name = "rbEarth";
            this.rbEarth.Size = new System.Drawing.Size(50, 17);
            this.rbEarth.TabIndex = 7;
            this.rbEarth.TabStop = true;
            this.rbEarth.Text = "Earth";
            this.rbEarth.UseVisualStyleBackColor = true;
            // 
            // lbCharacterName
            // 
            this.lbCharacterName.AutoSize = true;
            this.lbCharacterName.Location = new System.Drawing.Point(16, 15);
            this.lbCharacterName.Name = "lbCharacterName";
            this.lbCharacterName.Size = new System.Drawing.Size(38, 13);
            this.lbCharacterName.TabIndex = 8;
            this.lbCharacterName.Text = "Name:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(183, 166);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // gbElement
            // 
            this.gbElement.Controls.Add(this.rbWater);
            this.gbElement.Controls.Add(this.rbFire);
            this.gbElement.Controls.Add(this.rbAir);
            this.gbElement.Controls.Add(this.rbEarth);
            this.gbElement.Location = new System.Drawing.Point(3, 46);
            this.gbElement.Name = "gbElement";
            this.gbElement.Size = new System.Drawing.Size(126, 113);
            this.gbElement.TabIndex = 10;
            this.gbElement.TabStop = false;
            this.gbElement.Text = "Element";
            // 
            // gbClass
            // 
            this.gbClass.Controls.Add(this.rbWarrior);
            this.gbClass.Controls.Add(this.rbWizard);
            this.gbClass.Controls.Add(this.rbArcher);
            this.gbClass.Location = new System.Drawing.Point(162, 46);
            this.gbClass.Name = "gbClass";
            this.gbClass.Size = new System.Drawing.Size(123, 113);
            this.gbClass.TabIndex = 11;
            this.gbClass.TabStop = false;
            this.gbClass.Text = "Class";
            // 
            // CharacterCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 250);
            this.Controls.Add(this.gbClass);
            this.Controls.Add(this.gbElement);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lbCharacterName);
            this.Controls.Add(this.tbCharacterName);
            this.Name = "CharacterCreation";
            this.Text = "CharacterCreation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CharacterCreation_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CharacterCreation_FormClosed);
            this.Load += new System.EventHandler(this.CharacterCreation_Load);
            this.gbElement.ResumeLayout(false);
            this.gbElement.PerformLayout();
            this.gbClass.ResumeLayout(false);
            this.gbClass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCharacterName;
        private System.Windows.Forms.RadioButton rbWater;
        private System.Windows.Forms.RadioButton rbFire;
        private System.Windows.Forms.RadioButton rbAir;
        private System.Windows.Forms.RadioButton rbWarrior;
        private System.Windows.Forms.RadioButton rbWizard;
        private System.Windows.Forms.RadioButton rbArcher;
        private System.Windows.Forms.RadioButton rbEarth;
        private System.Windows.Forms.Label lbCharacterName;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox gbElement;
        private System.Windows.Forms.GroupBox gbClass;
    }
}