using Puzzle.Contexts;

namespace Puzzle.Repositories
{
    public class PuzzleRepository : IRepository
    {
        private PuzzlerDbContext _context;
        public PuzzleRepository(PuzzlerDbContext context)
        {
            _context = context;
        }
    }
}