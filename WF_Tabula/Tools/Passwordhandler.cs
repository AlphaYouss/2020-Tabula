using System;
using System.Security.Cryptography;

namespace WF_Tabula.Tools
{
    class Passwordhandler
    {
        public string[] GenerateSaltAndHash(string password)
        {
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
            var saltBytes = Convert.FromBase64String(salt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == passwordHash; ;
        }
    }
}