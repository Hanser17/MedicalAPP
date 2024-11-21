using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.SystemModel.Status
{
    public class StatusModelDTO : StatusBaseDTO
    {
        public int StatusID { get; set; }
        public string? StatusName { get; set; }
    }
}
