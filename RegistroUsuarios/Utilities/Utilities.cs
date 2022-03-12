using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}