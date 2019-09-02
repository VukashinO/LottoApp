using System.Linq;
using System.Security.Cryptography;

namespace BusinessLayer.Helpers
{
    public class HashHelper : IHashHelper
    {
        private string ByteArrayToString(byte[] val)
        {
            string b = "";
            int len = val.Length;
            for (int i = 0; i < len; i++)
            {
                if (i != 0)
                {
                    b += ",";
                }
                b += val[i].ToString();
            }
            return b;
        }

        private byte[] GetBytes(string str)
        {
            string[] strings = str.Split(',');
            byte[] bytes = strings.Select(s => byte.Parse(s)).ToArray();
            return bytes;
        }

        private byte[] GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[256];
            rng.GetBytes(salt);
            return salt;
        }

        public (string Salt, string Password) Hash(string plaintext, string saltString = null)
        {
            var hashFunc = SHA512.Create();

            byte[] salt;
            if (string.IsNullOrEmpty(saltString))
                salt = GenerateSalt();
            else
                salt = GetBytes(saltString);

            byte[] plainBytes = System.Text.Encoding.ASCII.GetBytes(plaintext);
            byte[] toHash = new byte[plainBytes.Length + salt.Length];
            plainBytes.CopyTo(toHash, 0);
            salt.CopyTo(toHash, plainBytes.Length);
            var hashedText = hashFunc.ComputeHash(toHash);

            return (Salt: ByteArrayToString(salt), Password: ByteArrayToString(hashedText));
        }
    }
}
