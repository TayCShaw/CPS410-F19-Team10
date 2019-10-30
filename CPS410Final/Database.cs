using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPS410Final
{
    public class Database
    {
        static string connectionstring = connectionBuilder().ConnectionString;

        static SqlConnectionStringBuilder builder;


        /************** DATABASE OPERATIONS **************/
        static void openDB()
        {
            connection.Open();
        }

        static void closeDB()
        {
            connection.Close();
        }

        static void query()
        {

        }

        static void addNewUser()
        {

        }

        static void checkCredentials(String username, String password)
        {
            openDB();
            SqlConnection connect = new SqlConnection(connectionstring);
            SqlCommand search = new SqlCommand("SELECT * FROM Users WHERE userName = @username", connect);

            search.Parameters.AddWithValue("@username", username);
            try
            {
                connect.Open();
                SqlDataReader reader = search.ExecuteReader();
                reader.Read();

                if (!reader.HasRows)
                {
                    
                }
                else
                {
                    pass = Security.Sha256(password);
                }
            }
            catch (Exception er)
            {
                lblErrorMessages.Text = er.ToString();
            }
            finally
            {
                connection.Close();
            }
        }

        search.ExecuteReader();
        }

        /************** END DATABASE OPERATIONS **************/

        static SqlConnectionStringBuilder connectionBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.ConnectionString = "Data Source = tutorsite.database.windows.net; Initial Catalog = siteDB; User ID = team10; " +
                "Password = ********; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite;" +
                " MultiSubnetFailover = False";
            builder.DataSource = "tutorsite.database.windows.net";
            builder.UserID = "team10";
            builder.Password = "Cps410Cps410";
            builder.InitialCatalog = "siteDB";

            return builder;

        }
    }
}
 
 