﻿

using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.medical
{
    [Table("MedicalRecords", Schema = "medical")]
    public class MedicalRecords : BaseEntity_medical
    {
        [Key]
        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }

        public string? Diagnosis { get; set; }

        public string? Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }


    }
}
