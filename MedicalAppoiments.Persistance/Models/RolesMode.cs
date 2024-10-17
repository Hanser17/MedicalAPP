

namespace MedicalAppoiments.Persistance.Models
{
    public sealed class RolesMode
    {

        public int RoleID { get; set; }
        public string? RoleName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
