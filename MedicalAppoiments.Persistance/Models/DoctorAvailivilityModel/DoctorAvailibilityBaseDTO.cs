using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.DoctorAvailivilityModel
{
    public abstract class DoctorAvailibilityBaseDTO
    {
        public int DoctorID { get; set; }
        public DateOnly AvailableDate { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}
