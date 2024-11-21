using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.MedicalModel.Specialties
{
    public abstract class SpecialtiesBaseDTO
    {
        public short SpecialtyID { get; set; }
        public string? SpecialtyName { get; set; }

        public bool IsActive { get; set; }
    }
}
