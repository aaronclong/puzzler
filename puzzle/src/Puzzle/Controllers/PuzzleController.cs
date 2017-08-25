using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Puzzle.Repositories;
using Puzzle.Responses;
using System;

namespace Puzzle.Controllers
{

    [Route("api/puzzle")]
    public class PuzzleController : Controller
    {
        private PuzzleRepository _repository;
        private readonly string PUZZLE_ADDED = "The Puzzle was added sucessfully";

        public PuzzleController(PuzzleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPuzzle(Guid id)
        {
            var model = await _repository.FindPuzzle(id);
            var puzzle = new PuzzleJson(model);
            return Json(new JsonFormatter(puzzle));
        }

		[HttpPost]
        public IActionResult MakePuzzle([FromBody] PuzzleRequest request)
		{
            _repository.Insert(request);
            return Json(new JsonFormatter(PUZZLE_ADDED));
		}
	}
}