using MovieList.DAL.Models;
using MovieList.DAL.Repositories;
using System;

namespace MovieList.DAL
{
    public class UnitOfWork
    {
        public MovieRepository Movies;

        public UnitOfWork(MovieContext context)
        {
            this.Movies = new MovieRepository(context);
        }


    }
}
