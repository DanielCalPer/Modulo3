using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoClub.Models
{
    public class UserFilm
    {
        public int Id { get; set; }
        public DateTime Daterental { get; set; }
        public DateTime? Returndate { get; set; } //? asi admite valores nulos
        
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public User User { get; set; }


    }
}
