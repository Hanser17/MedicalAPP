using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iappointments;

namespace MedicalAppoiments.Persistance.Repositories.appointmentsRepository
{
    public class DoctorAvailabilityRepository : BaseRepository<DoctorAvailability>, IDoctorAvailabilityRepository
    {
        public DoctorAvailabilityRepository(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext)
        {

        }


    }
}
