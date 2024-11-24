

namespace MedicalAppoiments.Persistance.Models.appointmentsModel
{
    public sealed class AppointmentSaveDTO : AppointmentBaseDTO
    {
        public DateTime CreatedAt { get; set; }

        public int StatusID { get; set; }
    }
}
 