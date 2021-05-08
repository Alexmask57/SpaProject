
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
            this.columnHeaderID = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTitulaire = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDelegue = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderInfracteur = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPlaignant = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderEtat = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderOuvert = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderNbCommentaires = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderNbAnimaux = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderNbFichiers = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderNbAppels = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAvis = new System.Windows.Forms.ColumnHeader();
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
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1247, 107);
            this.panel1.TabIndex = 1;
            // 
            // textBoxRecherche
            // 
            this.textBoxRecherche.Location = new System.Drawing.Point(661, 55);
            this.textBoxRecherche.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxRecherche.Name = "textBoxRecherche";
            this.textBoxRecherche.Size = new System.Drawing.Size(240, 23);
            this.textBoxRecherche.TabIndex = 5;
            this.textBoxRecherche.TextChanged += new System.EventHandler(this.textBoxRecherche_TextChanged);
            // 
            // labelRecherche
            // 
            this.labelRecherche.AutoSize = true;
            this.labelRecherche.Location = new System.Drawing.Point(591, 58);
            this.labelRecherche.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelRecherche.Name = "labelRecherche";
            this.labelRecherche.Size = new System.Drawing.Size(68, 15);
            this.labelRecherche.TabIndex = 4;
            this.labelRecherche.Text = "Recherche :";
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Location = new System.Drawing.Point(58, 15);
            this.labelTitre.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(55, 15);
            this.labelTitre.TabIndex = 3;
            this.labelTitre.Text = "labelTitre";
            // 
            // buttonDeleteEnquete
            // 
            this.buttonDeleteEnquete.Enabled = false;
            this.buttonDeleteEnquete.Location = new System.Drawing.Point(327, 44);
            this.buttonDeleteEnquete.Name = "buttonDeleteEnquete";
            this.buttonDeleteEnquete.Size = new System.Drawing.Size(116, 49);
            this.buttonDeleteEnquete.TabIndex = 2;
            this.buttonDeleteEnquete.Text = "Supprimer une enquête";
            this.buttonDeleteEnquete.UseVisualStyleBackColor = true;
            this.buttonDeleteEnquete.Click += new System.EventHandler(this.buttonDeleteEnquete_Click);
            // 
            // buttonModifyEnquetes
            // 
            this.buttonModifyEnquetes.Enabled = false;
            this.buttonModifyEnquetes.Location = new System.Drawing.Point(194, 44);
            this.buttonModifyEnquetes.Name = "buttonModifyEnquetes";
            this.buttonModifyEnquetes.Size = new System.Drawing.Size(115, 49);
            this.buttonModifyEnquetes.TabIndex = 0;
            this.buttonModifyEnquetes.Text = "Modifier une enquête";
            this.buttonModifyEnquetes.UseVisualStyleBackColor = true;
            this.buttonModifyEnquetes.Click += new System.EventHandler(this.buttonModifyEnquetes_Click);
            // 
            // buttonCreateEnquete
            // 
            this.buttonCreateEnquete.Location = new System.Drawing.Point(58, 44);
            this.buttonCreateEnquete.Name = "buttonCreateEnquete";
            this.buttonCreateEnquete.Size = new System.Drawing.Size(116, 49);
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
            this.panelAccueil.Location = new System.Drawing.Point(1, 114);
            this.panelAccueil.Name = "panelAccueil";
            this.panelAccueil.Size = new System.Drawing.Size(1247, 514);
            this.panelAccueil.TabIndex = 2;
            // 
            // listViewEnquetes
            // 
            this.listViewEnquetes.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewEnquetes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderTitulaire,
            this.columnHeaderDelegue,
            this.columnHeaderInfracteur,
            this.columnHeaderPlaignant,
            this.columnHeaderEtat,
            this.columnHeaderOuvert,
            this.columnHeaderNbCommentaires,
            this.columnHeaderNbAnimaux,
            this.columnHeaderNbFichiers,
            this.columnHeaderNbAppels,
            this.columnHeaderAvis});
            this.listViewEnquetes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEnquetes.FullRowSelect = true;
            this.listViewEnquetes.HideSelection = false;
            this.listViewEnquetes.Location = new System.Drawing.Point(0, 0);
            this.listViewEnquetes.Margin = new System.Windows.Forms.Padding(1);
            this.listViewEnquetes.MultiSelect = false;
            this.listViewEnquetes.Name = "listViewEnquetes";
            this.listViewEnquetes.Size = new System.Drawing.Size(1247, 514);
            this.listViewEnquetes.TabIndex = 0;
            this.listViewEnquetes.UseCompatibleStateImageBehavior = false;
            this.listViewEnquetes.View = System.Windows.Forms.View.Details;
            this.listViewEnquetes.SelectedIndexChanged += new System.EventHandler(this.listViewEnquetes_SelectedIndexChanged);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            this.columnHeaderID.Width = 70;
            // 
            // columnHeaderTitulaire
            // 
            this.columnHeaderTitulaire.Text = "Titulaire";
            this.columnHeaderTitulaire.Width = 100;
            // 
            // columnHeaderDelegue
            // 
            this.columnHeaderDelegue.Text = "Delegue";
            this.columnHeaderDelegue.Width = 100;
            // 
            // columnHeaderInfracteur
            // 
            this.columnHeaderInfracteur.Text = "Infracteur";
            this.columnHeaderInfracteur.Width = 100;
            // 
            // columnHeaderPlaignant
            // 
            this.columnHeaderPlaignant.Text = "Plaignant";
            this.columnHeaderPlaignant.Width = 100;
            // 
            // columnHeaderEtat
            // 
            this.columnHeaderEtat.Text = "Etat";
            this.columnHeaderEtat.Width = 100;
            // 
            // columnHeaderOuvert
            // 
            this.columnHeaderOuvert.Text = "Ouvert";
            this.columnHeaderOuvert.Width = 100;
            // 
            // columnHeaderNbCommentaires
            // 
            this.columnHeaderNbCommentaires.Text = "Nbre Commentaires";
            this.columnHeaderNbCommentaires.Width = 120;
            // 
            // columnHeaderNbAnimaux
            // 
            this.columnHeaderNbAnimaux.Text = "Nbre Animaux";
            this.columnHeaderNbAnimaux.Width = 120;
            // 
            // columnHeaderNbFichiers
            // 
            this.columnHeaderNbFichiers.Text = "Nbre Fichiers";
            this.columnHeaderNbFichiers.Width = 120;
            // 
            // columnHeaderNbAppels
            // 
            this.columnHeaderNbAppels.Text = "Nbre Appels";
            this.columnHeaderNbAppels.Width = 120;
            // 
            // columnHeaderAvis
            // 
            this.columnHeaderAvis.Text = "Avis";
            this.columnHeaderAvis.Width = 100;
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 630);
            this.Controls.Add(this.panelAccueil);
            this.Controls.Add(this.panel1);
            this.Name = "Accueil";
            this.Text = "Accueil";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Accueil_FormClossing);
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
        private System.Windows.Forms.Button buttonDeleteEnquete;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.TextBox textBoxRecherche;
        private System.Windows.Forms.Label labelRecherche;
        private System.Windows.Forms.ListView listViewEnquetes;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderTitulaire;
        private System.Windows.Forms.ColumnHeader columnHeaderDelegue;
        private System.Windows.Forms.ColumnHeader columnHeaderInfracteur;
        private System.Windows.Forms.ColumnHeader columnHeaderPlaignant;
        private System.Windows.Forms.ColumnHeader columnHeaderEtat;
        private System.Windows.Forms.ColumnHeader columnHeaderAvis;
        private System.Windows.Forms.ColumnHeader columnHeaderNbAnimaux;
        private System.Windows.Forms.ColumnHeader columnHeaderOuvert;
        private System.Windows.Forms.ColumnHeader columnHeaderNbCommentaires;
        private System.Windows.Forms.ColumnHeader columnHeaderNbFichiers;
        private System.Windows.Forms.ColumnHeader columnHeaderNbAppels;
    }
}