using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bewander.Models
{
    public class UserProfileViewModel
    {
        public User User { get; set; }
        public UserProfile UserProfile { get; set; }
        public List<Review> Reviews { get; set; }
        public List<File> Avatar { get; set; }
        public List<File> CoverPhoto { get; set; }
        public List<File> Photos { get; set; }
    }
}