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
        public static Personne utilisateur = new Personne();
        public Accueil(Personne utilisateurConnecte)
        {
            utilisateur = utilisateurConnecte;
            InitializeComponent();
        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            labelTitre.Text = "Bienvenue " + utilisateur.Prenom +" " + utilisateur.Nom;
            List<Enquete> list_enquetes = Enquete.GetEnquetes();
            if(list_enquetes.Count > 0)
            {
                foreach (Enquete enquete in list_enquetes)
                {
                    ListViewItem item = new ListViewItem(enquete.Id);
                    item.SubItems.Add(enquete.Titulaire_enquete.Nom + " " + enquete.Titulaire_enquete.Prenom);
                    item.SubItems.Add(enquete.Delegue_enqueteur.Nom + " " + enquete.Delegue_enqueteur.Prenom);
                    item.SubItems.Add(enquete.Infracteur.Nom + " " + enquete.Infracteur.Prenom);
                    item.SubItems.Add(enquete.Plaignant.Nom + " " + enquete.Plaignant.Prenom);
                    item.SubItems.Add(enquete.Etat.ToString());
                    item.SubItems.Add(enquete.OuvertParLeSiege.ToString());
                    item.SubItems.Add(enquete.Avis);
                    listViewEnquetes.Items.Add(item);
                }
            }
        }

        private void buttonCreateEnquete_Click(object sender, EventArgs e)
        {
            OuvrirEnquete ouvrirEnquete = new OuvrirEnquete(utilisateur);
            ouvrirEnquete.Show();
        }

        private void buttonDeleteEnquete_Click(object sender, EventArgs e)
        {

        }

        private void buttonModifyEnquetes_Click(object sender, EventArgs e)
        {
           //ModifierEnquete modifierEnquete = new ModifierEnquete();
           //modifierEnquete.Show();
        }

        private void listViewEnquetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewEnquetes.SelectedItems.Count > 0)
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
    }
}
