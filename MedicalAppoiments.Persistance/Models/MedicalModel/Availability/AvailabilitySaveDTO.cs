using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.MedicalModel.Availability
{
    public class AvailabilitySaveDTO : AvailabilityBaseDTO
    {

        public DateTime? CreateAt { get; set; }
        public bool IsActive { get; set; }

    }
}
