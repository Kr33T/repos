using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NewDesTasks
{
    internal class DBHelper
    {
        public static SqlConnection sqlConnection = null;

        public static void openConnetion(ref SqlConnection sqlConnection)
        {
            string loc = Environment.CurrentDirectory;
            loc = loc.Replace("bin\\Debug", "");
            sqlConnection = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={loc}Database1.mdf;Integrated Security=True");
            sqlConnection.Open();
        }
    }
}
