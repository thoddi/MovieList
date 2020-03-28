using System;
using System.Collections.Generic;
using System.Text;

namespace MovieList.DAL.Models
{
    public class Movie : MovieDTO
    {
        public int Id { get; set; }
    }

    public class MovieDTO
    {
        public string Name { get; set; }
    }
}
