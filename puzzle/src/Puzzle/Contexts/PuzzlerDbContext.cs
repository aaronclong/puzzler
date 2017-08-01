using Microsoft.EntityFrameworkCore;
using Puzzle.Models;

namespace Puzzle.Contexts
{
    public class PuzzlerDbContext : DbContext
    {
        public DbSet<PuzzleModel> Puzzles { get; set; }
        
        public PuzzlerDbContext(DbContextOptions<PuzzlerDbContext> options)
            : base(options)
        {}
    }
}