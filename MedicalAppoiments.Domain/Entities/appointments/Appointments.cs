

using MedicalAppoiments.Domain.Base;

namespace MedicalAppoiments.Domain.Entities.appointments
{
   public class Appointments :BaseEntity_appoiment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int StatusID { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
