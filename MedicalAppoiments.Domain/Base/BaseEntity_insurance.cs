

namespace MedicalAppoiments.Domain.Base
{
    public abstract class BaseEntity_insurance
    {
        public int NetworkTypeId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }


    }
}
