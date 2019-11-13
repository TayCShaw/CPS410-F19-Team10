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
        
        /* Opens the database connection for any database operations
         * @PARAM: N/A
         * @TABLE: N/A
         * @RETURNS: N/A
         */
        public static void openDB()
        {
           connection.Open();
        }

        /* Closes the database connection after database operations are complete
         * @PARAM: N/A
         * @TABLE: N/A
         * @RETURNS: N/A
         */
        public static void closeDB()
        {
            connection.Close();
        }

        /* Checks to see if a username already exists in the Users table
         * @PARAM: "username": Username to search Users table for 
         * @TABLE: Users
         * @RETURNS: True if name is found in Users table, False otherwise
         */
        public static Boolean nameExists(String username)
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
                role = reader["UserRole"].ToString();
            }
            closeDB();
            return role;
        }


        /* Adds a new user to the User table of the database
         * @PARAM: "email": Email address of the User
         *      "username": Username of the User
         *      "password": Password of the User
         *          "role": Role of the user  --TO BE ADDED
         * @TABLE: Users
         * @RETURNS: String value that represents the message shown to the user.
         *           Either a message saying account creation was successful,
         *           or displaying an "ERROR:" message.
         */
        public static String addNewUser(String email, String username, String password, String role)
        {
            if (nameExists(username))
            {
                // Username is already found, return an error message.
                return "Username is taken. Please pick a new username.";
            }
            else
            {
                // Username does not already exist
                SqlCommand insertUser = new SqlCommand("INSERT INTO Users (UserID, Username, UserPassword, UserSalt, UserEmail, TimeCreated, UserRole) values (@userid, @username, @userpassword, @usersalt, @email, @time, @role)", connection);
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
                insertUser.Parameters.AddWithValue("@role", role);
              
                /*
                 * Attempts to add the new user account to the database. If the addition is
                 * successful, the method returns "TRUE". If the addition is unsuccessful
                 * (in this case, for an error based on inserting to database), method returns
                 * "FALSE".
                 */
                if (insertUser.ExecuteNonQuery() != 0)
                {
                    closeDB();
                    return "TRUE,"+ newuserID;
                }
                else
                {
                    closeDB();
                    return "FALSE";
                }
            }
        }

        /* Adds a new subject to the Subjects table of the database
         * @PARAM: "UserID": UserID of the user creating the Subject, typically should be the UserID stored in session state
         *       "SubjName": Name to be set for the Subject. Will be outward facing and be the name users know the Subject by
         *         "chkbox": Determines if the Subject will be publicly available to all Users or private until otherwise set
         * @TABLE: Subjects
         * @RETURNS: Boolean value. TRUE if the Subject was added successfully, FALSE otherwise
         */
        public static Boolean addNewSubject(String UserID, String SubjName, Boolean chkbox)
        {

            // Once created, take to a page OR Show something that will let the user create a new Subject
            SqlCommand createSubject = new SqlCommand("INSERT INTO Subjects (SubjectID, SubjectName, SubjectCreator, SubjectVisibility) values(@SubjectID, @SubjectName, @SubjectCreator, @SubjectVisibility)", Database.connection);
            SqlCommand count = new SqlCommand("Select max(SubjectID) from Subjects", connection);

            int intID;

            // Assigning Subject visibility
            String visible = "F";
            if (chkbox)
            {
                visible = "T";
            }

            try
            {
                openDB();

                intID = (int)count.ExecuteScalar() + 1;
            }
            catch (InvalidCastException)
            {
                intID = 0;
            }
            closeDB();

            // Set INSERT parameters
            createSubject.Parameters.AddWithValue("@SubjectID", intID);
            createSubject.Parameters.AddWithValue("@SubjectName", SubjName);
            createSubject.Parameters.AddWithValue("@SubjectCreator", UserID);
            createSubject.Parameters.AddWithValue("@SubjectVisibility", visible);


            // Execute INSERT command
            openDB();
            if (createSubject.ExecuteNonQuery() == 0)
            {
                closeDB();
                return false;
            }
            else
            {
                closeDB();
                return true;
            }
        }

        /* Adds a new topic to the Topics table of the database
         * @PARAM: "UserID": UserID of the User creating the Topic, typically should be the UserID stored in session state 
         *      "SubjectID": SubjectID of the Subject the Topic is being created under (e.g., the topic Geometry could have 
         *                          SubjectID of 2 while being created under the subject Math that has ID of 2)
         *      "TopicName": Name to be set for the Topic. Will be outward facing and be the name users know the Topic by
         *         "chkbox": Determines if the Topic will be publicly available to all Users or private until otherwise set
         * @TABLE: Topics
         * @RETURNS: Boolean value. TRUE if the Topic was added successfully, FALSE otherwise
         */
        public static Boolean addNewTopic(String UserID, String SubjectID, String TopicName, Boolean chkbox)
        {
            SqlCommand createTopic = new SqlCommand("INSERT into Topics (TopicID, TopicName, TopicSubject, TopicCreator) " +
                "values(@ID, @name, @subj, @creator, @visible)", connection);
            SqlCommand count = new SqlCommand("Select max(TopicID) from Topics", connection);
            int intID;

            String visible = "F";
            if (chkbox)
            {
                visible = "T";
            }

            try
            {
                openDB();
                intID = (int)count.ExecuteScalar() + 1;
            }
            catch (InvalidCastException)
            {
                intID = 0;
            }
            closeDB();

            createTopic.Parameters.AddWithValue("@ID", intID);
            createTopic.Parameters.AddWithValue("@name", TopicName);
            createTopic.Parameters.AddWithValue("@subj", SubjectID);
            createTopic.Parameters.AddWithValue("@creator", UserID);
            createTopic.Parameters.AddWithValue("@visible", visible);

            openDB();
            if (createTopic.ExecuteNonQuery() != 0)
            {
                closeDB();
                return true;
            }
            closeDB();
            return false;
        }

        /*
         */
        public static Boolean addNewThread(String UserID, String TopicID)
        {
            // TO-DO

            return false;
        }

        /* Primarily used for logging in to the website. Determines if the login credentials match an account AND are valid
         * @PARAM: "username": Username to be searched for in the Users database table
         *         "password": Password to try and match up to the stored password for the User
         * @TABLE: Users
         * @RETURNS: String value representing either:
         *              1) the UserID of the User upon successful login, meant to be stored in SessionState
         *              2) an empty String
         */
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

        /********** END DATABASE OPERATIONS **********/



        /********** USER INFORMATION **********/

        /* GETs the role of specific user based on UserID
         * @PARAM: "userID": UserID used to search the Users table to find specific User
         * @TABLE: Users
         * @RETURNS: String value representing the UserRole field
         */
        public static String getRole(String userID)
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
                role = reader["UserRole"].ToString();
            }
            closeDB();
            return role;
        }


      /* GETs the salt of a specific user based on UserID
         * @PARAM: "userID": UserID used to search the Users table to find specific User
         * @TABLE: Users
         * @RETURNS: String value representing the UserSalt field
         */
        public static String getSalt(String userID)
        {
            String salt = "";
            SqlCommand grabSalt = new SqlCommand("SELECT UserSalt FROM Users WHERE UserID = @userID",connection);
            grabSalt.Parameters.AddWithValue("@userID", userID);

            openDB();
            SqlDataReader reader = grabSalt.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                salt = reader["UserSalt"].ToString();
                closeDB();
            }
            return salt;
        }

        /* GETs the password of a specified user based on UserID
         * @PARAM: "userID": UserID used to search the Users table to find specific User
         * @TABLE: Users
         * @RETURNS: String value representing the UserSalt field
         */
        public static String getPassword(String userID)
        {
            String password = "";
            SqlCommand grabPassword = new SqlCommand("SELECT UserPassword FROM Users WHERE UserID = @userID", connection);
            grabPassword.Parameters.AddWithValue("@userID", userID);

            openDB();
            SqlDataReader reader = grabPassword.ExecuteReader();

            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    password = reader["UserPassword"].ToString();
                }
                closeDB();

            }
            return password;
        }
        
        /********** END USER INFORMATION **********/


        /********** ACCOUNT FUNCTIONS **********/

        /* Changes the Username of an account based on availability of username
         * @PARAM: "desiredName": Specified name to have a User's Username be switched to
         *              "userID": UserID of the User receiving a username change
         * @TABLE: Users
         * @RETURNS: String value representing a message to the user stating either:
         *              1) Successful change of the username
         *              2) Unsuccessful change of the username, displaying the error
         */
        public static String changeUsername(String desiredName, String userID)
        {
            SqlCommand updateName = new SqlCommand("UPDATE Users SET Username = @desiredname WHERE UserID = @id", connection);

            // See if the name already exists in the User database. If the name already exists, it cannot be duplicated
            if (nameExists(desiredName))
            {
                return "ERROR: Username already taken!";
            }
            else
            {
                // Create the UPDATE command
                updateName.Parameters.AddWithValue("@desiredname", desiredName);
                updateName.Parameters.AddWithValue("@id",userID);

                // Execute the UPDATE
                if (updateName.ExecuteNonQuery() != 0)
                {
                    return "Username successfully changed!";
                }

                // Should only be hit if the UPDATE does not work
                return "ERROR: Could not change username at this time.";
            }
        } 

      
        /* Changes the UserPassword of an account
         * @PARAM: "desiredPassword": String value representing the newly desired password for a User account
         *                  "userID": UserID of the User account on the receiving end of the password change
         * @TABLE: Users
         * @RETURNS: String value representing a message to the user stating either:
         *              1) Successful password change
         *              2) Unsuccessful password change
         */
        public static String changePassword(String currentPassword, String desiredPassword, String userID)
        {
            /* 1) Take their desired password
             * 2) Take their saved salt, add that to their desired password
             * 3) Rehash their password with the concatenated pass+salt
             * 4) UPDATE the user's password field with the rehash
             */

            // Make new hashed password
            String salt = getSalt(userID);
            String possibleCurrentPassword = Security.Sha256(currentPassword + salt);

            // If the password they entered for their currentPassword is actually their password then continue
            if (possibleCurrentPassword.Equals(getPassword(userID)))
            {

                String newConcatPass = desiredPassword + salt;
                String hashedPass = Security.Sha256(newConcatPass);

                // Create the update command
                SqlCommand changePass = new SqlCommand("UPDATE Users SET UserPassword = @newpass " +
                    "WHERE UserID = @userid", connection);
                changePass.Parameters.AddWithValue("@newpass", hashedPass);
                changePass.Parameters.AddWithValue("@userid", userID);

                // Execute, see if the row was updated
                openDB();
                if (changePass.ExecuteNonQuery() == 1)
                {
                    closeDB();
                    return "Password successfully changed!";
                }

                // Only reached if the password was not updated
                closeDB();
                return "ERROR: Password change failed";
            }
            else
            {
                return "ERROR: Incorrect password";
            }          
        }

        /********** END ACCOUNT FUNCTIONS **********/


    }
}
 
 