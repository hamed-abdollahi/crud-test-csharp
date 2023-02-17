using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Mc2.CrudTest.Shared.Base;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Repository.DAO
{
    public class ApplicationContext:MainDbContext
    {
        private IConfiguration configuration;
        public DbSet<CustomerEntity> Customer { get; set; }
        public ApplicationContext(IConfiguration configuration) : base()
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServiceDatabase"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerEntity>(mb =>
            {
                mb.HasKey(x => x.Id);
                mb.HasIndex(x => new { x.FirstName, x.LastName, x.DateOfBirth }).IsUnique();
                mb.HasIndex(x => x.Email).IsUnique();
                mb.Property(x => x.PhoneNumber).HasMaxLength(32).HasColumnType("varchar(32)");
            });

        }
    }
}
