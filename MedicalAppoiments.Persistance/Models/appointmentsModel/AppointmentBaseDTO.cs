

using System.Reflection.Metadata.Ecma335;

namespace MedicalAppoiments.Persistance.Models.appointmentsModel
{
    public abstract class AppointmentBaseDTO
    {
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
