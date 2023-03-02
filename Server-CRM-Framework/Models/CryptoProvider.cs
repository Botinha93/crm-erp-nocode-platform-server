using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;

namespace Server_CRM_Framework.Models
{
    public class CryptoProvider
    {
        static X509Certificate2 certificate;
        public static void InitCryptoProvider(string certificateName)
        {
            certificate = new X509Certificate2(certificateName, "1234");
        }
        static public string EncryptRsa(string input)
        {
            string output = string.Empty;
            using (RSACryptoServiceProvider csp = (RSACryptoServiceProvider) certificate.PublicKey.Key)
            {
                byte[] bytesData = Encoding.UTF8.GetBytes(input);
                byte[] bytesEncrypted = csp.Encrypt(bytesData, false);
                output = Convert.ToBase64String(bytesEncrypted);
            }
            return output;
        }
        static public string decryptRsa(string encrypted)
        {
            string text = string.Empty;
            using (RSACryptoServiceProvider csp = (RSACryptoServiceProvider)certificate.PrivateKey)
            {
                byte[] bytesEncrypted = Convert.FromBase64String(encrypted);
                byte[] bytesDecrypted = csp.Decrypt(bytesEncrypted, false);
                text = Encoding.UTF8.GetString(bytesDecrypted);
            }
            return text;
        }
    }
}
