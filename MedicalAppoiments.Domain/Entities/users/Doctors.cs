

using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.users
{
    [Table("Doctors", Schema = "users")]
    public class Doctors : BaseEntity
    {
        [Key]
        public int DoctorID { get; set; }
        public Int16 SpecialtyID { get; set; }
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

        public int UserID { get; set; }



    }
}
