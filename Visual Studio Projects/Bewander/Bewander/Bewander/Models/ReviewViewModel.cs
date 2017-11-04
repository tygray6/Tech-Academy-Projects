using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bewander.Models
{
    public class ReviewViewModel
    {
        public Review Review { get; set; }
        public Place Place { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
    }

    public class DisplayReviews
    {
        public Review Review { get; set; }
        //public Place Place { get; set; }
        public string Place { get; set; }
        public string Local { get; set; }
        public string Subject { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}