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
    }
}
