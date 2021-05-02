
namespace SPA.Models
{
    partial class Accueil
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
            this.labelTitre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAccueil = new System.Windows.Forms.Panel();
            this.buttonCreateEnquete = new System.Windows.Forms.Button();
            this.buttonDisplayEnquetes = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelAccueil.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Location = new System.Drawing.Point(596, 52);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(38, 15);
            this.labelTitre.TabIndex = 0;
            this.labelTitre.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTitre);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 123);
            this.panel1.TabIndex = 1;
            // 
            // panelAccueil
            // 
            this.panelAccueil.Controls.Add(this.buttonCreateEnquete);
            this.panelAccueil.Controls.Add(this.buttonDisplayEnquetes);
            this.panelAccueil.Location = new System.Drawing.Point(3, 127);
            this.panelAccueil.Name = "panelAccueil";
            this.panelAccueil.Size = new System.Drawing.Size(1222, 499);
            this.panelAccueil.TabIndex = 2;
            // 
            // buttonCreateEnquete
            // 
            this.buttonCreateEnquete.Location = new System.Drawing.Point(516, 179);
            this.buttonCreateEnquete.Name = "buttonCreateEnquete";
            this.buttonCreateEnquete.Size = new System.Drawing.Size(116, 49);
            this.buttonCreateEnquete.TabIndex = 1;
            this.buttonCreateEnquete.Text = "Ouvrir une enquete";
            this.buttonCreateEnquete.UseVisualStyleBackColor = true;
            this.buttonCreateEnquete.Click += new System.EventHandler(this.buttonCreateEnquete_Click);
            // 
            // buttonDisplayEnquetes
            // 
            this.buttonDisplayEnquetes.Location = new System.Drawing.Point(264, 179);
            this.buttonDisplayEnquetes.Name = "buttonDisplayEnquetes";
            this.buttonDisplayEnquetes.Size = new System.Drawing.Size(115, 49);
            this.buttonDisplayEnquetes.TabIndex = 0;
            this.buttonDisplayEnquetes.Text = "Afficher les enquêtes";
            this.buttonDisplayEnquetes.UseVisualStyleBackColor = true;
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 629);
            this.Controls.Add(this.panelAccueil);
            this.Controls.Add(this.panel1);
            this.Name = "Accueil";
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.Accueil_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelAccueil.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelAccueil;
        private System.Windows.Forms.Button buttonCreateEnquete;
        private System.Windows.Forms.Button buttonDisplayEnquetes;
    }
}