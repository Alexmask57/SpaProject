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
using System.Diagnostics;

namespace SPA
{
    public partial class ModifierEnquete : Form
    {

        private List<string> etat = new List<string> { "En cours", "Rendue", "Terminée" };
        public static Personne utilisateur = new Personne();
        public static Enquete enquete = new Enquete();
        public static Accueil accueil;
        public ModifierEnquete(Accueil accueilMenu, Personne utilisateurConnecte, Enquete enqueteAModifier)
        {
            accueil = accueilMenu;
            utilisateur = utilisateurConnecte;
            enquete = enqueteAModifier;
            InitializeComponent();
        }
        private void ModifierEnquete_Load(object sender, EventArgs e)
        {
            if (utilisateur == enquete.Delegue_enqueteur || utilisateur == enquete.Titulaire_enquete || utilisateur.Admin)
            {
                buttonEnregistrer.Enabled = true;
            }
            else
            {
                comboBoxEtat.Enabled = false;
                comboBoxAnimaux.Enabled = false;
                comboBoxDelegue.Enabled = false;
                comboBoxRace.Enabled = false;
                comboBoxAnimaux.Enabled = false;
                comboBoxTitulaire.Enabled = false;
                textBoxAdresseInfracteur.Enabled = false;
                textBoxAdressePlaignant.Enabled = false;
                textBoxCodePostalInfracteur.Enabled = false;
                textBoxCodePostalPlaignant.Enabled = false;
                textBoxEmailInfracteur.Enabled = false;
                textBoxEmailPlaignant.Enabled = false;
                textBoxNomInfracteur.Enabled = false;
                textBoxNomPlaignant.Enabled = false;
                textBoxPrenomInfracteur.Enabled = false;
                textBoxPrenomPlaignant.Enabled = false;
                textBoxVilleInfracteur.Enabled = false;
                textBoxVillePlaignant.Enabled = false;

                buttonAjouterFichier.Enabled = false;
                buttonAjouter.Enabled = false;
                buttonSupprimer.Enabled = false;
                buttonSupprimerFichier.Enabled = false;

                richTextBoxMotif.Enabled = false;
                
                buttonEnregistrer.Enabled = false;
            }

            comboBoxEtat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEtat.Items.Add(etat[0].ToString());
            comboBoxEtat.Items.Add(etat[1].ToString());
            comboBoxEtat.Items.Add(etat[2].ToString());
            comboBoxEtat.SelectedIndex = comboBoxEtat.FindStringExact(etat[enquete.Etat]);

            comboBoxAnimaux.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDelegue.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRace.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTitulaire.DropDownStyle = ComboBoxStyle.DropDownList;

            //Remplissage box titulaire et delegue
            foreach (Personne personne in Personne.GetSalarieBenvole())
            {
                comboBoxDelegue.Items.Add(personne.Nom + " " + personne.Prenom);
                comboBoxTitulaire.Items.Add(personne.Nom + " " + personne.Prenom);

                if (enquete.Titulaire_enquete.Nom == personne.Nom && enquete.Titulaire_enquete.Prenom == personne.Prenom)
                    comboBoxTitulaire.SelectedIndex = comboBoxTitulaire.FindStringExact(personne.Nom + " " + personne.Prenom);
                if (enquete.Delegue_enqueteur.Nom == personne.Nom && enquete.Delegue_enqueteur.Prenom == personne.Prenom)
                    comboBoxDelegue.SelectedIndex = comboBoxDelegue.FindStringExact(personne.Nom + " " + personne.Prenom);
            }

            foreach (Race_animal animal in Race_animal.GetRace_Animals())
            {
                if (!comboBoxAnimaux.Items.Contains(animal.Animal))
                {
                    comboBoxAnimaux.Items.Add(animal.Animal);
                }
            }
            //REMPLIR CHAQUE ELEMENT

            //Infracteur
            textBoxNomInfracteur.Text = enquete.Infracteur.Nom;
            textBoxPrenomInfracteur.Text = enquete.Infracteur.Prenom;
            textBoxAdresseInfracteur.Text = enquete.Infracteur.Adresse;
            textBoxCodePostalInfracteur.Text = enquete.Infracteur.Code_postal.ToString();
            textBoxEmailInfracteur.Text = enquete.Infracteur.Email;
            textBoxVilleInfracteur.Text = enquete.Infracteur.Ville;

            //Plaignant
            textBoxNomPlaignant.Text = enquete.Plaignant.Nom;
            textBoxPrenomPlaignant.Text = enquete.Plaignant.Prenom;
            textBoxAdressePlaignant.Text = enquete.Plaignant.Adresse;
            textBoxCodePostalPlaignant.Text = enquete.Plaignant.Code_postal.ToString();
            textBoxEmailPlaignant.Text = enquete.Plaignant.Email;
            textBoxVillePlaignant.Text = enquete.Plaignant.Ville;

            //Motif
            richTextBoxMotif.Text = enquete.Motif;

            //Animaux
            foreach(Animaux_enquete animal in enquete.Animaux)
            {
                ListViewItem item = new ListViewItem(animal.Race.Animal);
                item.SubItems.Add(animal.Race.Nom_race);
                item.SubItems.Add(animal.Nombre.ToString());
                listViewAnimaux.Items.Add(item);
            }

            //Documents
            foreach (Document document in enquete.Document)
            {
                ListViewItem item = new ListViewItem(document.Chemin);
                item.SubItems.Add(Path.Combine(Variables.pathUploadFile, document.Chemin));
                listViewDocuments.Items.Add(item);
            }

            //Commentaires
            foreach (Commentaire commentaire in enquete.Commentaire)
            {
                ListViewItem item = new ListViewItem(commentaire.Date.ToString("dd/MM/yyyy HH:mm:ss"));
                item.SubItems.Add(commentaire.Detail);
                listViewCommentaires.Items.Add(item);
            }
        }
        private void buttonEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire())
            {
                labelErrorEnquete.Visible = true;
            }
            else
            {
                EnvoiDonnees();
                accueil.RefreshPage();
                this.Close();
            }
        }
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)comboBoxAnimaux.SelectedItem) &&
               !string.IsNullOrEmpty((string)comboBoxRace.SelectedItem) &&
               numericUpDownNombre.Value > 0)
            {
                /*
                ListViewItem item = new ListViewItem((string)comboBoxAnimaux.SelectedItem);
                item.SubItems.Add((string)comboBoxRace.SelectedItem);
                item.SubItems.Add(numericUpDownNombre.Value.ToString());
                listViewAnimaux.Items.Add(item);
                labelErrorAnimaux.Visible = false;
                */

                string Race = (string)comboBoxRace.SelectedItem;
                int nombre = Int32.Parse(numericUpDownNombre.Value.ToString());
                string animal = (string)comboBoxAnimaux.SelectedItem;
                bool exist = false;
                foreach (ListViewItem item in listViewAnimaux.Items)
                {
                    if (animal == item.SubItems[0].Text && Race == item.SubItems[1].Text)
                    {
                        exist = true;
                        int nb = nombre + Int32.Parse(item.SubItems[2].Text);
                        item.SubItems[2].Text = nb.ToString();
                    }
                }
                if (!exist)
                {
                    ListViewItem item = new ListViewItem((string)comboBoxAnimaux.SelectedItem);
                    item.SubItems.Add((string)comboBoxRace.SelectedItem);
                    item.SubItems.Add(numericUpDownNombre.Value.ToString());
                    listViewAnimaux.Items.Add(item);
                }
                labelErrorAnimaux.Visible = false;
            }
            else
            {
                labelErrorAnimaux.Visible = true;
            }
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (listViewAnimaux.Items.Count > 0)
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
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.*", ValidateNames = true, Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string f in ofd.FileNames)
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

        private bool ValiderFormulaire()
        {
            //Creation des regex
            Regex lettres_regex = new Regex("^[a-zA-Z]+$");
            Regex adresse_email_regex = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
            Regex code_postal_regex = new Regex("^((0[1-9])|([1-8][0-9])|(9[0-8])|(2A)|(2B))[0-9]{3}$");
            Regex alphanumeriques_regex = new Regex("^[a-zA-Z0-9,.;:?!+\\-=() ]+$");

            bool enquete_complete = true;

            //Le titulaire ne peut etre aussi le delegue
            if (string.IsNullOrEmpty(comboBoxTitulaire.Text) || string.IsNullOrEmpty(comboBoxDelegue.Text))
            {
                labelErrorTitulaireDelegue.Text = "Selectionner un Titulaire et un Délégué";
                labelErrorTitulaireDelegue.Visible = true;
                enquete_complete = false;
            }
            else if (comboBoxTitulaire.Text == comboBoxDelegue.Text)
            {
                labelErrorTitulaireDelegue.Text = "Le Titulaire ne peut être aussi le Délégué";
                labelErrorTitulaireDelegue.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorTitulaireDelegue.Visible = false;

            if (!lettres_regex.IsMatch(textBoxPrenomPlaignant.Text) ||
               !lettres_regex.IsMatch(textBoxNomPlaignant.Text))
            {
                labelErrorNomPrenomPlaignant.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorNomPrenomPlaignant.Visible = false;

            if (!lettres_regex.IsMatch(textBoxPrenomInfracteur.Text) ||
                !lettres_regex.IsMatch(textBoxNomInfracteur.Text))
            {
                labelErrorNomPrenomInfracteur.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorNomPrenomInfracteur.Visible = false;

            if (!alphanumeriques_regex.IsMatch(textBoxAdressePlaignant.Text))
            {
                labelErrorAdressePlaignant.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorAdressePlaignant.Visible = false;

            if (!alphanumeriques_regex.IsMatch(textBoxAdresseInfracteur.Text))
            {
                labelErrorAdresseInfracteur.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorAdresseInfracteur.Visible = false;

            if (!lettres_regex.IsMatch(textBoxVillePlaignant.Text))
            {
                labelErrorVillePlaignant.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorVillePlaignant.Visible = false;

            if (!lettres_regex.IsMatch(textBoxVilleInfracteur.Text))
            {
                labelErrorVilleInfracteur.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorVilleInfracteur.Visible = false;

            if (!code_postal_regex.IsMatch(textBoxCodePostalPlaignant.Text))
            {
                labelErrorCodePostalPlaignant.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorCodePostalPlaignant.Visible = false;

            if (!code_postal_regex.IsMatch(textBoxCodePostalInfracteur.Text))
            {
                labelErrorCodePostalInfracteur.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorCodePostalInfracteur.Visible = false;

            if (!adresse_email_regex.IsMatch(textBoxEmailPlaignant.Text))
            {
                labelErrorEmailPlaignant.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorEmailPlaignant.Visible = false;

            if (!adresse_email_regex.IsMatch(textBoxEmailInfracteur.Text))
            {
                labelErrorEmailInfracteur.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorEmailInfracteur.Visible = false;

            if (!alphanumeriques_regex.IsMatch(richTextBoxMotif.Text))
            {
                labelErrorMotif.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorMotif.Visible = false;

            if (listViewAnimaux.Items.Count <= 0)
            {
                labelErrorAnimaux.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorAnimaux.Visible = false;

            return enquete_complete;
        }

        private void EnvoiDonnees()
        {
            List<Animaux_enquete> list_animaux = new List<Animaux_enquete>();
            foreach (ListViewItem item in listViewAnimaux.Items)
            {
                Animaux_enquete animal = new Animaux_enquete
                {
                    Enquete = new Enquete { Id = enquete.Id },
                    Race = Race_animal.GetRace_AnimalBdd(item.SubItems[0].Text, item.SubItems[1].Text),
                    Nombre = Int32.Parse(item.SubItems[2].Text)
                };
                list_animaux.Add(animal);
            }

            List<Commentaire> list_commentaires = new List<Commentaire>();
            foreach (ListViewItem item in listViewCommentaires.Items)
            {
                Commentaire commentaire = new Commentaire
                {
                    Enquete = new Enquete { Id = enquete.Id },
                    Date = DateTime.Parse(item.SubItems[0].Text),
                    Detail = item.SubItems[1].Text
                };
                list_commentaires.Add(commentaire);
            }

            bool exists = System.IO.Directory.Exists(Variables.pathUploadFile);

            if (!exists)
                System.IO.Directory.CreateDirectory(Variables.pathUploadFile);

            List<Document> documents = new List<Document>();
            foreach (ListViewItem item in listViewDocuments.Items)
            {
                if (Document.ExistDocument(item.SubItems[0].Text) == -1)
                {
                    string filename = @Path.GetFileNameWithoutExtension(item.SubItems[0].Text);
                    string extension = @Path.GetExtension(item.SubItems[0].Text);
                    string file = @filename + DateTime.Now.ToString("ddMMyyHHmm") + extension;
                    string sourceFile = @item.SubItems[1].Text;
                    string destFile = @System.IO.Path.Combine(Variables.pathUploadFile, file);
                    System.IO.File.Copy(sourceFile, destFile, true);
                    Document doc = new Document { Chemin = file, Date = DateTime.Now };
                    documents.Add(doc);
                    Path.Combine(Variables.pathUploadFile, file);
                }
            };
            Enquete enquete2 = new Enquete
            {
                Id = enquete.Id,
                Plaignant = new Personne
                {
                    Nom = textBoxNomPlaignant.Text,
                    Prenom = textBoxPrenomPlaignant.Text,
                    Adresse = textBoxAdressePlaignant.Text,
                    Ville = textBoxVillePlaignant.Text,
                    Code_postal = Int32.Parse(textBoxCodePostalPlaignant.Text),
                    Email = textBoxEmailPlaignant.Text
                },
                Infracteur = new Personne
                {
                    Nom = textBoxNomInfracteur.Text,
                    Prenom = textBoxPrenomInfracteur.Text,
                    Adresse = textBoxAdresseInfracteur.Text,
                    Ville = textBoxVilleInfracteur.Text,
                    Code_postal = Int32.Parse(textBoxCodePostalInfracteur.Text),
                    Email = textBoxEmailInfracteur.Text
                },
                Titulaire_enquete = new Personne
                {
                    Nom = comboBoxTitulaire.SelectedItem.ToString().Split(new char[] { ' ' })[0],
                    Prenom = comboBoxTitulaire.SelectedItem.ToString().Split(new char[] { ' ' })[1]
                },
                Delegue_enqueteur = new Personne
                {
                    Nom = comboBoxDelegue.SelectedItem.ToString().Split(new char[] { ' ' })[0],
                    Prenom = comboBoxDelegue.SelectedItem.ToString().Split(new char[] { ' ' })[1]
                },
                Etat = etat.IndexOf(comboBoxEtat.SelectedItem.ToString()),
                Motif = richTextBoxMotif.Text,
                Animaux = list_animaux,
                Document = documents,
                Commentaire = list_commentaires
            };
            Enquete.UpdateEnqueteBdd(enquete2);
        }

        private void comboBoxEtat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enquete.Etat == 1 && comboBoxEtat.SelectedIndex.ToString() == etat[0])
            {
                string message = "Vous ne pouvez pas passer de \"Rendue\" à \"En cours\"";
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    comboBoxEtat.Text = etat[0];
                }
            }
        }

        private void buttonouvrirFichier_Click(object sender, EventArgs e)
        {
            if (listViewDocuments.SelectedItems.Count > 0)
            {
                string test = listViewDocuments.SelectedItems[0].SubItems[1].Text;
                Process fileopener = new Process();
                fileopener.StartInfo.FileName = "explorer";
                fileopener.StartInfo.Arguments = "\"" + listViewDocuments.SelectedItems[0].SubItems[1].Text + "\"";
                fileopener.Start();
            }
        }

        private void listViewDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDocuments.SelectedItems.Count > 0)
            {
                buttonouvrirFichier.Enabled = true;
            }
            else
            {
                buttonouvrirFichier.Enabled = false;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCommentaires.SelectedItems.Count > 0)
            {
                buttonDeletecommentaire.Enabled = true;
                buttonModifierCommentaire.Enabled = true;
                richTextBoxCommentaire.Text = listViewCommentaires.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                buttonDeletecommentaire.Enabled = false;
                buttonModifierCommentaire.Enabled = false;
            }
        }

        private void buttonAjoutCommentaire_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            item.SubItems.Add(richTextBoxCommentaire.Text);
            listViewCommentaires.Items.Add(item);
            richTextBoxCommentaire.Text = "";
        }

        private void buttonDeletecommentaire_Click(object sender, EventArgs e)
        {
            listViewCommentaires.Items.Remove(listViewCommentaires.SelectedItems[0]);
        }

        private void buttonModifierCommentaire_Click(object sender, EventArgs e)
        {
            listViewCommentaires.SelectedItems[0].SubItems[1].Text = richTextBoxCommentaire.Text;
        }
    }
}
