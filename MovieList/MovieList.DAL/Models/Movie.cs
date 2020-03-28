using System;
using System.Collections.Generic;
using System.Text;

namespace MovieList.DAL.Models
{
    public class Movie : MovieDTO
    {
        /// <summary>
        /// Raðnúmer myndar.
        /// </summary>
        public int Id { get; set; }
    }

    public class MovieDTO
    {
        /// <summary>
        /// Heiti myndar.
        /// </summary>
        public string Name { get; set; }
    }
}
