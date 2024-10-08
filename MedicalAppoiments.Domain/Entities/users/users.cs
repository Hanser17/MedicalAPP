
using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.users
{
    [Table("users", Schema = "users")]
    public class users : BaseEntity_user
    {
        [Key]
        public int UserID { get; set; }
        public int? RoleID { get; set; }

    }
}
