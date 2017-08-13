using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LoginForm_Demo.Functions
{
    static class SHA512_Hashing
    {
        public static string Convert_Hash(string input)
        {
            var sha512 = System.Security.Cryptography.SHA512.Create();

            byte[] inputBytes = System.Text.Encoding.BigEndianUnicode.GetBytes(input);
            byte[] hashing = sha512.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for(int i =0; i<hashing.Length; i++)
            {
                sb.Append(hashing[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
