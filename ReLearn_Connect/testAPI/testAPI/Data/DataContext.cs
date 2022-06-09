using Microsoft.EntityFrameworkCore;
using testAPI.Models;

namespace testAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TestModel> testModels { get; set; } 
    }
}
