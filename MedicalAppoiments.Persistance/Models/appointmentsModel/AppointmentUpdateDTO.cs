
using MedicalAppoiments.Persistance.Models.appointmentsModel;

namespace MedicalAppoiments.Persistance.Models.appointments
{
    public sealed class AppointmentUpdateDTO : AppointmentBaseDTO
    {
        public int AppointmentID { get; set; }

        public int StatusID { get; set; }


        public string StatusName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
    }
}
