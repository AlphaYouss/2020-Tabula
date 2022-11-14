using System;
using System.Security.Cryptography;

namespace ASP_Tabula.Tools
{
    class Passwordhandler
    {
        public string[] GenerateSaltAndHash(string password)
        {
            // Generates salt and hash based on password

            string[] data = new string[2];
            byte[] saltBytes = new byte[64];

            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);

            data[1] = Convert.ToBase64String(saltBytes);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            data[0] = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return data;
        }

        public bool VerifyPassword(string salt, string password, string passwordHash)
        {
            // Compares the hash with the filled password and salt

            byte[] saltBytes = Convert.FromBase64String(salt);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == passwordHash;
        }
    }
}