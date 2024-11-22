using MedicalAppoiments.Persistance.Models.appointments;
using Newtonsoft.Json;

namespace MedicalAppointmentWeb.Models
{
    [JsonArray]
    public class AppointmentGetResultModel : ResultBaseModel
    {
        public List<AppointmentsModel> data { get; set; }
    }
}
