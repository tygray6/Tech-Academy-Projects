using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Bewander.Models
{
    [Table("Review")]
    public partial class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewID { get; set; }

        public string UserID { get; set; }

        [Required]
        public string GoogleID { get; set; }

        public string PlaceID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(700)]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [DataType(DataType.DateTime)]
        public string DatePosted { get; set; }

        [Range(0, 2)]
        public int Local { get; set; }

        [Range(0, 10)]
        public int? StarRating { get; set; }

        [Range(0, 5)]
        public int? CostRating { get; set; }

        public int Flag { get; set; }

        [Required]
        public int SubjectID { get; set; }

    }
}