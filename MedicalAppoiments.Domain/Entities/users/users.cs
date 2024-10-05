
using MedicalAppoiments.Domain.Base;

namespace MedicalAppoiments.Domain.Entities.users
{
    public class users : BaseEntity_user
    {
        public int UserID { get; set; }
        public int? RoleID { get; set; }

    }
}
