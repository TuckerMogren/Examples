using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Contexts
{
	public class EmployeeContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

		protected override void OnModelCreating(ModelBuilder model)
		{
            base.OnModelCreating(model);
            model.Entity<Employee>(e =>
            {
                e.ToTable("Employee");
                e.HasKey(e => e.ID);
                e.Property(e => e.ID).ValueGeneratedOnAdd();
            });
        }

	}
}

