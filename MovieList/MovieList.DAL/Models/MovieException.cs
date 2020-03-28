using System;
using System.Collections.Generic;
using System.Text;

namespace MovieList.DAL.Models
{
    public class MovieException : Exception
    {
        public MovieException() { }

        public MovieException(string message) : base(message) { }

        public MovieException(string message, Exception inner) : base(message, inner) { }
    }
}
