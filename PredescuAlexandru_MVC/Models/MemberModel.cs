using System.ComponentModel.DataAnnotations;

namespace PredescuAlexandru_MVC.Models
{
    public class MemberModel
    {
        [Key]
        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public Guid IdMember { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Campul poate contine minim 5 caractere si maxim 250 de caractere!!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Campul poate contine minim 5 caractere si maxim 100 de caractere!!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Campul poate contine minim 5 caractere si maxim 250 de caractere!!!")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Campul poate contine minim 5 caractere si maxim 1000 de caractere!!!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public string Resume { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Campul poate contine minim 5 caractere si maxim 250 de caractere!!!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Campul poate contine minim 5 caractere si maxim 250 de caractere!!!")]
        public string Password { get; set; }

    }
}
