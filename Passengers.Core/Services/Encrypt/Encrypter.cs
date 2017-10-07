using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Passengers.Core.Services
{
  public  class Encrypter : IEncrypt
    {

        private static readonly int DriverBytesIterationsCOunts = 10000;

        private static readonly int SaltSize = 40;

       

        public string GetHash(string vlaue, string salt)
        {
            if (vlaue == null)
            {
                throw new ArgumentException("Can not generate salt from empty value", nameof(vlaue));
            }

            if (salt == null)
            {
                throw new ArgumentException("Can not generate salt from empty value", nameof(vlaue));
            }

            var pbkdf2 = new Rfc2898DeriveBytes(vlaue, GetBytes(salt), DriverBytesIterationsCOunts);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        public string GetSalt(string value)
        {
            if(value==null)
            {
                throw new ArgumentException("Can not generate salt from empty value",nameof(value));
            }

            var random = new Random();
            var saltBytes = new byte[SaltSize];
            //create savety values and then 
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            //converting to string format 
            return Convert.ToBase64String(saltBytes);

        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
