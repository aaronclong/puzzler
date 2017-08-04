using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puzzle.Models
{
    [Table("puzzles")]
    public class PuzzleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Problem { get; set; }
        public DateTime Added { get; set; }
    }
}