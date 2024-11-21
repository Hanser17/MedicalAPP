using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.SystemModel.Roles
{
    public class RolesModelDTO : RolesBaseDTO
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}
