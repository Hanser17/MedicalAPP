

using MedicalAppoiments.Domain.Base;

namespace MedicalAppoiments.Domain.Entities.appointments
{
   public class  DoctorAvailability: BaseEntity_appoiment
    {
        public int AvailabilityID { get; set; }

        public DateTime AvailableDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
