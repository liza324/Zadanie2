using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace AdvancedProgramming_Lesson1.Models
{
    public class DairtyProducts
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Rodzaj")]
        public string TypeOfProduct { get; set; }
        [Display(Name = "Data przydatności do spożycia")]
        public DateTime ExpiryDate { get; set; }
        [Display(Name = "Waga")]
        public double Weight { get; set; }
        [Display(Name = "Zawartość tłuszczu (%)")]
        public double Fat { get; set; }
        [Display(Name = "Cena (PLN)")]
        public decimal Price { get; set; }
    }
}
