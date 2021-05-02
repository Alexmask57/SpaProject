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

        private void OuvrirEnquete_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
