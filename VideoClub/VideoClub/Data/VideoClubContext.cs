using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoClub.Models;

namespace VideoClub.Models
{
    public class VideoClubContext : DbContext
    {
        public VideoClubContext (DbContextOptions<VideoClubContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Film> Film { get; set; }

        public DbSet<UserFilm> UserFilm { get; set; }
    }
}
