using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace CPS410Final
{
    public class Security
    {

        public static String genSalt()
        {

            string salt = "";
            // 48-122
            Random r = new Random();
            for (int i = 0; i < 32; i++)
            {
                salt = char.ToString((char)r.Next(48, 122));
            }
            return salt;
        }

        

        //https://stackoverflow.com/questions/50399685/c-sharp-login-system-need-help-hashing-password-before-inserting-them-to-the-da
        public static string Sha256(String value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                // Making the SHA-256 Version
                using (var sha = SHA256.Create())
                {
                    var bytes = Encoding.UTF8.GetBytes(value);
                    var hash = sha.ComputeHash(bytes);

                    return Convert.ToBase64String(hash);
                }
            }
            else
            {
                return String.Empty;
            }
        }

    }
}