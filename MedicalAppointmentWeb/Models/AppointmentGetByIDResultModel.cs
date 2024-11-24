using MedicalAppoiments.Persistance.Models.appointments;

namespace MedicalAppointmentWeb.Models
{
    public class AppointmentGetByIDResultModel : ResultBaseModel
    {
        public AppointmentsModel Data { get; set; }
    }
}
