
using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.ImedicalService
{
    public interface IAvailabilityModesService
    {
         Task<OperationResult> GetAllAvailabilityModesAsync();
         Task<OperationResult> GetByIDAvailabilityModesAsync(int id);

         Task<OperationResult> SaveAvailabilityModesAsync(AvailabilityModes availabilityModes);
         Task<OperationResult> UpdateAvailabilityModesAsync(AvailabilityModes availabilityModes);

         Task<OperationResult> DeleteAvailabilityModesAsync(AvailabilityModes availabilityModes);
    }
}
