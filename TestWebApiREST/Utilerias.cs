using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApiREST
{
    public static class Utilerias
    {
        private static string KeyEcrypt = ConfigurationManager.AppSettings["KeyEcrypt"];
        public static string AESEncrypt(string base64Encode)
        {
            string decode = null;
            try
            {
                using (var aes = new AesCryptoServiceProvider())
                {
                    aes.Key = Encoding.UTF8.GetBytes(KeyEcrypt);
                    aes.Mode = CipherMode.ECB;
                    aes.Padding = PaddingMode.PKCS7;
                    //aes.FeedbackSize = aes.BlockSize;                                
                    byte[] encrypted = AESCrypto(CryptoOperation.ENCRYPT, aes, Encoding.UTF8.GetBytes(base64Encode));
                    return Convert.ToBase64String(encrypted);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return decode;
        }
        public static string AESEncrypt(byte[] doc)
        {
            string decode = null;
            try
            {
                using (var aes = new AesCryptoServiceProvider())
                {
                    aes.Key = Encoding.UTF8.GetBytes(KeyEcrypt);
                    aes.Mode = CipherMode.ECB;
                    aes.Padding = PaddingMode.PKCS7;
                    //aes.FeedbackSize = aes.BlockSize;                                
                    byte[] encrypted = AESCrypto(CryptoOperation.ENCRYPT, aes, doc);
                    return Convert.ToBase64String(encrypted);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return decode;
        }
        public static string AESDecrypt(string base64Encode)
        {
            string decode = null;
            try
            {
                using (var aes = new AesCryptoServiceProvider())
                {
                    aes.Key = Encoding.UTF8.GetBytes(KeyEcrypt);
                    aes.Mode = CipherMode.ECB;
                    aes.Padding = PaddingMode.PKCS7;
                    //aes.FeedbackSize = aes.BlockSize;                                                    
                    byte[] decrypted = AESCrypto(CryptoOperation.DECRYPT, aes, Convert.FromBase64String(base64Encode));
                    return Encoding.UTF8.GetString(decrypted);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return decode;
        }

        public static byte[] AESCrypto(CryptoOperation cryptoOperation, AesCryptoServiceProvider aes, byte[] message)
        {
            using (var memStream = new MemoryStream())
            {
                CryptoStream cryptoStream = null;

                if (cryptoOperation == CryptoOperation.ENCRYPT)
                    cryptoStream = new CryptoStream(memStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                else if (cryptoOperation == CryptoOperation.DECRYPT)
                    cryptoStream = new CryptoStream(memStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

                if (cryptoStream == null)
                    return null;

                cryptoStream.Write(message, 0, message.Length);
                cryptoStream.FlushFinalBlock();
                return memStream.ToArray();
            }
        }

        public enum CryptoOperation
        {
            ENCRYPT,
            DECRYPT
        };
    }
}
