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

        /// <summary>
        /// Uppfærir gildi myndar með gefið raðnúmer.
        /// </summary>
        /// <param name="id">Raðnúmer myndar.</param>
        /// <param name="movie">Uppfærðar upplýsingar myndar.</param>
        /// <returns>True / false, eftir því hvort breyting tókst.</returns>
        public bool Update(int id, MovieDTO movie)
        {
            var movieToBeChanged = Context.Movies.Find(id);

            if(movieToBeChanged == null)
            {
                return false;
            }

            movieToBeChanged.Name = movie.Name;
            Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Eyðir mynd með gefið raðnúmer.
        /// </summary>
        /// <param name="id">Raðnúmer myndar.</param>
        /// <returns>True / false, eftir því hvort eyðsla tókst.</returns>
        public bool Delete(int id)
        {
            var movieToDelete = Context.Movies.Find(id);

            if(movieToDelete == null)
            {
                return false;
            }

            Context.Movies.Remove(movieToDelete);
            Context.SaveChanges();
            return true;
        }
    }
}
