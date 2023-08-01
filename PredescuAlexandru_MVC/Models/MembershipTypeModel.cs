using System.ComponentModel.DataAnnotations;

namespace PredescuAlexandru_MVC.Models
{
    public class MembershipTypeModel
    {
        [Key]
        public Guid IdMembershipType { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu !!!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Campul poate contine inim 5 caractere si maxim 250 de caractere!!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu !!!")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Campul poate contine minim 5 caractere si maxim 250 de caractere!!!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu !!!")]
        public int SubcriptionLenghtInMonths { get; set; }
    }
}
