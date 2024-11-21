using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.MedicalModel.MedicalRecorsd
{
    public abstract class MedicalRecorsdBaseDTO
    {
        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }

        public string? Diagnosis { get; set; }

        public string? Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }


    }
}
