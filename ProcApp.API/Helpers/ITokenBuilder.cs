using ProcApp.API.Models;

namespace ProcApp.API.Helpers
{
    public interface ITokenBuilder
    {
         object BuildToken(User user);
    }
}