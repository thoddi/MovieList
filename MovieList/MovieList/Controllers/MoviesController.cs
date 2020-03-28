using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieList.DAL;
using MovieList.DAL.Models;
using MovieList.Models;

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
        public Response<IEnumerable<Movie>> Get()
        {
            try
            {
                var movies = Uow.Movies.Get();
                return new Response<IEnumerable<Movie>>("Myndir sóttar", movies);
            }
            catch(Exception)
            {
                return new Response<IEnumerable<Movie>>("Ekki tókst að sækja myndir", "Óskilgreind villa!");
            }
        }

        /// <summary>
        /// Skilar mynd með gefið raðnúmer.
        /// </summary>
        /// <param name="id">Raðnúmer myndar.</param>
        /// <returns>Upplýsingar myndar.</returns>
        [HttpGet]
        [Route("{id}")]
        public Response<Movie> GetById(int id)
        {
            try
            {
                var movie = Uow.Movies.GetById(id);
                return new Response<Movie>("Mynd fannst.", movie);
            }
            catch(MovieException e)
            {
                return new Response<Movie>("Ekki tókst að sækja mynd.", e.Message);
            }
            catch (Exception)
            {
                return new Response<Movie>("Ekki tókst að sækja mynd", "Óskilgreind villa!");
            }
        }

        /// <summary>
        /// Bætir mynd við gagnagrunninn.
        /// </summary>
        /// <param name="movie">Mynd til að bæta við.</param>
        /// <returns>Raðnúmer nýrrar færslu.</returns>
        [HttpPost]
        public Response<int> Insert(MovieDTO movie)
        {
            try
            {
                int id = Uow.Movies.Insert(movie);
                Uow.Save();
                return new Response<int>("Mynd hefur verið bætt við.", id);
            }
            catch (Exception)
            {
                return new Response<int>("Ekki tókst að bæta við mynd.", "Óskilgreind villa!");
            }
        }

        /// <summary>
        /// Uppfærir gildi myndar með gefið raðnúmer.
        /// </summary>
        /// <param name="id">Raðnúmer myndar.</param>
        /// <param name="movie">Uppfærðar upplýsingar myndar.</param>
        /// <returns>True / false, eftir því hvort breyting tókst.</returns>
        [HttpPut]
        [Route("{id}")]
        public Response Update(int id, MovieDTO movie)
        {
            try
            {
                if(Uow.Movies.Update(id, movie))
                {
                    return new Response("Mynd uppfærð!");
                }
                return new Response("Ekki tókst að uppfæra mynd.", "Óskilgreind villa!");
            }
            catch (MovieException e)
            {
                return new Response("Ekki tókst að uppfæra mynd.", e.Message);
            }
            catch (Exception)
            {
                return new Response<Movie>("Ekki tókst að uppfæra mynd.", "Óskilgreind villa!");
            }
        }

        /// <summary>
        /// Eyðir mynd með gefið raðnúmer.
        /// </summary>
        /// <param name="id">Raðnúmer myndar.</param>
        /// <returns>True / false, eftir því hvort eyðsla tókst.</returns>
        [HttpDelete]
        [Route("{id}")]
        public Response Delete(int id)
        {
            try
            {
                if (Uow.Movies.Delete(id))
                {
                    return new Response("Mynd eytt!");
                }
                return new Response("Ekki tókst að eyða mynd.", "Óskilgreind villa!");
            }
            catch (MovieException e)
            {
                return new Response("Ekki tókst að eyða mynd.", e.Message);
            }
            catch (Exception)
            {
                return new Response<Movie>("Ekki tókst að eyða mynd.", "Óskilgreind villa!");
            }
        }
    }
}
