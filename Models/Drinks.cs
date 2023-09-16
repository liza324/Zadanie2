using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Drinks
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Typ")]
        public string Type { get; set; }
        [Display(Name = "Pojemność")]
        public double Capacity { get; set; }
        [Display(Name = "Data przydatności do spożycia")]
        public DateTime ExpiryDate { get; set; }
        [Display(Name = "Smak")]
        public string Flavor { get; set; }
        [Display(Name = "Cena(PLN)")]
        public decimal Price { get; set; }
    }
}
