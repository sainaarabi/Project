using System.Security.Cryptography;
using System.Text;

namespace SSO.Api.ExtensionMethods
{
    public class DecryptRSAwithPublicPrivateKey
    {
        /// <summary>
        /// ساختن کلید عمومی و خصوصی برای رمز نگاری
        /// </summary>
        /// <param name="strPublicKey"></param>
        /// <param name="strPublicPrivateKey"></param>
        public static void getRSAkeys(out string strPublicKey, out string strPublicPrivateKey)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                strPublicKey = rsa.ToXmlString(false);//public
                strPublicPrivateKey = rsa.ToXmlString(true);//public and private
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// رمزنگاری کردن عبارت وارده با کلید عمومی
        /// </summary>
        /// <param name="strPublicKey"></param>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string EncryptRSAwithPublicKey(string strPublicKey, string strText)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(strPublicKey);
                byte[] bs = rsa.Encrypt(Encoding.UTF8.GetBytes(strText), false);
                //ghalat kardi: return Encoding.UTF8.GetString(bs)
                return Convert.ToBase64String(bs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// از رمز در آموردن عبارت رمز شده با استفاده از کلید خصوصی
        /// </summary>
        /// <param name="strPublicPrivateKey"></param>
        /// <param name="strEncrypted"></param>
        /// <returns></returns>
        public static string DecryptRSAwithPublicPrivateKeys(string strPublicPrivateKey, string strEncrypted)
        {
            try
            {
                strEncrypted = strEncrypted.Replace(" ", "+");

                int mod4 = strEncrypted.Length % 4;
                if (mod4 > 0)
                {
                    strEncrypted += new string('=', 4 - mod4);
                }

                byte[] bs = Convert.FromBase64String(strEncrypted);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(strPublicPrivateKey);
                byte[] bs2 = rsa.Decrypt(bs, false);
                return Encoding.UTF8.GetString(bs2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


    }
}
