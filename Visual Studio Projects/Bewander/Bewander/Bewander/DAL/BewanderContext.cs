using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bewander.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Bewander.DAL
{
    public class BewanderContext : DbContext
    {
        public BewanderContext() : base("BewanderContext")
        {
        }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<Bewander.Models.Place> Places { get; set; }

        public System.Data.Entity.DbSet<Bewander.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<Bewander.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<Bewander.Models.State> States { get; set; }

        //public System.Data.Entity.DbSet<Bewander.Models.UserProfile> UserProfiles { get; set; }
    }
}