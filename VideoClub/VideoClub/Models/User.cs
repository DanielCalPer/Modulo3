using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoClub.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        [EmailAddress (ErrorMessage ="Formato de email incorrecto")]
        public string Email { get; set; }
        public string ProfilePicture { get; set; }

        public List<UserFilm> UserFilms { get; set; }
    }
}
