using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace agendaContactosS4
{
    internal class Conexion
    {
        public static SqlConnection Conecto()
        {
            SqlConnection cnx = new SqlConnection("SERVER=WONDER\\SQLEXPRESS;DATABASE=BibliotecaVirtualBD;integrated security=true;");
            cnx.Open();
            return cnx;
        }
    }
}
