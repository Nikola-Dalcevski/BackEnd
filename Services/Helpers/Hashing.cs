using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.Helpers
{
    public static class Hashing
    {
        public static string sha256(string password)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                foreach (byte theByte in bytes)
                {
                    sb.Append(theByte.ToString("x2"));
                }

                return sb.ToString();


            }
        }
    }
}
