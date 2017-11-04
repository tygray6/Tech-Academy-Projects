using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bewander.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserProfileID { get; set; }

        public string UserID { get; set; }

        [DataType(DataType.MultilineText)]
        public string About { get; set; }

        [Display( Name= "Local of" )]
        public string HomeTown { get; set; }

        [Display(Name = "Travel Locations")]
        public List<Place> TravelLocations { get; set; }

        [Display(Name = "Favorite Locations")]
        public string FavoriteLocation { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}