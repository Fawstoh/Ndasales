using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArcoticWindowsService
{
    public static class Hmac
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        public static string GetHashByMD5(string key, string message)
        {
            var keyByte = encoding.GetBytes(key);
            using (var hmacsha256 = new HMACMD5(keyByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(message));
                return ByteToString(hmacsha256.Hash);
            }
        }

        private static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2"); /* formato hexadecimal */
            return sbinary;
        }
    }
}
