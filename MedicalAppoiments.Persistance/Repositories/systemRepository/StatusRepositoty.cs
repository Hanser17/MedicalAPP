using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Isystem;

namespace MedicalAppoiments.Persistance.Repositories.systemRepository
{
    public class StatusRepositoty : BaseRepository<Status>, IStatusRepositoty
    {
        public StatusRepositoty(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }
    }
}
