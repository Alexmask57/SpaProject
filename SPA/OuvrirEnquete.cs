using SPA.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPA
{
    public partial class OuvrirEnquete : Form
    {
        public static Personne utilisateur = new Personne();
        public OuvrirEnquete(Personne utilisateurConnecte)
        {
            utilisateur = utilisateurConnecte;
            InitializeComponent();
        }
        private void OuvrirEnquete_Load(object sender, EventArgs e)
        {
            foreach (Personne personne in Personne.GetSalarieBenvole())
            {
                comboBoxDelegue.Items.Add(personne.Nom + " " + personne.Prenom);
                comboBoxTitulaire.Items.Add(personne.Nom + " " + personne.Prenom);
            }

            foreach (Race_animal animal in Race_animal.GetRace_Animals())
            {
                if (!comboBoxAnimaux.Items.Contains(animal.Animal))
                {
                    comboBoxAnimaux.Items.Add(animal.Animal);
                }
            }
        }
        private void buttonEnregistrer_Click(object sender, EventArgs e)
        {
            bool enquete_complete = true;
            foreach (Control element in this.Controls)
            {
                if (element is Label && ((Label)element).ForeColor == Color.Red)
                {
                    element.Visible = false;
                }
            }
            if(textBoxPrenomPlaignant.Text == "" || textBoxNomPlaignant.Text == "")
            {
                labelErrorNomPrenomPlaignant.Visible = true;
                enquete_complete = false;
            }
            if (textBoxPrenomInfracteur.Text == "" || textBoxNomInfracteur.Text == "")
            {
                labelErrorNomPrenomInfracteur.Visible = true;
                enquete_complete = false;
            }
            if (textBoxAdressePlaignant.Text == "")
            {
                labelErrorAdressePlaignant.Visible = true;
                enquete_complete = false;
            }
            if (textBoxAdresseInfracteur.Text == "")
            {
                labelErrorAdresseInfracteur.Visible = true;
                enquete_complete = false;
            }
            if (textBoxVillePlaignant.Text == "")
            {
                labelErrorVillePlaignant.Visible = true;
                enquete_complete = false;
            }
            if (textBoxVilleInfracteur.Text == "")
            {
                labelErrorVilleInfracteur.Visible = true;
                enquete_complete = false;
            }
            if (textBoxCodePostalPlaignant.Text == "")
            {
                labelErrorCodePostalPlaignant.Visible = true;
                enquete_complete = false;
            }
            if (textBoxCodePostalInfracteur.Text == "")
            {
                labelErrorCodePostalInfracteur.Visible = true;
                enquete_complete = false;
            }
            if (textBoxEmailPlaignant.Text == "")
            {
                labelErrorEmailPlaignant.Visible = true;
                enquete_complete = false;
            }
            if (textBoxEmailInfracteur.Text == "")
            {
                labelErrorEmailInfracteur.Visible = true;
                enquete_complete = false;
            }
            if (richTextBoxMotif.Text == "")
            {
                labelErrorMotif.Visible = true;
                enquete_complete = false;
            }
            if (listViewAnimaux.Items.Count <= 0)
            {
                labelErrorMotif.Visible = true;
                enquete_complete = false;
            }
            if (!enquete_complete)
            {
                labelErrorEnquete.Visible = true;
            }
            else
            {
                // Enquete enquete1 = new Enquete { Id = "test", Plaignant = new Personne { Id = 1 } };
            }
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)comboBoxAnimaux.SelectedItem) &&
               !string.IsNullOrEmpty((string)comboBoxRace.SelectedItem) &&
               numericUpDownNombre.Value > 0)
            {
                ListViewItem item = new ListViewItem((string)comboBoxAnimaux.SelectedItem);
                item.SubItems.Add((string)comboBoxRace.SelectedItem);
                item.SubItems.Add(numericUpDownNombre.Value.ToString());
                listViewAnimaux.Items.Add(item);
                labelErrorAnimaux.Visible = false;
            }
            else
            {
                labelErrorAnimaux.Visible = true;
            } 
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if(listViewAnimaux.Items.Count>0)
            {
                foreach (ListViewItem item in listViewAnimaux.SelectedItems)
                {
                    listViewAnimaux.Items.Remove(item);
                }
            }
        }
        private void comboBoxAnimaux_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRace.Items.Clear();
            foreach (Race_animal animal in Race_animal.GetRace_Animals())
            {
                if (animal.Animal == (string)comboBoxAnimaux.SelectedItem)
                {
                    comboBoxRace.Items.Add(animal.Nom_race);
                }
            }
        }
        private void buttonAjouterFichier_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Filter="All files|*.*", ValidateNames=true, Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach(string f in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(f);
                        ListViewItem item = new ListViewItem(fi.Name);
                        item.SubItems.Add(fi.FullName);
                        listViewDocuments.Items.Add(item);
                    }
                }
            }
        }
        private void buttonSupprimerFichier_Click(object sender, EventArgs e)
        {
            if (listViewDocuments.Items.Count > 0)
            {
                foreach (ListViewItem item in listViewDocuments.SelectedItems)
                {
                    listViewDocuments.Items.Remove(item);
                }
            }
        }
    }
}
