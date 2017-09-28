using moviewatch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace moviewatch.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public GenreDTO genre { get; set; }
        [Required]
        public int genreid { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}