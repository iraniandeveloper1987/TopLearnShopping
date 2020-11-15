using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TopLearn.Core.Security
{
     public static class PasswordHelper
    {
        public static string EncodePasswordMd5(string password)
        {
            Byte[] mainBytes;
            Byte[] encodeBytes;

            MD5 md5;

            md5 = new MD5CryptoServiceProvider();

            mainBytes = ASCIIEncoding.Default.GetBytes(password);
            encodeBytes = md5.ComputeHash(mainBytes);

            return BitConverter.ToString(encodeBytes);
        }
    }
}
