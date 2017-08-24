using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Puzzle.Repositories;
using Puzzle.Responses;
using System;

namespace Puzzle.Controllers
{

    [Route("puzzle")]
    public class PuzzleController : Controller
    {
        private PuzzleRepository _repository;

        public PuzzleController(PuzzleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetPuzzle(Guid id)
        {
            var puzzle = new PuzzleJson();

            return Json(new JsonFormatter(puzzle));
        }
    }
}