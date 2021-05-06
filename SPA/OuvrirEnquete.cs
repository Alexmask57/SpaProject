﻿using SPA.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
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
            //Creation des regex
            Regex lettres_regex = new Regex("^[a-zA-Z]+$");
            Regex adresse_email_regex = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
            Regex code_postal_regex = new Regex("^((0[1-9])|([1-8][0-9])|(9[0-8])|(2A)|(2B))[0-9]{3}$");
            Regex alphanumeriques_regex = new Regex("^[a-bA-B0-9,.;:?!+\\-=() ]+$");

            bool enquete_complete = true;
            foreach (Control element in this.Controls)
            {
                if (element is Label && ((Label)element).ForeColor == Color.Red)
                {
                    element.Visible = false;
                }
            }
            if(!lettres_regex.IsMatch(textBoxPrenomPlaignant.Text)||
               !lettres_regex.IsMatch(textBoxNomPlaignant.Text))
            {
                labelErrorNomPrenomPlaignant.Visible = true;
                enquete_complete = false;
            }
            if (!lettres_regex.IsMatch(textBoxPrenomInfracteur.Text)||
                !lettres_regex.IsMatch(textBoxNomInfracteur.Text))
            {
                labelErrorNomPrenomInfracteur.Visible = true;
                enquete_complete = false;
            }
            if (!alphanumeriques_regex.IsMatch(textBoxAdressePlaignant.Text))
            {
                labelErrorAdressePlaignant.Visible = true;
                enquete_complete = false;
            }
            if (!alphanumeriques_regex.IsMatch(textBoxAdresseInfracteur.Text))
            {
                labelErrorAdresseInfracteur.Visible = true;
                enquete_complete = false;
            }
            if (!lettres_regex.IsMatch(textBoxVillePlaignant.Text))
            {
                labelErrorVillePlaignant.Visible = true;
                enquete_complete = false;
            }
            if (!lettres_regex.IsMatch(textBoxVilleInfracteur.Text))
            {
                labelErrorVilleInfracteur.Visible = true;
                enquete_complete = false;
            }
            if (!code_postal_regex.IsMatch(textBoxCodePostalPlaignant.Text))
            {
                labelErrorCodePostalPlaignant.Visible = true;
                enquete_complete = false;
            }
            if (!code_postal_regex.IsMatch(textBoxCodePostalInfracteur.Text))
            {
                labelErrorCodePostalInfracteur.Visible = true;
                enquete_complete = false;
            }
            if (!adresse_email_regex.IsMatch(textBoxEmailPlaignant.Text))
            {
                labelErrorEmailPlaignant.Visible = true;
                enquete_complete = false;
            }
            if (!adresse_email_regex.IsMatch(textBoxEmailInfracteur.Text))
            {
                labelErrorEmailInfracteur.Visible = true;
                enquete_complete = false;
            }
            if (!alphanumeriques_regex.IsMatch(richTextBoxMotif.Text))
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
                //Enquete enquete1 = new Enquete { Id = "test", Plaignant = new Personne { Id = 1 } };
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
