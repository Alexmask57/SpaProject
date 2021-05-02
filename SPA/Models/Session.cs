using SPA.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public static int ExistSession(string login, string password)
        {
            return SessionDAO.ExistSession(login, password);
        }
    }
}
