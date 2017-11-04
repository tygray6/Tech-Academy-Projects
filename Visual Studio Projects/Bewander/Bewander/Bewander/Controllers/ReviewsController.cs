using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bewander.DAL;
using Bewander.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Text;

namespace Bewander.Controllers
{
    public class ReviewsController : Controller
    {
        private BewanderContext db = new BewanderContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        // -- CREATE --
        public ActionResult Create()
        {
            // If user not logged in, display login prompt and disable Submit.  Otherwise, ensure Submit is no longer disabled
            try
            {
                var userID = GetUserID();
                ViewBag.showLoginPrompt1 = "<script>\n$(window).load(function(){";
                ViewBag.showLoginPrompt2 = "$(\"input[type=submit]\").removeAttr('disabled')";
                ViewBag.showLoginPrompt3 = "$</script >";

            }
            catch
            {
                ViewBag.showLoginPrompt1 = "<script>\n$(window).load(function(){";
                ViewBag.showLoginPrompt2 = "$(\"#myModal\").modal(\"show\");\n});";
                ViewBag.showLoginPrompt3 = "$(\"input[type = submit]\").attr('disabled','disabled');\n</script >";

            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewViewModel reviewViewModel)
        {
            if (reviewViewModel != null)
            {
                // GET: UserID
                var userID = GetUserID();
                var placeCount = PlaceCount(reviewViewModel.Review.GoogleID);
                if (placeCount != 1)
                {
                    var countryID = GetCountryID(reviewViewModel.Country.Name);
                    //int stateID = GetStateID(reviewViewModel.State.Name, countryID);
                    //var cityID = GetCityID(reviewViewModel.City.Name, stateID, countryID);

                    if (reviewViewModel.State.Name != null)
                    {
                        int stateID = GetStateID(reviewViewModel.State.Name, countryID);
                        reviewViewModel.Place.StateID = stateID;

                        if (reviewViewModel.City.Name != null)
                        {
                            var cityID = GetCityID(reviewViewModel.City.Name, stateID, countryID);
                            reviewViewModel.Place.CityID = cityID;
                        }
                    }
                    else if (reviewViewModel.State.Name == null && reviewViewModel.City.Name != null)
                    {
                        var cityID = GetCityID(reviewViewModel.City.Name, 0, countryID);
                        reviewViewModel.Place.CityID = cityID;
                    }

                    reviewViewModel.Place.PlaceID = reviewViewModel.Review.GoogleID;
                    reviewViewModel.Place.CountryID = countryID;


                    db.Places.Add(reviewViewModel.Place);
                    db.SaveChanges();

                    if (reviewViewModel.Review.StarRating == null)
                    {
                        reviewViewModel.Review.StarRating = 0;
                    }
                }
                SaveReview(reviewViewModel, userID);

                // Redirect to the Display page to see the review posted
                string googleID = reviewViewModel.Review.GoogleID;
                bool createdNewReview = true;
                return RedirectToAction("Display", "Reviews", new { googleID, createdNewReview });
            }
            else return View();
        }

        // -- DELETE --
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // -- DETAILS --
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // -- DISPLAY --
        [HttpPost]
        public ActionResult Display(FormCollection formData)
        {
            // SET: Empty variables for form input values
            string googleID = "";

            // GET: Values from form input
            foreach (var key in formData.AllKeys)
            {
                var value = formData[key];

                if (key.Contains("PlaceID"))
                {
                    googleID = value;
                }
            }

            // NULL googleID: 404 error
            if (googleID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // GET: All reviews with matching GoogleID
            List<Review> allReviews = AllReviews(googleID);

            //  NULL Review count: Redirect to empty page (Would you like to make a review page)
            if (allReviews.Count == 0)
            {
                return RedirectToAction("Create");
            }

            // FORMAT: Set values for viewmodel
            List<DisplayReviews> reviews = FormatReviews(allReviews);

            // POST: Send values from allReviews to page for display
            return View(reviews);
        }

        public ActionResult Display(string googleID, bool createdNewReview)
        {
            // GET: All reviews with matching GoogleID
            List<Review> allReviews = AllReviews(googleID); // No null checking: nulls not expected

            // If new review was created, generate code to display the Success dialog on the page
            if (createdNewReview == true)
            {
                ViewBag.showSuccess1 = "<script type = \"text/javascript\" >\n$(window).load(function(){";
                ViewBag.showSuccess2 = "$(\"#myModal\").modal(\"show\");\n});\n</script >";
            }

            // FORMAT: Set values for viewmodel
            List<DisplayReviews> reviews = FormatReviews(allReviews);

            // POST: Send query result (allReviews) to page for display
            return View(reviews);
        }


        // -- EDIT --
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,UserID,GoogleID,Title,Body,DatePosted,StarRating,CostRating,Flag,SubjectID")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string GetUserID()
        {
            // GET: Current Users ID
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            // SET: UserID
            string userID = user.Id;

            return (userID);
        }

        // -- INDEX --
        public ActionResult Index()
        {
            return View();
            //return View(db.Reviews.ToList());
        }


        //       View return methods above  
        //  ===================================================================================================
        //         Other methods below      


        public string GetReviewSummaries(string placeID)
        {
            StringBuilder summaryStringBuilder = new StringBuilder();

            List<Review> reviewList = db.Reviews
                                     .Where(pl => pl.GoogleID == placeID)
                                     .OrderByDescending(pl => pl.DatePosted)
                                     .Take(7)
                                     .ToList();

            if (reviewList.Count == 0)
            {
                summaryStringBuilder.Append("<p>There are no reviews for this location.</p>");
            }
            else {
                summaryStringBuilder.Append("<table>");
                foreach (Review review in reviewList)
                {
                    summaryStringBuilder.Append("<tr><td class='summaryItem'><a href='/Reviews/Details/" + review.ReviewID + "'>");
                    summaryStringBuilder.Append(review.Title);
                    summaryStringBuilder.Append("<br><span class='summaryItemTagline'>");
                    switch (review.SubjectID)
                    {
                        case 0:
                            summaryStringBuilder.Append("Good Eats"); break;
                        case 1:
                            summaryStringBuilder.Append("Safe Stays"); break;
                        case 2:
                            summaryStringBuilder.Append("Cool Sites"); break;
                        case 3:
                            summaryStringBuilder.Append("Fun Times"); break;
                        case 4:
                            summaryStringBuilder.Append("Legit Business"); break;
                        default:
                            summaryStringBuilder.Append("Other"); break;
                    }

                    summaryStringBuilder.Append("</span></a></td></tr>");
                    summaryStringBuilder.Append("<tr class='summarySpacer'></tr>");
                }
                summaryStringBuilder.Append("</table>");
            }

            string summaryString = summaryStringBuilder.ToString();
            return (summaryString);
        }



        public int PlaceCount(string PlaceID)
        {
            var placeCount = db.Places.Where(p => p.PlaceID == PlaceID).Count();

            return (placeCount);
        }


        public int GetCountryID(string CountryName)
        {
            // SELECT: City with matching CityID
            Country country = db.Countries
                                .Where(c => c.Name == CountryName)
                                .FirstOrDefault();

            if (country == null)
            {
                country = new Country
                {
                    Name = CountryName
                };

                db.Countries.Add(country);
                db.SaveChanges();

                Country newCountry = db.Countries
                        .Where(c => c.Name == CountryName)
                        .FirstOrDefault();

                return (newCountry.CountryID);
            }

            return (country.CountryID);
        }


        public int GetStateID(string StateName, int CountryID)
        {
            // SELECT: City with matching CityID
            State state = db.States
                        .Where(c => c.Name == StateName)
                        .FirstOrDefault();

            if (state == null)
            {
                state = new State
                {
                    Name = StateName,
                    CountryID = CountryID
                };

                db.States.Add(state);
                db.SaveChanges();

                State newState = db.States
                        .Where(c => c.Name == StateName)
                        .FirstOrDefault();

                return (newState.StateID);
            }

            return (state.StateID);
        }


        public int GetCityID(string CityName, int StateID, int CountryID)
        {
            // SELECT: City with matching CityID
            City city = db.Cities
                        .Where(c => c.Name == CityName)
                        .FirstOrDefault();

            if (city == null)
            {
                city = new City
                {
                    Name = CityName,
                    StateID = StateID,
                    CountryID = CountryID
                };

                db.Cities.Add(city);
                db.SaveChanges();

                City newCity = db.Cities
                        .Where(c => c.Name == CityName)
                        .FirstOrDefault();

                return (newCity.CityID);
            }

            return (city.CityID);
        }


        public void SaveReview(ReviewViewModel reviewViewModel, string userID)
        {
            reviewViewModel.Review.UserID = userID;
            reviewViewModel.Review.PlaceID = reviewViewModel.Review.GoogleID;
            reviewViewModel.Review.DatePosted = DateTime.Now.ToString();
            reviewViewModel.Review.Flag = 0;
            db.Reviews.Add(reviewViewModel.Review);
            db.SaveChanges();
        }

        public List<Review> AllReviews(string googleID)
        {
            // SELECT: Reviews with matching googleID
            var allReviews = db.Reviews
                            .Where(pl => pl.GoogleID == googleID)
                            .OrderByDescending(pl => pl.DatePosted)
                            .ToList();

            return (allReviews);
        }

        public List<DisplayReviews> FormatReviews(List<Review> allReviews)
        {
            List<DisplayReviews> reviews = new List<DisplayReviews>();

            foreach (var item in allReviews)
            {
                DisplayReviews review = new DisplayReviews();
                review.Review = item;
                //Place
                var place = db.Places.Where(pl => pl.PlaceID == item.PlaceID).FirstOrDefault();
                review.Place = place.Name;
                review.Country = db.Countries.Where(pl => pl.CountryID == place.CountryID).Select(pl => pl.Name).FirstOrDefault();
                review.State = db.States.Where(pl => pl.StateID == place.StateID).Select(pl => pl.Name).FirstOrDefault();
                review.City = db.Cities.Where(pl => pl.CityID == place.CityID).Select(pl => pl.Name).FirstOrDefault();
                var user = db.Users.Where(u => u.UserID == item.UserID).FirstOrDefault();
                review.FirstName = user.FirstName;
                review.LastName = user.LastName;

                reviews.Add(review);
            }

            return (reviews);
        }




    }
}
