using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ticapi.Models
{
    public class GameDetailsContext : DbContext
    {
        public GameDetailsContext(DbContextOptions<GameDetailsContext> options)
            : base(options)
        {
        }

        public DbSet<GameDetails> Games { get; set; } = null!;
    }
}