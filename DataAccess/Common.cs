using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Common
    {
        public static string EncryptMD5(string password)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] buffer = encoding.GetBytes(password);

            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(buffer);

            string hashString = "";

            for (int i = 0; i < result.Length; i++)
            {
                hashString += Convert.ToString(result[i], 16).PadLeft(2, '0');
            }
            return hashString.PadLeft(32, '0');
        }
    }
}
