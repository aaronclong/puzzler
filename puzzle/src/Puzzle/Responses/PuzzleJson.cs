using System;
using System.Collections.Generic;
using Puzzle.Models;

namespace Puzzle.Responses
{
    public class PuzzleJson : Response
    {
        private readonly IDictionary<String, String> _puzzle;

        public PuzzleJson(PuzzleModel model)
        {
            _puzzle = new Dictionary<string, string>();
        }

        public object GetMessage()
        {
            return _puzzle;
        }

        private PuzzleModel ExtractPuzzle(PuzzleModel model)
        {
            _puzzle["puzzle"] = model.Problem;
            _puzzle["source"] = model.Origin;
            return model;
        }
    }
}
