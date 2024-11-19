

using MedicalAppoiments.Persistance.Models.BaseModel;

namespace MedicalAppoiments.Persistance.Models.usersModel
{
    public class DoctorsModel : Basemodel
    {
        // from class Doctor
        public string RoleName { get; set; }
        public int DoctorID { get; set; }
        public Int16 SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string? Education { get; set; }
        public string? Bio { get; set; }
        public decimal? ConsultationFee { get; set; }
        public string? ClinicAddress { get; set; }
        public int? AvailabilityModeId { get; set; }
        public DateTime LicenseExpirationDate { get; set; }
        public bool IsActive { get; set; }
       

        

    }
}
