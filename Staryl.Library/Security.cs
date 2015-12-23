using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;



namespace Staryl.Library
{
    　
    /// <summary>
    /// This class will implement common authorization-related functionality in the applications.
    /// </summary>
    public class Security
    {
        /// <summary>
        /// Creates an instance of the specified implementation of the MD5 hash algorithm.
        /// </summary>
        /// <param name="source">The string of the specific implementation of MD5 to use.</param>
        /// <returns>A new string of the specified implementation of MD5.</returns>
        public static string MD5(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            byte[] output = md5.ComputeHash(bytes);

            return BitConverter.ToString(output);
        }


        private static string DESKey_ = "";


        private static string DESKey
        {
            get
            {
                if (DESKey_.Length < 2)
                {
                    DESKey_ = ".!e@0&" + System.Configuration.ConfigurationManager.AppSettings["DESKey"];

                }
                return DESKey_;
            }
        }
        /// <summary>
        /// 加密Creates a symmetric data encryption standard (des) encryptor object.
        /// </summary>
        /// <param name="source">The string of the specific implementation of DES to use.</param>
        /// <returns>A new encrypted string.</returns>
        public static string DESEncrypt(string source)
        {
            string key = Security.DESKey;//".!e@0Na&";
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] bytes = Encoding.UTF8.GetBytes(source);

            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(bytes, 0, bytes.Length);
            cs.FlushFinalBlock();

            StringBuilder sb = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                sb.AppendFormat("{0:X2}", b);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 解密 Creates a symmetric data encryption standard (des) decrypted object.
        /// </summary>
        /// <param name="source">encrypted string</param>
        /// <returns>A new decrypted string</returns>
        public static string DESDecrypt(string source)
        {
            if (source == null || source.Length == 0)
            {
                return source;
            }
            string key = Security.DESKey;//".!e@0Na&";
          
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] bytes = new byte[source.Length / 2];
                for (int x = 0; x < source.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(source.Substring(x * 2, 2), 16));
                    bytes[x] = (byte)i;
                }

                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(bytes, 0, bytes.Length);
                cs.FlushFinalBlock();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
