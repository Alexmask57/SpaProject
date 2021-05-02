using SPA.Models;
using SPA.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA
{
    public partial class ApplicationSPAConnexion : Form
    {
        public ApplicationSPAConnexion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            string valueLogin = textBoxIdentifiant.Text.Trim();
            string valuePassword = textBoxPassword.Text.Trim();
            if (!string.IsNullOrEmpty(valueLogin) && !string.IsNullOrEmpty(valuePassword))
            {
                int res = verifConnexion(valueLogin, valuePassword);
                if (res != -1)
                {
                    Personne utilisateur = Personne.GetPersonneById(res);
                    labelConnexionError.Visible = false;
                    Accueil accueil = new Accueil(utilisateur);
                    accueil.Show();
                    this.Hide();
                }
                else
                {
                    labelConnexionError.Visible = true;
                }
            }
        }

        private int verifConnexion(string login, string password)
        {
            return Session.ExistSession(login, password);
            
        }
    }
}
