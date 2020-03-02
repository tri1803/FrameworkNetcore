using Microsoft.EntityFrameworkCore;

namespace Temp.DataAccess.Data
{    
    /// <summary>
    /// DbContext
    /// </summary>
    public class DataContext : DbContext
    {                      
        /// <summary>
        /// role
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// user
        /// </summary>
        public DbSet<User> Users { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    }
}