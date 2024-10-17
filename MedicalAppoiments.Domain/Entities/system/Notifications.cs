﻿

using MedicalAppoiments.Domain.Base;

namespace MedicalAppoiments.Domain.Entities.system
{
    public class Notifications :BaseEntity
    {
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }
        public int InsuranceProviderID { get; set; }
        public bool IsActive { get; set; }

    }
}