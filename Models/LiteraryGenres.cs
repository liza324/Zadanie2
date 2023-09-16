using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AdvancedProgramming_Lesson1.Models
{
    public class LiteraryGenres
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Nazwa gatunku ")]
        public string GenreName { get; set; }
        [Display(Name = "Data powstania gatunku")]
        public string DateOfOriginOfTheGenre { get; set; }
        [Display(Name = "Główne motywy występujące w gatunku")]
        public string TheMainMotifsInTheGenre { get; set; }
        [Display(Name = "Popularność gatunku")]
        public double PopularityOfTheGenre { get; set; }
        [Display(Name = "Liczba książek w danym gatunku")]
        public double TheNumberOfBooksInAGivenGenre { get; set; }
    }
}
