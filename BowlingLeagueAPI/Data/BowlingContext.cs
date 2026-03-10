using BowlingLeagueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeagueAPI.Data
{
    // EF Core DbContext -- bridges the app to the BowlingLeague SQLite database
    public class BowlingContext : DbContext
    {
        public BowlingContext(DbContextOptions<BowlingContext> options) : base(options) { }

        // Tables mapped to the database
        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
