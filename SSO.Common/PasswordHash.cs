using System;
using System.Security.Cryptography;
using System.Text;

namespace SSO.Common
{
    public class PasswordHash
    {
        // The following constants may be changed without breaking existing hashes.
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        //public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 0;
        public const int PBKDF2_INDEX = 1;




        public static string GetSha256Hash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var byteValue = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(byteValue);
                return Convert.ToBase64String(hash);
            }
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            try
            {

                var hashPassword = GetSha256Hash(password);
                bool isPasswordMatched = VerifyPassword(hashPassword, correctHash);
                if (!isPasswordMatched)
                {
                    return false;
                }
                return true;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static bool VerifyPassword(string hashPassword, string correctHash)
        {
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(hashPassword, 10000);
            if (hashPassword == correctHash)
            {
                return true;
            }
            return false;
        }
       
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


    }
}
