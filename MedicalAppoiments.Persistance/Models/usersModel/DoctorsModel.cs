

using MedicalAppoiments.Persistance.Models.BaseModel;

namespace MedicalAppoiments.Persistance.Models.usersModel
{
    public class DoctorsModel : Basemodel
    {
        // from class Doctor
        public string RoleName { get; set; }
        public int DoctorID { get; set; }

        // from class Doctor
        public decimal? ConsultationFee { get; set; }

        // from class Specialties
        public string SpecialtyName { get; set; }

        // from class Doctor
        public bool IsActive { get; set; }

        

    }
}
