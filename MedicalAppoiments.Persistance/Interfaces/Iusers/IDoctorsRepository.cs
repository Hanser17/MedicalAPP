using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Repositories;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppoiments.Persistance.Interfaces.Iusers
{
    public interface IDoctorsRepository : IBaseRepository<Doctors>
    {
        Task<OperationResult> GetDoctorByAvailability(int id);
        Task<OperationResult> GetDoctorBySpecialty(int id);
    }
}
