using System.Security.Cryptography;
using System.Text;

namespace User.Infrastructure.EF.Helpers
{
    public static class SecurityHelper
    {
        public static string Hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.Unicode.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToUpper();
            }
        }
        public static string Decrypt(byte[] cipherBytes, string passPhrase)
        {
            using var aes = Aes.Create();
            using var sha256 = SHA256.Create();
                       
            aes.Key = sha256.ComputeHash(Encoding.UTF8.GetBytes(passPhrase));
            aes.IV = new byte[16]; 

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            var decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }

}
