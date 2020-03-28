using MovieList.DAL.Models;
using MovieList.DAL.Repositories;
using System;

namespace MovieList.DAL
{
    public class UnitOfWork
    {
        public MovieRepository Movies;
        public MovieContext Context;

        public UnitOfWork(MovieContext context)
        {
            this.Movies = new MovieRepository(context);
            this.Context = context;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
