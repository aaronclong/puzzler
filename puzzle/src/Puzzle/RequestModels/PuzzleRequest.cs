using System;

namespace Puzzle.RequestModels
{
    public class PuzzleRequest
    {
        public string Puzzle { get; set; }
        public string Origin { get; set; }
        public string Answer { get; set; }
    }
}
