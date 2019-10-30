using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPS410Final
{
    public class Database
    {
        static SqlConnection connection;
        static SqlConnectionStringBuilder builder;

        static void openDB(String[] args)
        {
            connection.Open();
        }

        static void closeDB()
        {
            connection.Close();
        }

        static void connectionBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "tutorsite.database.windows.net";
            builder.UserID = "team10";
            builder.Password = "Cps410Cps410";
            builder.InitialCatalog = "siteDB";
        }
    }
}