
using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.ImedicalService
{
    public interface IAvailabilityModesService
    {
        public Task<OperationResult> GetAllAvailabilityModesAsync();
        public Task<OperationResult> GetByIDAvailabilityModesAsync(int id);

        public Task<OperationResult> SaveAvailabilityModesAsync(AvailabilityModes availabilityModes);
        public Task<OperationResult> UpdateAvailabilityModesAsync(AvailabilityModes availabilityModes);

        public Task<OperationResult> DeleteAvailabilityModesAsync(AvailabilityModes availabilityModes);
    }
}
