using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace test
{
    internal class DBHelper
    {
        static public SqlConnection sqlConnection = null;

        public static void dbOpenConnection(ref SqlConnection sqlConnection)
        {
            string loc = Environment.CurrentDirectory;
            loc = loc.Replace("bin\\Debug", "");
            sqlConnection = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={loc}Database1.mdf;Integrated Security=True");
            sqlConnection.Open();
        }
    }
}
