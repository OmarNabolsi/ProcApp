namespace ProcApp.API.Helpers
{
    public interface IEncryptPassword
    {
         void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
         bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}