using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.SystemModel.Roles
{
    public class RolesSaveDto : RolesBaseDTO
    {
        public DateTime? CreateAt { get; set; }

        public bool IsActive { get; set; }
    }
}
