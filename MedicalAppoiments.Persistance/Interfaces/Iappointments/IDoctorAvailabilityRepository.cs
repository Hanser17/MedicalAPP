using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Repositories;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppoiments.Persistance.Interfaces.Iappointments
{
    public interface IDoctorAvailabilityRepository : IBaseRepository<DoctorAvailability>
    {
        Task<OperationResult> DoctorAvailabilityByDoctorID(int id);
    }
}
