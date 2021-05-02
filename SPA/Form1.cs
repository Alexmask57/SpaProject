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
    public partial class ApplicationSPA : Form
    {
        public ApplicationSPA()
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
                if (verifConnexion(valueLogin, valuePassword))
                {
                    labelConnexionError.Visible = false;
                    this.Close();
                }
                else
                {
                    labelConnexionError.Visible = true;
                }
            }
        }

        private bool verifConnexion(string login, string password)
        {
            if (SessionDAO.ExistSession(login, password))
                return true;
            return false;
        }
    }
}
