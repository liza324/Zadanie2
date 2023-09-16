using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Authors
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Imię autora")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko autora")]
        public string LastName { get; set; }
        [Display(Name = "Data urodzenia")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Kraj pochodzenia")]
        public string CountryOfOrigin { get; set; }
        [Display(Name = "Liczba napisanych książek")]
        public int NumberOfBooks { get; set; }
    }
}
