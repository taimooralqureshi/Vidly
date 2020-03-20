using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIdly.Dtos;
using VIdly.Models;

namespace VIdly.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       
       
        public IHttpActionResult GetMovie(string query = null)
        {
            var moviesQuery = _context.Movies.Include(m => m.Genre).Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            moviesQuery




                .ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesQuery);
        }
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.id == id);

            if (movie == null)
                return NotFound();



            return Ok(Mapper.Map<Movie,MovieDto>(movie));
        }



        [HttpPost]
  
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.id = movie.id; 
            return Created(new Uri(Request.RequestUri+"/"+movie.id),movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movieInDb == null)
                return NotFound();
            movieDto.DateAdded = movieInDb.DateAdded;
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
          

            var movieInDb = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }


    }


}
