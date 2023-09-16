using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AdvancedProgramming_Lesson1.Models
{
    public class AuthorsBooks
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Tytuł książki")]
        public string BookTitle { get; set; }
        [Display(Name = "Rok wydania")]
        public string YearOfPublication { get; set; }
        [Display(Name = "Gatunek literacki")]
        public string LiteraryGenre { get; set; }
        [Display(Name = "Liczba stron")]
        public int PageCount { get; set; }
        [Display(Name = "Cena (PLN)")]
        public decimal Price { get; set; }
    }
}
