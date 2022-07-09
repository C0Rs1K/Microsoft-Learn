using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required, StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
        
        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [StringLength(maximumLength: 30), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Genre { get; set; } = string.Empty;

        [Range(minimum: 1, maximum: 100), Column(TypeName ="decimal(18,2)"), DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required, StringLength(maximumLength: 5), RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Rating { get; set; } = string.Empty;
    }
}