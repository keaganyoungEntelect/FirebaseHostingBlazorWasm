using System;
using System.Security.Cryptography;
using System.Text;

namespace BlazorWasmSample.Services
{

    public class PasswordHasher
    {

        public async Task<string> HashPassword(string password, string salt)
        {

            int iterations = 10000;

            using (var deriveBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), iterations))
            {
                byte[] key = deriveBytes.GetBytes(32); 
                return Convert.ToBase64String(key);
            }
        }

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }

}
