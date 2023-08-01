using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PredescuAlexandru_MVC.Models
{
    public class MembershipModel
    {
        [Key]
        public Guid IdMembership { get; set; }

        [ForeignKey ("IdMember")]
        public Guid IdMember { get; set; }

        [ForeignKey ("MembershipIdType")]
        public Guid IdMembershipType { get; set;}

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [Range(1, 100, ErrorMessage = "Level este intre 1 si 100")]
        public int Level { get; set; }
    }
}

