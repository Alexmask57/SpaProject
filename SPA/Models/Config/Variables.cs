using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SPA.Models
{
    public static class Variables
    {
        public static readonly string connectionSql = "Server = localhost\\SQLEXPRESS; Database = SPA; Trusted_Connection = True;";

        public static readonly string pathUploadFile = AppDomain.CurrentDomain.BaseDirectory; //"~\\FichiersUpload\\"
    }
}
