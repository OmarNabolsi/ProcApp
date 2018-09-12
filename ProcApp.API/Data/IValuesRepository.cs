using System.Collections.Generic;
using System.Threading.Tasks;
using ProcApp.API.Models;

namespace ProcApp.API.Data
{
    public interface IValuesRepository
    {
        void Add<T>(T entity) where T:class;
        void Delete<T>(T entity) where T:class;
        Task<bool> SaveAll();
        Task<IEnumerable<Value>> GetValues();
        Task<Value> GetValue(int id);
    }
}