

using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.ImedicalService
{
    public interface  ISpecialtiesService
    {
         Task<OperationResult> GetAllSpecialtiesAsync();
         Task<OperationResult> GetByIDSpecialtiesAsync(int id);

         Task<OperationResult> SaveSpecialtiesAsync(Specialties specialties);
         Task<OperationResult> UpdateSpecialtiesAsync(Specialties specialties);

         Task <OperationResult>DeleteSpecialtiesAsync(Specialties specialties);
    }
}
