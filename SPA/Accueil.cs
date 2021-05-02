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
        }

        private void buttonCreateEnquete_Click(object sender, EventArgs e)
        {
            OuvrirEnquete ouvrirEnquete = new OuvrirEnquete(utilisateur);
            ouvrirEnquete.Show();
        }
    }
}
