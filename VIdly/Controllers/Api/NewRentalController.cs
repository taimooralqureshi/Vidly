using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIdly.Dtos;
using VIdly.Models;

namespace VIdly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController() 
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(c => c.id == newRentalDto.CustomerId);

            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not Available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Movie = movie,
                    Customer = customer,
                    RentedDate = DateTime.Now
                   
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();

         
        }
}
}
