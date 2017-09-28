using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace moviewatch.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string genre { get; set; }

    }
}