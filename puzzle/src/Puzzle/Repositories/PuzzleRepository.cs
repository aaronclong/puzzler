using Puzzle.Contexts;
using Puzzle.Models;
using Puzzle.RequestModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Puzzle.Repositories
{
    public class PuzzleRepository : IRepository
    {
        private PuzzlerDbContext _context;

        public PuzzleRepository(PuzzlerDbContext context)
        {
            _context = context;
        }

        public async Task<PuzzleModel> FindPuzzle(Guid id)
        {
            return await _context.Puzzles.SingleOrDefaultAsync(m => m.Id == id);
        }

        public PuzzleModel Insert(PuzzleRequest puzzle)
        {
            var dbModel = new PuzzleModel()
            {
                Problem = puzzle.Puzzle,
                Origin = puzzle.Origin,
                Added = DateTime.Now
            };
            _context.Add(dbModel);
            _context.SaveChanges();

            return dbModel;
        }
    }
}