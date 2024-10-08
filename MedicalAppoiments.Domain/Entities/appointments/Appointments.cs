

using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.appointments
{
    [Table("Appointments", Schema = "appointments")]
   public class Appointments :BaseEntity_appoiment
    {
        [Key]
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int StatusID { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
