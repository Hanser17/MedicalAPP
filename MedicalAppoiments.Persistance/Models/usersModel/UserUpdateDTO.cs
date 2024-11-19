using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.usersModel
{
    public class UserUpdateDTO : UserBaseDTO
    {
        public int UserID { get; set; }

        public bool IsActive { get; set; }
    }
}
