
using MedicalAppoiments.Domain.Base;

namespace MedicalAppoiments.Domain.Entities.medical
{
    public class Specialties : BaseEntity_medical
    {

        public int SpecialtyID { get; set; }
        public string? SpecialtyName { get; set; }


    }
}
