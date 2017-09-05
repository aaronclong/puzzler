using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puzzle.Models
{
    [Table("puzzles", Schema = "puzzler")]
    public class PuzzleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Problem { get; set; }
        public string Answer { get; set; }
        public string Origin { get; set; }
        public DateTime Added { get; set; }
    }
}