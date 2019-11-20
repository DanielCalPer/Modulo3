using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoClub.Models
{
    public class Film
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [Required] // asi no puede ser nulo. 
        public string Title { get; set; }
        public string Sinopsis { get; set; }
        [MaxLength(15)]
        [Required]
        public string Genre { get; set; }
        public string Image { get; set; }
        public string Rented { get; set; }

        public List<UserFilm> UserFilms { get; set; }
    }
}
