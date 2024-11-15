
using MedicalAppoiments.Persistance.Models.appointmentsModel;

namespace MedicalAppoiments.Persistance.Models.appointments
{
    public sealed class AppointmentUpdateDTO : AppointmentBaseDTO
    {
        public int AppointmentID { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int StatusID { get; set; }
    }
}
