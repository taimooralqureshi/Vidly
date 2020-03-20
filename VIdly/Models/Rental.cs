
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIdly.Models
{
    public class Rental
    {
        public int id { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }

        public DateTime RentedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

    }
}