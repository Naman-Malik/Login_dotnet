using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Login
{
    public class Hashing
    {
        public static string ToSHA256(string s)
        {
            var sha256 = SHA256.Create();
            string salt = "asdf";
            if (s == null)
            {
                return "";
            }
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

            var sb = new StringBuilder();
            for(int i=0;i<bytes.Length;i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString()+salt;
        }

    }
}
