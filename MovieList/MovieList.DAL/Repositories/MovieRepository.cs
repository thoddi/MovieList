﻿using MovieList.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieList.DAL.Repositories
{
    public class MovieRepository
    {
        private readonly MovieContext _context;
        public MovieContext Context => _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Sækir allar myndir.
        /// </summary>
        /// <returns>Lista af myndum.</returns>
        public List<Movie> Get()
        {
            //return Context.Movies.ToList();

            return new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Name = "Click"
                },
                new Movie
                {
                    Id = 2,
                    Name = "Toy Story"
                }
            };
        }

        /// <summary>
        /// Skilar mynd með gefið raðnúmer.
        /// </summary>
        /// <param name="id">Raðnúmer myndar.</param>
        /// <returns>Upplýsingar myndar.</returns>
        public Movie GetById(int id)
        {
            var list = Get();

            return list.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
