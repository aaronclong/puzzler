using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Puzzle.Repositories;

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
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}