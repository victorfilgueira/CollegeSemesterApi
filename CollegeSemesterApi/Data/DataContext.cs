using CollegeSemesterApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSemesterApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
