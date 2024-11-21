using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.MedicalModel.Specialties
{
    public class SpecialtiesModelDTO : SpecialtiesBaseDTO
    {
        public short SpecialtyID { get; set; }
        public string? SpecialtyName { get; set; }

        public bool IsActive { get; set; }
    }
}
