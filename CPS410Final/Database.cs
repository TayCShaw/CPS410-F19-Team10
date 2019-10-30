using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPS410Final
{
    public class Database
    {
        static string connectionstring = "Data Source=tutorsite.database.windows.net;Initial Catalog=siteDB;User ID=team10;Password=Cps410Cps410;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



        /************** DATABASE OPERATIONS **************/
        static void openDB()
        {
           // connection.Open();
        }

        static void closeDB()
        {
            //connection.Close();
        }


        static Boolean nameExists(String username)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            SqlDataReader reader;
            SqlCommand search = new SqlCommand("SELECT * FROM Users WHERE userName = @username", connection);
            search.Parameters.AddWithValue("@username", username);

            connection.Open();

            reader = search.ExecuteReader();
            reader.Read();

            if (!reader.HasRows)
            {
                // Username doesn't exist
                return false;
            }
            else
            {
                return true;
            }


        }

        public static Boolean addNewUser(String email, String username, String password)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            if (nameExists(username))
            {
                // Username is already found
                return false;
            }
            else
            {
                // Username does not already exist
                SqlCommand insertUser = new SqlCommand("INSERT INTO Users (UserID, Username, UserPassword, UserSalt, UserEmail) values (@userid, @username, @userpassword, @usersalt, @email)", connection);
                SqlCommand count = new SqlCommand("Select max(UserID) from Users", connection);
                String userSalt;
                // Should we have them confirm their password?

                
                // open database for interaction
                connection.Open();

                // Set the userID to be assigned

                int newuserID;
                try
                {
                    newuserID = (Int32)count.ExecuteScalar() + 1;
                }
                catch (InvalidCastException e)
                {
                    newuserID = 0;
                }

                // Generate a salt for the new user and generate the hashed/salted password
                Security sclass = new Security();
                userSalt = Security.genSalt();
                String hashedPass = Security.Sha256((password + userSalt));

                // Assign parameters to SQL INSERT command
                insertUser.Parameters.AddWithValue("@userid", newuserID);
                insertUser.Parameters.AddWithValue("@username", username);
                insertUser.Parameters.AddWithValue("@userpassword", hashedPass);
                insertUser.Parameters.AddWithValue("@usersalt", userSalt);
                insertUser.Parameters.AddWithValue("@email", email);

                // Adds the user to the database. (OPTIONAL: Returns an int signifying how many rows were affected. Should only be 1?)
                insertUser.ExecuteNonQuery();

                connection.Close();
                return true;
            }

        }

        static void checkCredentials(String username, String password)
        {
 /*           openDB();
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
        */
        }

        /************** END DATABASE OPERATIONS **************/

 /*       static SqlConnectionStringBuilder connectionBuilder()
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

        } */
    }
}
 
 