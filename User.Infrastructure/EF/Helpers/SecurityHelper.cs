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
        public static string Decrypt(string cipherTextBase64, string passPhrase)
        {
            using var aes = Aes.Create();
            using var key = new Rfc2898DeriveBytes(passPhrase, Encoding.UTF8.GetBytes("MiSaltFijo123"), 10000);
            aes.Key = key.GetBytes(32);
            aes.IV = key.GetBytes(16);

            var cipherBytes = Convert.FromBase64String(cipherTextBase64);

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
}
