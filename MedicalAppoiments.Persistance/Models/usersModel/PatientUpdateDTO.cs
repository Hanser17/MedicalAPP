using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.usersModel
{
    public class PatientUpdateDTO : PatientBaseDTO
    {
        public int  PatientID { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
