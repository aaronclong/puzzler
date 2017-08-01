using Microsoft.EntityFrameworkCore;

namespace Puzzle
{
    public class PuzzleDbContext : DbContext
    {
        public PuzzleDbContext(DbContextOptions<PuzzleDbContext> options)
            : base(options)
        {}
    }
}