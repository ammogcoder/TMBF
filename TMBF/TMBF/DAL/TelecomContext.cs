﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TMBF.Models;

namespace TMBF.DAL
{
    public class TelecomContext : DbContext
    {
        public TelecomContext()
            : base("TelecomContext") 
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<SalesRep> SalesReps { get; set; }
        
        protected void onModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }        
}