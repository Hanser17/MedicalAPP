using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.MedicalModel.MedicalRecorsd
{
    public class MedicalRecorsdSaveDTO : MedicalRecorsdBaseDTO
    {
        public DateTime? CreateAt { get; set; }
        public bool IsActive { get; set; }
    }
}
