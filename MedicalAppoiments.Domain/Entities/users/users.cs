
using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.users
{
    [Table("users", Schema = "users")]
    public class users : BaseEntity
    {
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public int? RoleID { get; set; }

    }
}
