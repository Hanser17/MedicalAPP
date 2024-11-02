using MedicalAppoiments.Persistance.Models.BaseModel;

namespace MedicalAppoiments.Persistance.Models.appointments
{
    public sealed  class AppointmentsModel
    {
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }

        public int PatientID { get; set; }
        public DateTime? AppointmentDate { get; set; }


        public string StatusName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
    }
}
