using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VIdly.Models;

namespace VIdly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? id { get; set; }
       
        [StringLength(255)]
        [Required]
        public string Name { get; set; }


        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }


        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return id != 0 ? "Edit Movie" : "New Movie";
            }
        }
        public MovieFormViewModel()
        {
            id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            id = movie.id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}