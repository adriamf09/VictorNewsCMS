using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsApi.Models
{
    public  class EncryptService : IPasswordHasher
    {
        //public static String Encryptor(string password)
        //{
        //    byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
        //    data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
        //    String hash = System.Text.Encoding.ASCII.GetString(data);

        //    return hash;
        //}

        public string HashPassword(string password)
        {
            throw new NotImplementedException();
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            throw new NotImplementedException();
        }
    }
}