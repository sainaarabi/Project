using System;
using System.Text.RegularExpressions;

namespace SSO.Common.ExtensionMethods
{
    public static class TypeExtensions
    {
        public static T CastTo<T>(this object obj)
        {
            return (T)obj;
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsDigit(string val)
        {
            try
            {
                return Regex.IsMatch(val, @"\d");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
