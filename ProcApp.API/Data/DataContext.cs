using Microsoft.EntityFrameworkCore;
using ProcApp.API.Models;

namespace ProcApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) {}
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ValuePhoto> ValuePhotos { get; set; }
    }
}