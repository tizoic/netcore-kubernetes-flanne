using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace backend.Api.Configurations
{
    public class HashConfiguration
    {
        public string Encrypt(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                return null; 
            }

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[ 256 / 8 ];
            var iterations = 1000;
            
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(salt);
            }

            var valuesByte = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: iterations,
                numBytesRequested: 256 / 8);

            return $"{ Convert.ToBase64String(valuesByte) }:{ Convert.ToBase64String(salt) }";
        }
        public bool ValidatePassword(string password, string passwordHash)
        {
            var split = passwordHash.Split(':');
            
            if(split.Count() == 1)
                return false;

            var hash = Convert.FromBase64String(split[0]);
            var salt = Convert.FromBase64String(split[1]);

            var newHash = GetPbkdf2Bytes(password, salt, hash.Length);

            return SlowEquals(hash, newHash);
        }
        private bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }
        private byte[] GetPbkdf2Bytes(string password, byte[] salt, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = 1000;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}