using SPA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SPA
{
    public partial class Admin : Form
    {
        public static Personne utilisateur = new Personne();
        public static Accueil pageConnexion;

        public Admin(Accueil page, Personne admin)
        {
            utilisateur = admin;
            pageConnexion = page;
            InitializeComponent();
        }

        private void checkBoxSal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSal.Checked)
            {
                checkBoxBenevole.Checked = false;
                textBoxLogin.Enabled = true;
                textBoxMotDePasse.Enabled = true; ;
            }
            else
            {
                checkBoxBenevole.Checked = true;
                textBoxLogin.Enabled = false;
                textBoxMotDePasse.Enabled = false;
                textBoxLogin.Text = "";
                textBoxMotDePasse.Text = "";
            }
        }

        private void checkBoxBenevole_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBenevole.Checked)
            {
                checkBoxSal.Checked = false;
                textBoxLogin.Enabled = false;
                textBoxMotDePasse.Enabled = false;
                textBoxLogin.Text = "";
                textBoxMotDePasse.Text = "";
            }
            else
            {
                checkBoxSal.Checked = true;
                textBoxLogin.Enabled = true;
                textBoxMotDePasse.Enabled = true; ;
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (ValiderFormulaire())
            {
                EnvoiDonnees();
                pageConnexion.RefreshPage();
                this.Close();
            }
        }

        private void EnvoiDonnees()
        {
            Personne personne = new Personne
            {
                Nom = textBoxNom.Text,
                Prenom = textBoxPrenom.Text,
                Adresse = textBoxAdresse.Text,
                Code_postal = Int32.Parse(textBoxCodePostal.Text),
                Ville = textBoxVille.Text,
                Email = textBoxEmail.Text,
                Salarie = checkBoxSal.Checked,
                Benevole = checkBoxBenevole.Checked,
                Admin = checkBoxAdmin.Checked
            };
            int id  = Personne.AddPersonneBdd(personne);
            if (personne.Salarie)
            {
                Session session = new Session
                {
                    Id = id,
                    Login = textBoxLogin.Text,
                    Password = textBoxMotDePasse.Text
                };
                Session.AddSession(session);
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




            if (!lettres_regex.IsMatch(textBoxPrenom.Text))
            {
                labelErrorPrenom.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorPrenom.Visible = false;

            if (!lettres_regex.IsMatch(textBoxVille.Text))
            {
                labelErrorVille.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorVille.Visible = false;

            if (!adresse_email_regex.IsMatch(textBoxEmail.Text))
            {
                labelErrorEmail.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorEmail.Visible = false;

            if (!lettres_regex.IsMatch(textBoxNom.Text))
            {
                labelErrorNom.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorNom.Visible = false;

            if (!code_postal_regex.IsMatch(textBoxCodePostal.Text))
            {
                labelCodePostal.Visible = true;
                enquete_complete = false;
            }
            else
                labelCodePostal.Visible = false;

            if (!alphanumeriques_regex.IsMatch(textBoxAdresse.Text))
            {
                labelErrorAdresse.Visible = true;
                enquete_complete = false;
            }
            else
                labelErrorAdresse.Visible = false;

            if (checkBoxBenevole.Checked == false && checkBoxSal.Checked == false)
            {
                labelErrorCheckBox.Visible = true;
                enquete_complete = false;
            }
            else
            {
                if (checkBoxSal.Checked)
                {
                    if (!alphanumeriques_regex.IsMatch(textBoxLogin.Text))
                    {
                        labelErrorLogin.Text = "Login manquant ou invalide";
                        labelErrorLogin.Visible = true;
                        enquete_complete = false;
                    }
                    else
                    {
                        labelErrorLogin.Visible = false;
                        int test = Session.ExistSession(textBoxLogin.Text);
                        if (Session.ExistSession(textBoxLogin.Text) != -1)
                        {
                            labelErrorLogin.Text = "Login existant";
                            labelErrorLogin.Visible = true;
                        }
                    }


                    if (!alphanumeriques_regex.IsMatch(textBoxMotDePasse.Text))
                    {
                        labelErrorMDP.Visible = true;
                        enquete_complete = false;
                    }
                    else
                        labelErrorMDP.Visible = false;
                }
                else
                {
                    labelErrorLogin.Visible = false;
                    labelErrorMDP.Visible = false;
                }
                labelErrorCheckBox.Visible = false;
            }
            return enquete_complete;
        }
    }
}
