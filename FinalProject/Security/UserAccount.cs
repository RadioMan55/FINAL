using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;

namespace FinalProject.Security
{
    public class UserAccount
    {
        public static string HashSHA1(string value)
        {
            // default encryption instance
            var sha1 = System.Security.Cryptography.SHA1.Create();
            // string to byte array conversion
            var inputBytes = Encoding.ASCII.GetBytes(value);
            // byte array to hash conversion
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static Int32 GetUserID()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            return Convert.ToInt32(ticket.Name);
        }
    }
}