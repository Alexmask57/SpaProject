
namespace SPA
{
    partial class Admin
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
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.checkBoxSal = new System.Windows.Forms.CheckBox();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.labelNom = new System.Windows.Forms.Label();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.labelPrenom = new System.Windows.Forms.Label();
            this.textBoxAdresse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxVille = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCodePostal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxBenevole = new System.Windows.Forms.CheckBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMotDePasse = new System.Windows.Forms.TextBox();
            this.labelErrorNom = new System.Windows.Forms.Label();
            this.labelErrorPrenom = new System.Windows.Forms.Label();
            this.labelErrorAdresse = new System.Windows.Forms.Label();
            this.labelErrorVille = new System.Windows.Forms.Label();
            this.labelCodePostal = new System.Windows.Forms.Label();
            this.labelErrorCheckBox = new System.Windows.Forms.Label();
            this.labelErrorLogin = new System.Windows.Forms.Label();
            this.labelErrorMDP = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelErrorEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(542, 412);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(125, 32);
            this.buttonAjouter.TabIndex = 1;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // checkBoxSal
            // 
            this.checkBoxSal.AutoSize = true;
            this.checkBoxSal.Location = new System.Drawing.Point(683, 210);
            this.checkBoxSal.Name = "checkBoxSal";
            this.checkBoxSal.Size = new System.Drawing.Size(60, 19);
            this.checkBoxSal.TabIndex = 4;
            this.checkBoxSal.Text = "Salarié";
            this.checkBoxSal.UseVisualStyleBackColor = true;
            this.checkBoxSal.CheckedChanged += new System.EventHandler(this.checkBoxSal_CheckedChanged);
            // 
            // textBoxNom
            // 
            this.textBoxNom.Location = new System.Drawing.Point(299, 75);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(152, 23);
            this.textBoxNom.TabIndex = 5;
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.Location = new System.Drawing.Point(149, 78);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(40, 15);
            this.labelNom.TabIndex = 6;
            this.labelNom.Text = "Nom :";
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Location = new System.Drawing.Point(299, 137);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.Size = new System.Drawing.Size(152, 23);
            this.textBoxPrenom.TabIndex = 7;
            // 
            // labelPrenom
            // 
            this.labelPrenom.AutoSize = true;
            this.labelPrenom.Location = new System.Drawing.Point(149, 140);
            this.labelPrenom.Name = "labelPrenom";
            this.labelPrenom.Size = new System.Drawing.Size(55, 15);
            this.labelPrenom.TabIndex = 8;
            this.labelPrenom.Text = "Prenom :";
            // 
            // textBoxAdresse
            // 
            this.textBoxAdresse.Location = new System.Drawing.Point(299, 194);
            this.textBoxAdresse.Name = "textBoxAdresse";
            this.textBoxAdresse.Size = new System.Drawing.Size(152, 23);
            this.textBoxAdresse.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Adresse :";
            // 
            // textBoxVille
            // 
            this.textBoxVille.Location = new System.Drawing.Point(833, 70);
            this.textBoxVille.Name = "textBoxVille";
            this.textBoxVille.Size = new System.Drawing.Size(152, 23);
            this.textBoxVille.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ville";
            // 
            // textBoxCodePostal
            // 
            this.textBoxCodePostal.Location = new System.Drawing.Point(833, 125);
            this.textBoxCodePostal.Name = "textBoxCodePostal";
            this.textBoxCodePostal.Size = new System.Drawing.Size(152, 23);
            this.textBoxCodePostal.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(683, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Code postal :";
            // 
            // checkBoxBenevole
            // 
            this.checkBoxBenevole.AutoSize = true;
            this.checkBoxBenevole.Location = new System.Drawing.Point(876, 210);
            this.checkBoxBenevole.Name = "checkBoxBenevole";
            this.checkBoxBenevole.Size = new System.Drawing.Size(74, 19);
            this.checkBoxBenevole.TabIndex = 15;
            this.checkBoxBenevole.Text = "Benevole";
            this.checkBoxBenevole.UseVisualStyleBackColor = true;
            this.checkBoxBenevole.CheckedChanged += new System.EventHandler(this.checkBoxBenevole_CheckedChanged);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Enabled = false;
            this.textBoxLogin.Location = new System.Drawing.Point(310, 324);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(140, 23);
            this.textBoxLogin.TabIndex = 16;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(149, 327);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(37, 15);
            this.labelLogin.TabIndex = 17;
            this.labelLogin.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(675, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Mot de passe :";
            // 
            // textBoxMotDePasse
            // 
            this.textBoxMotDePasse.Enabled = false;
            this.textBoxMotDePasse.Location = new System.Drawing.Point(833, 319);
            this.textBoxMotDePasse.Name = "textBoxMotDePasse";
            this.textBoxMotDePasse.Size = new System.Drawing.Size(140, 23);
            this.textBoxMotDePasse.TabIndex = 19;
            // 
            // labelErrorNom
            // 
            this.labelErrorNom.AutoSize = true;
            this.labelErrorNom.ForeColor = System.Drawing.Color.Red;
            this.labelErrorNom.Location = new System.Drawing.Point(149, 101);
            this.labelErrorNom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelErrorNom.Name = "labelErrorNom";
            this.labelErrorNom.Size = new System.Drawing.Size(161, 15);
            this.labelErrorNom.TabIndex = 53;
            this.labelErrorNom.Text = "* Nom manquant ou invalide";
            this.labelErrorNom.Visible = false;
            // 
            // labelErrorPrenom
            // 
            this.labelErrorPrenom.AutoSize = true;
            this.labelErrorPrenom.ForeColor = System.Drawing.Color.Red;
            this.labelErrorPrenom.Location = new System.Drawing.Point(149, 163);
            this.labelErrorPrenom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelErrorPrenom.Name = "labelErrorPrenom";
            this.labelErrorPrenom.Size = new System.Drawing.Size(176, 15);
            this.labelErrorPrenom.TabIndex = 54;
            this.labelErrorPrenom.Text = "* Prenom manquant ou invalide";
            this.labelErrorPrenom.Visible = false;
            // 
            // labelErrorAdresse
            // 
            this.labelErrorAdresse.AutoSize = true;
            this.labelErrorAdresse.ForeColor = System.Drawing.Color.Red;
            this.labelErrorAdresse.Location = new System.Drawing.Point(150, 220);
            this.labelErrorAdresse.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelErrorAdresse.Name = "labelErrorAdresse";
            this.labelErrorAdresse.Size = new System.Drawing.Size(175, 15);
            this.labelErrorAdresse.TabIndex = 55;
            this.labelErrorAdresse.Text = "* Adresse manquant ou invalide";
            this.labelErrorAdresse.Visible = false;
            // 
            // labelErrorVille
            // 
            this.labelErrorVille.AutoSize = true;
            this.labelErrorVille.ForeColor = System.Drawing.Color.Red;
            this.labelErrorVille.Location = new System.Drawing.Point(680, 101);
            this.labelErrorVille.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelErrorVille.Name = "labelErrorVille";
            this.labelErrorVille.Size = new System.Drawing.Size(162, 15);
            this.labelErrorVille.TabIndex = 56;
            this.labelErrorVille.Text = "* Ville manquante ou invalide";
            this.labelErrorVille.Visible = false;
            // 
            // labelCodePostal
            // 
            this.labelCodePostal.AutoSize = true;
            this.labelCodePostal.ForeColor = System.Drawing.Color.Red;
            this.labelCodePostal.Location = new System.Drawing.Point(683, 163);
            this.labelCodePostal.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelCodePostal.Name = "labelCodePostal";
            this.labelCodePostal.Size = new System.Drawing.Size(200, 15);
            this.labelCodePostal.TabIndex = 57;
            this.labelCodePostal.Text = "*  Code Postal manquant ou invalide";
            this.labelCodePostal.Visible = false;
            // 
            // labelErrorCheckBox
            // 
            this.labelErrorCheckBox.AutoSize = true;
            this.labelErrorCheckBox.ForeColor = System.Drawing.Color.Red;
            this.labelErrorCheckBox.Location = new System.Drawing.Point(680, 244);
            this.labelErrorCheckBox.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelErrorCheckBox.Name = "labelErrorCheckBox";
            this.labelErrorCheckBox.Size = new System.Drawing.Size(102, 15);
            this.labelErrorCheckBox.TabIndex = 58;
            this.labelErrorCheckBox.Text = "* Cocher une case";
            this.labelErrorCheckBox.Visible = false;
            // 
            // labelErrorLogin
            // 
            this.labelErrorLogin.AutoSize = true;
            this.labelErrorLogin.ForeColor = System.Drawing.Color.Red;
            this.labelErrorLogin.Location = new System.Drawing.Point(149, 363);
            this.labelErrorLogin.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelErrorLogin.Name = "labelErrorLogin";
            this.labelErrorLogin.Size = new System.Drawing.Size(164, 15);
            this.labelErrorLogin.TabIndex = 59;
            this.labelErrorLogin.Text = "* Login manquant ou invalide";
            this.labelErrorLogin.Visible = false;
            // 
            // labelErrorMDP
            // 
            this.labelErrorMDP.AutoSize = true;
            this.labelErrorMDP.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMDP.Location = new System.Drawing.Point(675, 363);
            this.labelErrorMDP.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelErrorMDP.Name = "labelErrorMDP";
            this.labelErrorMDP.Size = new System.Drawing.Size(207, 15);
            this.labelErrorMDP.TabIndex = 60;
            this.labelErrorMDP.Text = "*  Mot de passe manquant ou invalide";
            this.labelErrorMDP.Visible = false;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(298, 263);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(152, 23);
            this.textBoxEmail.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 62;
            this.label5.Text = "Email :";
            // 
            // labelErrorEmail
            // 
            this.labelErrorEmail.AutoSize = true;
            this.labelErrorEmail.ForeColor = System.Drawing.Color.Red;
            this.labelErrorEmail.Location = new System.Drawing.Point(149, 289);
            this.labelErrorEmail.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelErrorEmail.Name = "labelErrorEmail";
            this.labelErrorEmail.Size = new System.Drawing.Size(175, 15);
            this.labelErrorEmail.TabIndex = 63;
            this.labelErrorEmail.Text = "* Adresse manquant ou invalide";
            this.labelErrorEmail.Visible = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 523);
            this.Controls.Add(this.labelErrorEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelErrorMDP);
            this.Controls.Add(this.labelErrorLogin);
            this.Controls.Add(this.labelErrorCheckBox);
            this.Controls.Add(this.labelCodePostal);
            this.Controls.Add(this.labelErrorVille);
            this.Controls.Add(this.labelErrorAdresse);
            this.Controls.Add(this.labelErrorPrenom);
            this.Controls.Add(this.labelErrorNom);
            this.Controls.Add(this.textBoxMotDePasse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.checkBoxBenevole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCodePostal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxVille);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAdresse);
            this.Controls.Add(this.labelPrenom);
            this.Controls.Add(this.textBoxPrenom);
            this.Controls.Add(this.labelNom);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.checkBoxSal);
            this.Controls.Add(this.buttonAjouter);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.CheckBox checkBoxSal;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelPrenom;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.TextBox textBoxAdresse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxVille;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCodePostal;
        private System.Windows.Forms.CheckBox checkBoxBenevole;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMotDePasse;
        private System.Windows.Forms.Label labelErrorNom;
        private System.Windows.Forms.Label labelErrorPrenom;
        private System.Windows.Forms.Label labelErrorAdresse;
        private System.Windows.Forms.Label labelErrorVille;
        private System.Windows.Forms.Label labelCodePostal;
        private System.Windows.Forms.Label labelErrorCheckBox;
        private System.Windows.Forms.Label labelErrorLogin;
        private System.Windows.Forms.Label labelErrorMDP;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelErrorEmail;
    }
}