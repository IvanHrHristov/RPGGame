using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.EF_Core
{
    public class RPGContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-E0HI4PO\\SOFTUNI_SQL;Database=RPGDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }
}
