﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bewander.Models
{
    [Table("Country")]
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
    }
}