using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPA.Models
{
    public partial class Accueil : Form
    {
        private bool cliqueDeco = false;
        private List<string> etat = new List<string> { "En cours", "Rendue", "Terminée" };
        public static Personne utilisateur = new Personne();
        public static ApplicationSPAConnexion pageConnexion;
        public Accueil(ApplicationSPAConnexion connexionMenu, Personne utilisateurConnecte)
        {
            pageConnexion = connexionMenu;
            utilisateur = utilisateurConnecte;
            InitializeComponent();
        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            if (utilisateur.Admin)
            {
                buttonAdmin.Visible = true;
            }
            labelTitre.Text = "Bienvenue " + utilisateur.Prenom + " " + utilisateur.Nom;
            RefreshPage();
        }

        private void Accueil_FormClossing(object sender, FormClosingEventArgs e)
        {
            if (!cliqueDeco)
                pageConnexion.Close();
            cliqueDeco = false;
        }

        public void RefreshPage()
        {
            foreach (ListViewItem item in listViewEnquetes.Items)
            {
                item.Remove();
            }
            List<Enquete> list_enquetes = Enquete.GetEnquetes();
            if (list_enquetes.Count > 0)
            {
                foreach (Enquete enquete in list_enquetes)
                {
                    string ouvertSiege = enquete.OuvertParLeSiege ? "Oui" : "Non";
                    ListViewItem item = new ListViewItem(enquete.Id);
                    item.SubItems.Add(enquete.Titulaire_enquete.Nom + " " + enquete.Titulaire_enquete.Prenom);
                    item.SubItems.Add(enquete.Delegue_enqueteur.Nom + " " + enquete.Delegue_enqueteur.Prenom);
                    item.SubItems.Add(enquete.Infracteur.Nom + " " + enquete.Infracteur.Prenom);
                    item.SubItems.Add(enquete.Plaignant.Nom + " " + enquete.Plaignant.Prenom);
                    item.SubItems.Add(etat[enquete.Etat]);
                    item.SubItems.Add(ouvertSiege);
                    item.SubItems.Add(Commentaire.NombreCommentaireEnquete(enquete).ToString());
                    item.SubItems.Add(Animaux_enquete.NombreAnimauxEnquete(enquete).ToString());
                    item.SubItems.Add(Document.NombreDocumentEnquete(enquete).ToString());
                    item.SubItems.Add(Appel.NombreAppelEnquete(enquete).ToString());
                    item.SubItems.Add(enquete.Avis);
                    listViewEnquetes.Items.Add(item);
                }
            }
        }

        private void buttonCreateEnquete_Click(object sender, EventArgs e)
        {
            OuvrirEnquete ouvrirEnquete = new OuvrirEnquete(this, utilisateur);
            ouvrirEnquete.Show();
            this.Hide();
        }

        private void buttonDeleteEnquete_Click(object sender, EventArgs e)
        {
            Enquete.DeleteEnquete(Enquete.GetEnquete(listViewEnquetes.SelectedItems[0].Text));
            listViewEnquetes.Items.Remove(listViewEnquetes.SelectedItems[0]);
        }

        private void buttonModifyEnquetes_Click(object sender, EventArgs e)
        {
            ModifierEnquete modifierEnquete = new ModifierEnquete(this, utilisateur, Enquete.GetEnquete(listViewEnquetes.SelectedItems[0].Text));
            modifierEnquete.Show();
        }

        private void listViewEnquetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEnquetes.SelectedItems.Count > 0)
            {
                buttonModifyEnquetes.Enabled = true;
                buttonDeleteEnquete.Enabled = true;
            }
            else
            {
                buttonModifyEnquetes.Enabled = false;
                buttonDeleteEnquete.Enabled = false;
            }
        }
        private void textBoxRecherche_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListViewItem foundItem = listViewEnquetes.FindItemWithText(textBoxRecherche.Text, true, 0, true);
                if (foundItem != null)
                {
                    listViewEnquetes.TopItem = foundItem;
                }
                textBoxRecherche.Text = "";
            }
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(this, utilisateur);
            admin.Show();
        }

        private void buttonDeconnexion_Click(object sender, EventArgs e)
        {
            cliqueDeco = true;
            pageConnexion.Show();
            this.Close();
        }
    }
}
