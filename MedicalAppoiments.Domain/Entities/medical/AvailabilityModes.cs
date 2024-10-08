

using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.medical
{
    [Table("AvailabilityModes", Schema = "medical")]
    public class AvailabilityModes : BaseEntity_medical
    {
        [Key]
        public int SAvailabilityModeID { get; set; }
        public string? AvailabilityMode { get;}



    }
}
