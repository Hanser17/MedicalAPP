

using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.appointments
{
    [Table("DoctorAvailability", Schema = "appointments")]
    public class  DoctorAvailability: BaseEntity_appoiment
    {
        [Key]
        public int AvailabilityID { get; set; }

        public DateTime AvailableDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
