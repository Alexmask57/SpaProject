
namespace SPA
{
    partial class OuvrirEnquete
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelNomTitulaire = new System.Windows.Forms.Label();
            this.textBoxNomTitulaire = new System.Windows.Forms.TextBox();
            this.labelPrenomTitualire = new System.Windows.Forms.Label();
            this.textBoxPrenomTitulaire = new System.Windows.Forms.TextBox();
            this.labelTitulaireEnquete = new System.Windows.Forms.Label();
            this.labelTitre = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTitre);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 54);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelTitulaireEnquete);
            this.panel2.Controls.Add(this.textBoxPrenomTitulaire);
            this.panel2.Controls.Add(this.labelPrenomTitualire);
            this.panel2.Controls.Add(this.textBoxNomTitulaire);
            this.panel2.Controls.Add(this.labelNomTitulaire);
            this.panel2.Location = new System.Drawing.Point(5, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1229, 579);
            this.panel2.TabIndex = 1;
            // 
            // labelNomTitulaire
            // 
            this.labelNomTitulaire.AutoSize = true;
            this.labelNomTitulaire.Location = new System.Drawing.Point(73, 76);
            this.labelNomTitulaire.Name = "labelNomTitulaire";
            this.labelNomTitulaire.Size = new System.Drawing.Size(77, 15);
            this.labelNomTitulaire.TabIndex = 0;
            this.labelNomTitulaire.Text = "Nom titulaire";
            // 
            // textBoxNomTitulaire
            // 
            this.textBoxNomTitulaire.Location = new System.Drawing.Point(182, 72);
            this.textBoxNomTitulaire.Name = "textBoxNomTitulaire";
            this.textBoxNomTitulaire.Size = new System.Drawing.Size(170, 23);
            this.textBoxNomTitulaire.TabIndex = 1;
            // 
            // labelPrenomTitualire
            // 
            this.labelPrenomTitualire.AutoSize = true;
            this.labelPrenomTitualire.Location = new System.Drawing.Point(73, 112);
            this.labelPrenomTitualire.Name = "labelPrenomTitualire";
            this.labelPrenomTitualire.Size = new System.Drawing.Size(92, 15);
            this.labelPrenomTitualire.TabIndex = 2;
            this.labelPrenomTitualire.Text = "Prenom titulaire";
            // 
            // textBoxPrenomTitulaire
            // 
            this.textBoxPrenomTitulaire.Location = new System.Drawing.Point(182, 109);
            this.textBoxPrenomTitulaire.Name = "textBoxPrenomTitulaire";
            this.textBoxPrenomTitulaire.Size = new System.Drawing.Size(170, 23);
            this.textBoxPrenomTitulaire.TabIndex = 3;
            // 
            // labelTitulaireEnquete
            // 
            this.labelTitulaireEnquete.AutoSize = true;
            this.labelTitulaireEnquete.Location = new System.Drawing.Point(73, 29);
            this.labelTitulaireEnquete.Name = "labelTitulaireEnquete";
            this.labelTitulaireEnquete.Size = new System.Drawing.Size(123, 15);
            this.labelTitulaireEnquete.TabIndex = 4;
            this.labelTitulaireEnquete.Text = "Titulaire de l\'enquête :";
            this.labelTitulaireEnquete.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Location = new System.Drawing.Point(589, 18);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(139, 15);
            this.labelTitre.TabIndex = 0;
            this.labelTitre.Text = "Ouverture d\'une enquête";
            // 
            // OuvrirEnquete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 640);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OuvrirEnquete";
            this.Text = "OuvrirEnquete";
            this.Load += new System.EventHandler(this.OuvrirEnquete_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTitulaireEnquete;
        private System.Windows.Forms.TextBox textBoxPrenomTitulaire;
        private System.Windows.Forms.Label labelPrenomTitualire;
        private System.Windows.Forms.TextBox textBoxNomTitulaire;
        private System.Windows.Forms.Label labelNomTitulaire;
        private System.Windows.Forms.Label labelTitre;
    }
}