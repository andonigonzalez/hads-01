using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;

namespace RegistroUsuarios.Utilities
{
    public static class Utilities
    {
        public static bool CheckPasswordsIguales(string pass1, string pass2)
        {
            return pass1.Equals(pass2);
        }

        public static bool CheckLongitudMinimaPassword(string pass)
        {
            return pass.Length >= 6; 
        }

        public static bool IsValidEmail(string email)
        {
            string trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        public static bool CheckSession(HttpSessionState session)
        {
            if (session["usuario"] == null)
                return false;

            if (session["email"] == null)
                return false;

            return true;
        }

        public static string HashPassword(string pass)
        {
            RNGCryptoServiceProvider saltCellar = new RNGCryptoServiceProvider();
            byte[] salt = new byte[24];
            saltCellar.GetBytes(salt);

            Rfc2898DeriveBytes hashTool = new Rfc2898DeriveBytes(pass, salt);
            hashTool.IterationCount = 1000;
            byte[] hash = hashTool.GetBytes(24);

            string databaseStorePassword = "1000:" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);

            return databaseStorePassword;
        }

        public static bool CheckPasswords(string inputPass, string storedPass)
        {
            string[] hashParts = storedPass.Split(':');
            int iterations = int.Parse(hashParts[0]);
            byte[] originalSalt = Convert.FromBase64String(hashParts[1]);
            byte[] originalHash = Convert.FromBase64String(hashParts[2]);

            Rfc2898DeriveBytes hashTool = new Rfc2898DeriveBytes(inputPass, originalSalt);
            hashTool.IterationCount = iterations;
            byte[] testHash = hashTool.GetBytes(originalHash.Length);

            return CompareBytes(testHash, originalHash);
        }

        private static bool CompareBytes(byte[] test, byte[] original)
        {
            uint differences = (uint)original.Length ^ (uint)test.Length;

            for (int position = 0; position < Math.Min(original.Length,
              test.Length); position++)
                differences |= (uint)(original[position] ^ test[position]);

            return (differences == 0);
        }
    }
}