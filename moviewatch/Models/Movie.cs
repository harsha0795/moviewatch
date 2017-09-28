using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace moviewatch.Models
{
    public class Movie
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } 
        [Required]
        [Display(Name ="Genre")]
        public int genreid { get; set; }
        public Genre genre { get; set; }
        [Required(ErrorMessage ="Please Select from the Dropdown")]
        [Display(Name = "Date of Release")]
        public DateTime ReleaseDate { get; set; }

    }

}