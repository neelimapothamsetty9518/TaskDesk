using Microsoft.EntityFrameworkCore;
using TravelDeskWebapi.Model;

namespace TravelDeskWebapi.NewFolder
{
    public class ManagerDbContext:DbContext
    {
        public ManagerDbContext(DbContextOptions<ManagerDbContext> options):base(options)
        {

        }
        public DbSet<Manager> managers { get; set; }
        
    }
}
