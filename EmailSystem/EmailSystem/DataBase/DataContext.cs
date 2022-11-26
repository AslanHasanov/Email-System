using EmailSystem.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSystem.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TargetEmail> TargetEmail { get; set; }
    }
}
