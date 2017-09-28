﻿using moviewatch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace moviewatch.DTO
{
    public class GenreDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string genre { get; set; }
    }
}