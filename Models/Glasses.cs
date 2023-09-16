using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Glasses
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Title { get; set; }
        [Display(Name = "Pojemność (ml)")]
        public double Capacity { get; set; }
        [Display(Name = "Waga (g)")]
        public double Weight { get; set; }
        [Display(Name = "Typ")]
        public string Type { get; set; }
        [Display(Name = "Kolor")]
        public string Color { get; set; }
        [Display(Name = "Materiał wykonania")]
        public string MaterialOfManufacture { get; set; }
    }
}
