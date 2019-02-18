using MANAGE_CUSTOMER_CONTACT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MANAGE_CUSTOMER_CONTACT.Infra
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext() : base("CustomerDBContext") { }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserSys> UserSys { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();           
        }
    }
}