using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROIECT_MEDII.Models;
using Proiect_Medii.Models;

namespace Proiect_Medii.Data
{
    public class Proiect_MediiContext : DbContext
    {
        public Proiect_MediiContext (DbContextOptions<Proiect_MediiContext> options)
            : base(options)
        {
        }

        public DbSet<PROIECT_MEDII.Models.Artist> Artist { get; set; } = default!;

        public DbSet<PROIECT_MEDII.Models.Festival> Festival { get; set; }

        public DbSet<PROIECT_MEDII.Models.Location> Location { get; set; }

        public DbSet<Proiect_Medii.Models.Order> Order { get; set; }

        public DbSet<PROIECT_MEDII.Models.Producer> Producer { get; set; }

        public DbSet<Proiect_Medii.Models.User> User { get; set; }
    }
}
