using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Puzzle.Repositories;
using Puzzle.Responses;
using Puzzle.JsonModels;
using System;

namespace Puzzle.Controllers
{

    [Route("api/puzzle")]
    public class PuzzleController : Controller
    {
        private PuzzleRepository _repository;

        public PuzzleController(PuzzleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPuzzle(Guid id)
        {
            var model = await _repository.FindPuzzle(id);
            var puzzle = new PuzzleJson();
            puzzle.Answer = model.Answer;
            puzzle.Origin = model.Origin;
            puzzle.Puzzle = model.Problem;
            return Json(new JsonFormatter(puzzle));
        }

		[HttpPost]
        public IActionResult MakePuzzle([FromBody] PuzzleJson request)
		{
            _repository.Insert(request);
            return Json(request);
		}
	}
}