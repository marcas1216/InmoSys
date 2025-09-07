using System.Security.Cryptography;
using System.Text;
using User.Infrastructure.Constants;

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
        public static string Decrypt(string ConnectionString, string ServiceName)
        {
            using var aes = Aes.Create();         
            using var key = new Rfc2898DeriveBytes(
                ServiceName,
                Encoding.UTF8.GetBytes(ServiceName),
                JwtAuthConstants.NUMBER_OF_ITERATION,
                HashAlgorithmName.SHA256
            );
            aes.Key = key.GetBytes(32);
            aes.IV = key.GetBytes(16);

            var cipherBytes = Convert.FromBase64String(ConnectionString);

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
}
