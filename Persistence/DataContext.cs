
using Microsoft.EntityFrameworkCore;
using Reactivities.Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {              
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Activite> Activities { get; set;  }
    }

    
}