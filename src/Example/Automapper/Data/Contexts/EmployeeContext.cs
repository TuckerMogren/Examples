using System;
using Data.Models;
using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace Data.Contexts
{
	public class EmployeeContext : DbContext
	{
		public EmployeeContext() : base("EmployeeContext")
		{

		}

		public DbSet<Employee> Employees { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

	}
}

