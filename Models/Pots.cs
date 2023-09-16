using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Pots
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Title { get; set; }
        [Display(Name = "Pojemność (l)")]
        public double Capacity { get; set; }
        [Display(Name = "Waga (kg)")]
        public double Weight { get; set; }
        [Display(Name = "Typ pokrywki")]
        public string LidType { get; set; }
        [Display(Name = "Ilość uchwytów")]
        public int NumberOfHandles { get; set; }
        [Display(Name = "Materiał wykonania")]
        public string Material { get; set; }
    }
}
