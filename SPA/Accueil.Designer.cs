
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxRecherche = new System.Windows.Forms.TextBox();
            this.labelRecherche = new System.Windows.Forms.Label();
            this.labelTitre = new System.Windows.Forms.Label();
            this.buttonDeleteEnquete = new System.Windows.Forms.Button();
            this.buttonModifyEnquetes = new System.Windows.Forms.Button();
            this.buttonCreateEnquete = new System.Windows.Forms.Button();
            this.panelAccueil = new System.Windows.Forms.Panel();
            this.listViewEnquetes = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panelAccueil.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.textBoxRecherche);
            this.panel1.Controls.Add(this.labelRecherche);
            this.panel1.Controls.Add(this.labelTitre);
            this.panel1.Controls.Add(this.buttonDeleteEnquete);
            this.panel1.Controls.Add(this.buttonModifyEnquetes);
            this.panel1.Controls.Add(this.buttonCreateEnquete);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2973, 293);
            this.panel1.TabIndex = 1;
            // 
            // textBoxRecherche
            // 
            this.textBoxRecherche.Location = new System.Drawing.Point(1576, 213);
            this.textBoxRecherche.Name = "textBoxRecherche";
            this.textBoxRecherche.Size = new System.Drawing.Size(576, 47);
            this.textBoxRecherche.TabIndex = 5;
            // 
            // labelRecherche
            // 
            this.labelRecherche.AutoSize = true;
            this.labelRecherche.Location = new System.Drawing.Point(1390, 213);
            this.labelRecherche.Name = "labelRecherche";
            this.labelRecherche.Size = new System.Drawing.Size(170, 41);
            this.labelRecherche.TabIndex = 4;
            this.labelRecherche.Text = "Recherche :";
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Location = new System.Drawing.Point(140, 42);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(140, 41);
            this.labelTitre.TabIndex = 3;
            this.labelTitre.Text = "labelTitre";
            // 
            // buttonDeleteEnquete
            // 
            this.buttonDeleteEnquete.Enabled = false;
            this.buttonDeleteEnquete.Location = new System.Drawing.Point(795, 120);
            this.buttonDeleteEnquete.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.buttonDeleteEnquete.Name = "buttonDeleteEnquete";
            this.buttonDeleteEnquete.Size = new System.Drawing.Size(282, 134);
            this.buttonDeleteEnquete.TabIndex = 2;
            this.buttonDeleteEnquete.Text = "Supprimer une enquête";
            this.buttonDeleteEnquete.UseVisualStyleBackColor = true;
            this.buttonDeleteEnquete.Click += new System.EventHandler(this.buttonDeleteEnquete_Click);
            // 
            // buttonModifyEnquetes
            // 
            this.buttonModifyEnquetes.Enabled = false;
            this.buttonModifyEnquetes.Location = new System.Drawing.Point(472, 120);
            this.buttonModifyEnquetes.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.buttonModifyEnquetes.Name = "buttonModifyEnquetes";
            this.buttonModifyEnquetes.Size = new System.Drawing.Size(279, 134);
            this.buttonModifyEnquetes.TabIndex = 0;
            this.buttonModifyEnquetes.Text = "Modifier une enquête";
            this.buttonModifyEnquetes.UseVisualStyleBackColor = true;
            this.buttonModifyEnquetes.Click += new System.EventHandler(this.buttonModifyEnquetes_Click);
            // 
            // buttonCreateEnquete
            // 
            this.buttonCreateEnquete.Location = new System.Drawing.Point(140, 120);
            this.buttonCreateEnquete.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.buttonCreateEnquete.Name = "buttonCreateEnquete";
            this.buttonCreateEnquete.Size = new System.Drawing.Size(282, 134);
            this.buttonCreateEnquete.TabIndex = 1;
            this.buttonCreateEnquete.Text = "Ajouter une enquête";
            this.buttonCreateEnquete.UseVisualStyleBackColor = true;
            this.buttonCreateEnquete.Click += new System.EventHandler(this.buttonCreateEnquete_Click);
            // 
            // panelAccueil
            // 
            this.panelAccueil.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAccueil.AutoSize = true;
            this.panelAccueil.Controls.Add(this.listViewEnquetes);
            this.panelAccueil.Location = new System.Drawing.Point(2, 295);
            this.panelAccueil.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.panelAccueil.Name = "panelAccueil";
            this.panelAccueil.Size = new System.Drawing.Size(2979, 1422);
            this.panelAccueil.TabIndex = 2;
            // 
            // listViewEnquetes
            // 
            this.listViewEnquetes.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewEnquetes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEnquetes.FullRowSelect = true;
            this.listViewEnquetes.HideSelection = false;
            this.listViewEnquetes.Location = new System.Drawing.Point(140, 0);
            this.listViewEnquetes.MultiSelect = false;
            this.listViewEnquetes.Name = "listViewEnquetes";
            this.listViewEnquetes.Size = new System.Drawing.Size(2708, 1343);
            this.listViewEnquetes.TabIndex = 0;
            this.listViewEnquetes.UseCompatibleStateImageBehavior = false;
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2977, 1719);
            this.Controls.Add(this.panelAccueil);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "Accueil";
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.Accueil_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelAccueil.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelAccueil;
        private System.Windows.Forms.Button buttonCreateEnquete;
        private System.Windows.Forms.Button buttonModifyEnquetes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDeleteEnquete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.TextBox textBoxRecherche;
        private System.Windows.Forms.Label labelRecherche;
        private System.Windows.Forms.ListView listViewEnquetes;
    }
}