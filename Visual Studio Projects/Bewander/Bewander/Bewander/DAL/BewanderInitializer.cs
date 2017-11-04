using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bewander.Models;

namespace Bewander.DAL
{
    public class BewanderInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BewanderContext>
    {
        protected override void Seed(BewanderContext context)
        {
            //var review = new List<Review>
            //{
            //    new Review { ReviewID = 1, UserID = "123abd", Body = "Test", Title = "Test", CostRating = 2, Flag = 0, GoogleID = "abc", StarRating = 3, SubjectID = 1 }
            //};
            //review.ForEach(r => context.Reviews.Add(r));
            //context.SaveChanges();

            //var user = new List<User>
            //{
            //    new User { UserID = "123abd", About = "About", FirstName = "Jordan", LastName = "Real", Permission = 1 }
            //};

            //user.ForEach(u => context.Users.Add(u));
            //context.SaveChanges();
        }
    }
}