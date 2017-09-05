using System;

namespace Puzzle.JsonModels
{
    public class PuzzleJson : IJsonModel
    {
        public string Puzzle { get; set; }
        public string Origin { get; set; }
        public string Answer { get; set; }
    }
}
