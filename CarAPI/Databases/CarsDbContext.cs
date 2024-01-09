using CarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Databases
{
	public class CarsDbContext : DbContext
	{
		public DbSet<Car> Cars { get; set; }

        
        public CarsDbContext()
        {
            
        }

		public CarsDbContext(DbContextOptions options) : base(options)
		{
		}
	}
}
