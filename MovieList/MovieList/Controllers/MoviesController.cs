﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieList.DAL;
using MovieList.DAL.Models;

namespace MovieList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;

        private readonly UnitOfWork _uow;
        public UnitOfWork Uow => _uow;

        public MoviesController(ILogger<MoviesController> logger, MovieContext context)
        {
            _logger = logger;
            _uow = new UnitOfWork(context);
        }

        /// <summary>
        /// Skilar öllum myndum.
        /// </summary>
        /// <returns>Lista af myndum.</returns>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return Uow.Movies.Get();
        }
    }
}
