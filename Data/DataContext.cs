using Microsoft.EntityFrameworkCore;
using jogovelha.Models;

namespace jogovelha.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; }

        public DbSet<Position> Position { get; set; }

    }
}