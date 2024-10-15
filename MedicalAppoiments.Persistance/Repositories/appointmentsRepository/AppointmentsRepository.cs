using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iappointments;

namespace MedicalAppoiments.Persistance.Repositories.appointmentsRepository
{
    public class AppointmentsRepository : BaseRepository<Appointments>, IAppointmentsRepository
    {
        public AppointmentsRepository(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }

    }
}
