

namespace MedicalAppoiments.Persistance.Models.usersModel
{
    public class DoctorsModel
    {
        // from class Doctor
        public string RoleName { get; set; }
        public int DoctorID { get; set; }
        // from class Users
        public string FirstName { get; set;}
        // from class Users
        public string LastName { get; set; }
        // from class Doctor
        public decimal? ConsultationFee { get; set; }

        // from class Specialties
        public string SpecialtyName { get; set; }

        // from class Doctor
        public bool IsActive { get; set; }

        

    }
}
