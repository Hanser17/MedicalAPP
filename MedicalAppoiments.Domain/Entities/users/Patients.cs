﻿

using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.users
{
    [Table("Patients", Schema = "users")]
    public class Patients : BaseEntity
    {
        [Key]
        public int PatientID { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? BloodType { get; set; }
        public string? Allergies { get; set; }
        public int InsuranceProviderID { get; set; }

        public bool IsActive { get; set; }

     


    }
}
