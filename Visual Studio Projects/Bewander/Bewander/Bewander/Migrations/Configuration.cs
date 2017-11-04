namespace Bewander.Migrations
{
    using Bewander.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bewander.DAL.BewanderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //ContextKey = "Bewander.DAL.BewanderContext";
        }

        protected override void Seed(Bewander.DAL.BewanderContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var review = new List<Review>
            //{
            //    new Review { ReviewID = 1, UserID = "123abd", Body = "Test", Title = "Test", CostRating = 2, Flag = 0, GoogleID = "abc", StarRating = 3, SubjectID = 1 }
            //};
            //review.ForEach(r => context.Reviews.AddOrUpdate(r));
            //context.SaveChanges();

            //var user = new List<User>
            //{
            //    new User { UserID = "123abd", About = "About", FirstName = "Jordan", LastName = "Real", Permission = 1 }
            //};

            //user.ForEach(u => context.Users.AddOrUpdate(u));
            //context.SaveChanges();


        }
    }
}
