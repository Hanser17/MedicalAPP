using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Isystem;

namespace MedicalAppoiments.Persistance.Repositories.systemRepository
{
    public class RolesRepository : BaseRepository<Roles>, IRolesRepository
    {
        public RolesRepository(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }
    }
}
