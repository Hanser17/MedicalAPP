using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iusers;

namespace MedicalAppoiments.Persistance.Repositories.usersRepository
{
    public class UsersRepository : BaseRepository<users>, IUsersRepository
    {
        public UsersRepository(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }
    }
}
