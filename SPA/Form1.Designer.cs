
namespace SPA
{
    partial class ApplicationSPAConnexion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitre = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelConnexion = new System.Windows.Forms.Panel();
            this.labelConnexionError = new System.Windows.Forms.Label();
            this.textBoxIdentifiant = new System.Windows.Forms.TextBox();
            this.buttonConnexion = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelIdentifiant = new System.Windows.Forms.Label();
            this.labelConnexion = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelConnexion.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Location = new System.Drawing.Point(429, 30);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(279, 15);
            this.labelTitre.TabIndex = 0;
            this.labelTitre.Text = "Bienvenue sur l\'application de gestion des enquêtes";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelTitre);
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1107, 70);
            this.panelTop.TabIndex = 1;
            // 
            // panelConnexion
            // 
            this.panelConnexion.Controls.Add(this.labelConnexionError);
            this.panelConnexion.Controls.Add(this.textBoxIdentifiant);
            this.panelConnexion.Controls.Add(this.buttonConnexion);
            this.panelConnexion.Controls.Add(this.textBoxPassword);
            this.panelConnexion.Controls.Add(this.labelPassword);
            this.panelConnexion.Controls.Add(this.labelIdentifiant);
            this.panelConnexion.Controls.Add(this.labelConnexion);
            this.panelConnexion.Location = new System.Drawing.Point(0, 76);
            this.panelConnexion.Name = "panelConnexion";
            this.panelConnexion.Size = new System.Drawing.Size(1107, 533);
            this.panelConnexion.TabIndex = 2;
            // 
            // labelConnexionError
            // 
            this.labelConnexionError.AutoSize = true;
            this.labelConnexionError.ForeColor = System.Drawing.Color.Red;
            this.labelConnexionError.Location = new System.Drawing.Point(499, 293);
            this.labelConnexionError.Name = "labelConnexionError";
            this.labelConnexionError.Size = new System.Drawing.Size(150, 15);
            this.labelConnexionError.TabIndex = 6;
            this.labelConnexionError.Text = "Impossible de se connecter";
            this.labelConnexionError.Visible = false;
            // 
            // textBoxIdentifiant
            // 
            this.textBoxIdentifiant.Location = new System.Drawing.Point(477, 193);
            this.textBoxIdentifiant.Name = "textBoxIdentifiant";
            this.textBoxIdentifiant.Size = new System.Drawing.Size(184, 23);
            this.textBoxIdentifiant.TabIndex = 5;
            // 
            // buttonConnexion
            // 
            this.buttonConnexion.Location = new System.Drawing.Point(531, 327);
            this.buttonConnexion.Name = "buttonConnexion";
            this.buttonConnexion.Size = new System.Drawing.Size(75, 23);
            this.buttonConnexion.TabIndex = 4;
            this.buttonConnexion.Text = "Connexion";
            this.buttonConnexion.UseVisualStyleBackColor = true;
            this.buttonConnexion.Click += new System.EventHandler(this.buttonConnexion_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(477, 238);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(184, 23);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(383, 241);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(77, 15);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Mot de passe";
            // 
            // labelIdentifiant
            // 
            this.labelIdentifiant.AutoSize = true;
            this.labelIdentifiant.Location = new System.Drawing.Point(383, 196);
            this.labelIdentifiant.Name = "labelIdentifiant";
            this.labelIdentifiant.Size = new System.Drawing.Size(61, 15);
            this.labelIdentifiant.TabIndex = 1;
            this.labelIdentifiant.Text = "Identifiant";
            // 
            // labelConnexion
            // 
            this.labelConnexion.AutoSize = true;
            this.labelConnexion.Location = new System.Drawing.Point(513, 142);
            this.labelConnexion.Name = "labelConnexion";
            this.labelConnexion.Size = new System.Drawing.Size(93, 15);
            this.labelConnexion.TabIndex = 0;
            this.labelConnexion.Text = "Connectez-vous";
            // 
            // ApplicationSPAConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 609);
            this.Controls.Add(this.panelConnexion);
            this.Controls.Add(this.panelTop);
            this.Name = "ApplicationSPAConnexion";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelConnexion.ResumeLayout(false);
            this.panelConnexion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelConnexion;
        private System.Windows.Forms.Label labelConnexion;
        private System.Windows.Forms.Label labelIdentifiant;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxIdentifiant;
        private System.Windows.Forms.Button buttonConnexion;
        private System.Windows.Forms.Label labelConnexionError;
    }
}

