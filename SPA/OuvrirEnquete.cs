﻿using SPA.Models;
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
            foreach(Personne personne in Personne.GetSalarieBenvole())
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
            String valuePrenomPlaignant = textBoxPrenomPlaignant.Text;
            // Enquete enquete1 = new Enquete { Id = "test", Plaignant = new Personne { Id = 1 } };
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty((string)comboBoxAnimaux.SelectedItem) && 
               !string.IsNullOrEmpty((string)comboBoxRace.SelectedItem) &&
               numericUpDownNombre.Value > 0)
            {
                ListViewItem item = new ListViewItem((string)comboBoxAnimaux.SelectedItem);
                item.SubItems.Add((string)comboBoxRace.SelectedItem);
                item.SubItems.Add(numericUpDownNombre.Value.ToString());
                listViewAnimaux.Items.Add(item);
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
