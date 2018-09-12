using System.Collections.Generic;
using System.Threading.Tasks;
using ProcApp.API.Models;

namespace ProcApp.API.Data
{
    public interface IUsersRepository
    {
         void Add<T>(T entity) where T:class;
         void Delete<T>(T entity) where T:class;
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
         Task<bool> SaveAll();
    }
}