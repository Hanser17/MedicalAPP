
using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.medical
{
    [Table("Specialties", Schema = "medical")]
    public class Specialties : BaseEntity_medical
    {
        [Key]
        public int SpecialtyID { get; set; }
        public string? SpecialtyName { get; set; }


    }
}
