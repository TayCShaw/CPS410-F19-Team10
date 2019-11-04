using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPS410Final
{
    public class Database
    {
        public static SqlConnection connection = new SqlConnection("Data Source=tutorsite.database.windows.net;Initial Catalog=siteDB;User ID=team10;Password=Cps410Cps410;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");



        /************** DATABASE OPERATIONS **************/
        static void openDB()
        {
           connection.Open();
        }

        static void closeDB()
        {
            connection.Close();
        }


        static Boolean nameExists(String username)
        {
            SqlDataReader reader;
            SqlCommand search = new SqlCommand("SELECT * FROM Users WHERE userName = @username", connection);
            search.Parameters.AddWithValue("@username", username);

            openDB();

            reader = search.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                closeDB();
                return true;
            }
            else
            {
                // Username doesn't exist
                closeDB();
                return false;
            }
        }


        public static String grabRole(String userID)
        {
            SqlCommand search = new SqlCommand("SELECT * FROM Users WHERE UserID = @userID", connection);
            search.Parameters.AddWithValue("@userID", userID);
            SqlDataReader reader;
            String role = "";

            openDB();
            reader = search.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                role = reader["Role"].ToString();
            }
            closeDB();
            return role;
        }


        public static String addNewUser(String email, String username, String password)
        {
            if (nameExists(username))
            {
                // Username is already found, return an error message.
                return "Username is taken. Please pick a new username.";
            }
            else
            {
                // Username does not already exist
                SqlCommand insertUser = new SqlCommand("INSERT INTO Users (UserID, Username, UserPassword, UserSalt, UserEmail, TimeCreated) values (@userid, @username, @userpassword, @usersalt, @email, @time)", connection);
                SqlCommand count = new SqlCommand("Select max(UserID) from Users", connection);
                String userSalt;


                // Open database for interaction
                openDB();

                // Set the userID to be assigned
                // Catches if the maxID number is nonexistent
                int newuserID;
                try
                {
                    newuserID = (Int32)count.ExecuteScalar() + 1;
                }
                catch (InvalidCastException)
                {
                    newuserID = 0;
                }


                // Generate a salt for the new user and generate the hashed/salted password
                userSalt = Security.genSalt();
                String hashedPass = Security.Sha256((password + userSalt));

                
                // Assign parameters to SQL INSERT command
                insertUser.Parameters.AddWithValue("@userid", newuserID);
                insertUser.Parameters.AddWithValue("@username", username);
                insertUser.Parameters.AddWithValue("@userpassword", hashedPass);
                insertUser.Parameters.AddWithValue("@usersalt", userSalt);
                insertUser.Parameters.AddWithValue("@email", email);
                insertUser.Parameters.AddWithValue("@time", DateTime.Now);


                /*
                 * Attempts to add the new user account to the database. If the addition is
                 * successful, the method returns "TRUE". If the addition is unsuccessful
                 * (in this case, for an error based on inserting to database), method returns
                 * "FALSE".
                 */
                if (insertUser.ExecuteNonQuery() != 0)
                {
                    closeDB();
                    return "TRUE";
                }
                else
                {
                    closeDB();
                    return "FALSE";
                }
            }

        }


        public static Boolean addNewSubject(String UserID, String SubjName, Boolean chkbox) {

            // Once created, take to a page OR Show something that will let the user create a new Subject
            SqlCommand createSubject = new SqlCommand("INSERT INTO Subjects (SubjectID, SubjectName, SubjectCreator, SubjectVisibility) values(@SubjectID, @SubjectName, @SubjectCreator, @SubjectVisibility)", Database.connection);
            SqlCommand count = new SqlCommand("Select max(SubjectID) from Subjects", Database.connection);
            String SubjectID;


            // Catches if the maxID number is nonexistent and assigns the SubjectID
            int intID;
            openDB();
            try
            {


                // Try to find the maximum ID (highest ID number so far) and add one to it to make new SubjectID
                intID = (Int32)count.ExecuteScalar() + 1;

                SubjectID = intID.ToString();
            }
            catch (InvalidCastException)
            {
                int id = 0;
                SubjectID = id.ToString();
            }
            closeDB();

            // Assigning Subject visibility
            String visible;
            if (chkbox)
            {
                visible = "T";
            }
            else
            {
                visible = "F";
            }


            // Set INSERT parameters
            createSubject.Parameters.AddWithValue("@SubjectID", SubjectID);
            createSubject.Parameters.AddWithValue("@SubjectName", SubjName);
            createSubject.Parameters.AddWithValue("@SubjectCreator", UserID);
            createSubject.Parameters.AddWithValue("@SubjectVisibility", visible);


            // Execute INSERT command
            openDB();
            if (createSubject.ExecuteNonQuery() == 0)
            {
                closeDB();
                return true;
            }
            else
            {
                closeDB();
                return false;
            }
            ;
        }


        public static String validCredentials(String username, String password)
        {
            if (nameExists(username))
            {
                SqlCommand grabInfo = new SqlCommand("SELECT * FROM Users WHERE Username = @username", connection);
                SqlDataReader reader;

                grabInfo.Parameters.AddWithValue("@username", username);

                openDB();
                reader = grabInfo.ExecuteReader();
                reader.Read();

                if (!reader.HasRows)
                { // No user found
                    closeDB();
                    return "";
                }
                else
                {
                    String userSalt = (String)reader["UserSalt"];
                    String inputBased = Security.Sha256(password + userSalt);

                    if (inputBased.Equals(reader["UserPassword"]))
                    { // Correct login information
                        String userID = reader["userID"].ToString();
                        closeDB();
                        return userID;
                    }
                    else
                    { // Incorrect password
                        closeDB();
                        return "";
                    }
                }
            
            }
            else
            { // Not registered
                closeDB();
                return "";
            }


        }

        /************** END DATABASE OPERATIONS **************/
    }
}
 
 