using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcApp.API.Helpers;
using ProcApp.API.Models;

namespace ProcApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IEncryptPassword _encrypt;
        public AuthRepository(DataContext context,
        IEncryptPassword encrypt)
        {
            _context = context;
            _encrypt = encrypt;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
                return null;
            
            var validPasswordHash = _encrypt.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (!validPasswordHash)
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            _encrypt.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;
                
            return false;
        }
    }
}