

using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.system
{
    [Table("Roles", Schema = "system")]
    public class Roles : BaseEntity
    {
        [Key]
        public int RoleID { get; set; }
        public string? RoleName { get; set; }

        public bool IsActive { get; set; }


    }
}
