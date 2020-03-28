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
            return Context.Movies.ToList();
        }

        /// <summary>
        /// Skilar mynd með gefið raðnúmer.
        /// </summary>
        /// <param name="id">Raðnúmer myndar.</param>
        /// <returns>Upplýsingar myndar.</returns>
        public Movie GetById(int id)
        {
            return Context.Movies.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Bætir mynd við gagnagrunninn.
        /// </summary>
        /// <param name="movie">Mynd til að bæta við.</param>
        /// <returns>Raðnúmer nýrrar færslu.</returns>
        public int Insert(MovieDTO movie)
        {
            var newMovie = new Movie
            {
                Name = movie.Name
            };

            Context.Movies.Add(newMovie);
            Context.SaveChanges();

            return newMovie.Id;
        }
    }
}
