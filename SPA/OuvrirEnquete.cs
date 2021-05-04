using SPA.Models;
using System;
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

        private void buttonEnregistrer_Click(object sender, EventArgs e)
        {
            String valuePrenomPlaignant = textBoxPrenomPlaignant.Text;
            // Enquete enquete1 = new Enquete { Id = "test", Plaignant = new Personne { Id = 1 } };
        }

        private void comboBoxTitulaire_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPlaignant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
