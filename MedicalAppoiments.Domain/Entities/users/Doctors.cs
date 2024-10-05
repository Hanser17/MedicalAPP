

using MedicalAppoiments.Domain.Base;

namespace MedicalAppoiments.Domain.Entities.users
{
    public class Doctors : BaseEntity_user
    {
        public int DoctorID { get; set; }
        public int SpecialtyID { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string Education { get; set; }
        public string? Bio { get; set; }
        public decimal? ConsultationFee { get; set; }
        public string? ClinicAddress { get; set; }
        public int? AvailabilityModeId { get; set; }
        public DateTime LicenseExpirationDate { get; set; }
      

    }
}
