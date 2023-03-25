﻿using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Contexts
{
	public class EmployeeContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext()
        {

        }

		protected override void OnModelCreating(ModelBuilder model)
		{
            base.OnModelCreating(model);
            model.Entity<Employee>(e =>
            {
                e.ToTable("Emoloyees");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).IsRequired();
            });
        }

	}
}

