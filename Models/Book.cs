using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Book
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Title { get; set; }
        [Display(Name = "Liczba stron")]
        public int NumberOfPages { get; set; }
        [Display(Name = "Cena (PLN)")]
        public decimal Price { get; set; }
        [Display(Name = "Rok wydania ")]
        public int ReleaseYear { get; set; }
        [Display(Name = "Ocena czytelników")]
        public double ReadersRating { get; set; }
        [Display(Name = "Nakład")]
        public int Input { get; set; }
    }
}
