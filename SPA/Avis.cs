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
    public partial class Avis : Form
    {

        public static Personne utilisateur = new Personne();
        public static Enquete enquete = new Enquete();
        public static ModifierEnquete pageModifier;
        public static bool voirAvis;

        public Avis(Personne user, Enquete enq, ModifierEnquete page, bool showAvis)
        {
            voirAvis = showAvis;
            utilisateur = user;
            enquete = enq;
            pageModifier = page;
            InitializeComponent();
        }

        private void Avis_Load(object sender, EventArgs e)
        {
            if (voirAvis)
            {
                buttonAnnuler.Visible = false;
                buttonEnregistrer.Visible = false;
                label1.Text = "Avis du titulaire de l'enquête sur l'enquête";
            }
            else
            {

            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            pageModifier.GetAvis(false, null);
            this.Close();
        }

        private void buttonEnregistrer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text)){
                labelErrorAvis.Visible = false;
                pageModifier.GetAvis(true, richTextBox1.Text);
                this.Close();
            }
            else
            {
                labelErrorAvis.Visible = true;
            }
        }
    }
}
