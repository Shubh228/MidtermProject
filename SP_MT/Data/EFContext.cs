using Microsoft.EntityFrameworkCore;
using SP_MT.Model;

namespace SP_MT.Data
{
    public class EFContext:  DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Coursess { get; set; }
    }
}
