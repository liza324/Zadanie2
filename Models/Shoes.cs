using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Shoes
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Rodzaj")]
        public string Title { get; set; }
        [Display(Name = "Rozmiar")]
        public int Size { get; set; }
        [Display(Name = "Cena (PLN)")]
        public decimal Price { get; set; }
        [Display(Name = "Waga (g)")]
        public double Weight { get; set; }
        [Display(Name = "Długość wkładki (cm)")]
        public double InsoleLength { get; set; }
        [Display(Name = "Rodzaj materiału")]
        public string TypeOfMaterial { get; set; }
    }
}
