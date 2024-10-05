

using MedicalAppoiments.Domain.Base;

namespace MedicalAppoiments.Domain.Entities.medical
{
    public class MedicalRecords : BaseEntity_medical
    {

        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }

        public string? Diagnosis { get; set; }

        public string? Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }


    }
}
