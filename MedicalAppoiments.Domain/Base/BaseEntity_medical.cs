
namespace MedicalAppoiments.Domain.Base
{
     public abstract class BaseEntity_medical
    {

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
