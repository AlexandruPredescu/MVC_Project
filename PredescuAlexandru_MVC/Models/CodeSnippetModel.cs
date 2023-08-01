using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PredescuAlexandru_MVC.Models
{
    public class CodeSnippetModel
    {
        [Key]
        public Guid IdCodeSnippet { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Campul poate contine minim 5 caractere si maxim 100 de caractere!!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public string ContentCode { get; set; }


        [ForeignKey("IdMember")]
        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public Guid IdMember { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [Range(1, 100, ErrorMessage = "Revision este intre 1 si 100")]
        public int Revision { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime DateTimeAdded { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public bool IsPublished { get; set; }
    }
}
