using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcApp.API.Models;

namespace ProcApp.API.Data
{
    public class ValuesRepository : IValuesRepository
    {
        private readonly DataContext _context;
        public ValuesRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Value> GetValue(int id)
        {
            var value = await _context.Values.Include(vp => vp.Photos).FirstOrDefaultAsync(v => v.Id == id);
            
            return value;
        }

        public async Task<IEnumerable<Value>> GetValues()
        {
            var values = await _context.Values.Include(vp => vp.Photos).ToListAsync();

            return values;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}