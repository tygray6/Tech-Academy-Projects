using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bewander.Models
{
    [Table("User")]
    public class User
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Permission { get; set; }

        [DataType(DataType.DateTime)]
        public string DateJoined { get; set; }

    }
}