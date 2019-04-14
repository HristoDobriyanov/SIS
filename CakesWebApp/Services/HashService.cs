using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace CakesWebApp.Services
{
    public class HashService : IHashService

    {
        public string Hash(string stringToHash)
        {
            stringToHash = stringToHash + "myAppSalt#asdad324234234";
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }

    public interface IHashService
    {
        string Hash(string stringToHash);
    }
}
