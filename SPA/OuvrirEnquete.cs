using SPA.Models;
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
        public static Accueil accueil;
        public OuvrirEnquete(Accueil accueilMenu, Personne utilisateurConnecte)
        {
            accueil = accueilMenu;
            utilisateur = utilisateurConnecte;
            InitializeComponent();
        }
        private void OuvrirEnquete_Load(object sender, EventArgs e)
        {
            comboBoxAnimaux.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDelegue.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRace.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTitulaire.DropDownStyle = ComboBoxStyle.DropDownList;

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
        private void OuvrirEnquete_FormClossing(object sender, FormClosingEventArgs e)
        {
            accueil.Show();
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
                accueil.Show();
                this.Close();
            }
        }
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)comboBoxAnimaux.SelectedItem) &&
               !string.IsNullOrEmpty((string)comboBoxRace.SelectedItem) &&
               numericUpDownNombre.Value > 0)
            {
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
            foreach (ListViewItem item in listViewDocuments.Items)
            {
                string filename = Path.GetFileNameWithoutExtension(item.SubItems[0].Text);
                string extension = Path.GetExtension(item.SubItems[0].Text);
                string file = filename + DateTime.Now.ToString("ddMMyyHHmm") + extension;
                string sourceFile = item.SubItems[1].Text;
                string destFile = System.IO.Path.Combine(Variables.pathUploadFile, file);
                System.IO.File.Copy(sourceFile, destFile, true);
            };

            List<Animaux_enquete> list_animaux = new List<Animaux_enquete>();
            foreach (ListViewItem item in listViewAnimaux.Items)
            {
                Animaux_enquete animal = new Animaux_enquete
                {
                    Race = Race_animal.GetRace_AnimalBdd(item.SubItems[0].Text, item.SubItems[1].Text),
                    Nombre = Int32.Parse(item.SubItems[2].Text)
                };
                list_animaux.Add(animal);
            }
            List<Document> documents = new List<Document>();
            foreach (ListViewItem item in listViewDocuments.Items)
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
            };

            Enquete enquete = new Enquete
            {
                Id = checkBoxSiege.Checked ? textBoxIdEnquete.Text : null,
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
                Motif = richTextBoxMotif.Text,
                Animaux = list_animaux,
                Document = documents
            };
            Enquete.CreerEnqueteBdd(enquete);
        }

        private void checkBoxSiege_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSiege.Checked)
            {
                labelIdEnquete.Visible = true;
                textBoxIdEnquete.Visible = true;
            }
            else
            {
                labelIdEnquete.Visible = false;
                textBoxIdEnquete.Visible = false;
                textBoxIdEnquete.Text = "";
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
