using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RZAAppliciation
{
    public class DataHasher
    {
        public static string Datahash(string data)
        {
            // This is  the algorithm which Encrypts the data.
            using (SHA256 sha = SHA256.Create())
            {
                //Turns the string provied into a byte and stores it in an array.
                byte[] hashedBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(data));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    // Converts each byte into a 2 character long hexadecmial and adds it to the string.
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
