

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.system
{
    [Table("Roles", Schema = "system")]
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        public string? RoleName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}

        public bool IsActive { get; set; }
    }
}
