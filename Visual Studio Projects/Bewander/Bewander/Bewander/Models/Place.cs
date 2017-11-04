using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bewander.Models
{
    [Table("Place")]
    public class Place
    {
        public string PlaceID { get; set; }
        public string Name { get; set; }
        public int StreetNumber { get; set; }
        public string Route { get; set; }
        public string PostalCode { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public string Website { get; set; }
        public List<string> Hours { get; set; }
    }
}