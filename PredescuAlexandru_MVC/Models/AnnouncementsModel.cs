using PredescuAlexandru_MVC.Models.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace PredescuAlexandru_MVC.Models
{
    public class AnnouncementsModel
    {
        [Key]
        public Guid IdAnnouncement { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [DateMustBeValid("ValidFrom", ErrorMessage = "Trebuie sa fie dupa data de inceput")]
        public DateTime ValidTo { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Campul poate contineminim 5 caractere si maxim 250 de caractere!!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public string Tags { get; set; }

    }
}

