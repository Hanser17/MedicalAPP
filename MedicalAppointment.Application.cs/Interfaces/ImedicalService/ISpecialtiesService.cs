

using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.ImedicalService
{
    public interface  ISpecialtiesService
    {
        public Task<OperationResult> GetAllSpecialtiesAsync();
        public Task<OperationResult> GetByIDSpecialtiesAsync(int id);

        public Task<OperationResult> SaveSpecialtiesAsync(Specialties specialties);
        public Task<OperationResult> UpdateSpecialtiesAsync(Specialties specialties);

        public Task <OperationResult>DeleteSpecialtiesAsync(Specialties specialties);
    }
}
