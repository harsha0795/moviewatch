using System;
using System.Collections.Generic;
using System.Linq;

namespace moviewatch.Models
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> genre { get; set; }
        public Movie Movie { get; set; }
    }
};