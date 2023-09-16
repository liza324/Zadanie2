using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Knives
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Title { get; set; }
        [Display(Name = "Długość ostrza (cm)")]
        public double BladeLength { get; set; }
        [Display(Name = "Waga (g)")]
        public double Weight { get; set; }
        [Display(Name = "Typ ostrza")]
        public string BladeType { get; set; }
        [Display(Name = "Materiał rękojeści")]
        public string HandleMaterial { get; set; }
        [Display(Name = "Stopień ostrości")]
        public double DegreeOfSeverity { get; set; }
    }
}
