using System.Security.Cryptography;
using System.Text;

namespace ProcApp.API.Helpers
{
    public class EncryptPassword : IEncryptPassword
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                var encodedPassword = Encoding.UTF8.GetBytes(password);

                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(encodedPassword);
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = Encoding.UTF8.GetBytes(password);

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}