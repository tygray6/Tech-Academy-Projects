using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bewander.Models
{
    [Table("City")]
    public class City
    {
        public int CityID { get; set; }
        public string Name { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
    }
}