using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Alcohols
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Rodzaj")]
        public string TypeOfAlcohol { get; set; }
        [Display(Name = "Objętość (ml, l)")]
        public double Volume { get; set; }
        [Display(Name = "Procentowa zawartość alkoholu (%)")]
        public double PercentageOfAlcoholContent { get; set; }
        [Display(Name = "Ilość cukru (g/100 ml)")]
        public double AmountOfSugar { get; set; }
        [Display(Name = "Cena (PLN)")]
        public decimal Price { get; set; }
        [Display(Name = "Rok produkcji")]
        public int YearOfManufacture { get; set; }
    }
}
