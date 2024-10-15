using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Imedical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Repositories.medicalRepository
{
    public class AvailabilityModesRepository : BaseRepository<AvailabilityModes>, IAvailabilityModesRepository
    {
        public AvailabilityModesRepository(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }
    }
}
