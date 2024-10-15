using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iusers;

namespace MedicalAppoiments.Persistance.Repositories.usersRepository
{
    public class PatientsRepositoy : BaseRepository<Patients>, IPatientsRepository
    {
        public PatientsRepositoy(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }
    }
}
