using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public static class Security
    {
        private static string _keySecurity = "ZAJLX7jS+sD@j-r4KT*WW8mK$JkJfcCn";//32 Bit
        public static string Encrypt(string strEnc)
        {
            string encryptionKey = _keySecurity;
            byte[] clearBytes = Encoding.Unicode.GetBytes(strEnc);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    strEnc = Convert.ToBase64String(ms.ToArray());
                }
            }
            return strEnc;
        }
        public static string Decrypt(string strDec)
        {
            string encryptionKey = _keySecurity;
            strDec = strDec.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(strDec);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    strDec = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return strDec;
        }
    }
}
