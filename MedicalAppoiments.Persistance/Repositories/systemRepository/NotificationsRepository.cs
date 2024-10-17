

using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Isystem;

namespace MedicalAppoiments.Persistance.Repositories.systemRepository
{
    public class NotificationsRepository : BaseRepository<Notifications>, INotificationsRepository
    {
        public NotificationsRepository(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }
    }
}
