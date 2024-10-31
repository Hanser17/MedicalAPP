

using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.IinsuranceService
{
    public interface  INetworkTypeService
    {
         Task<OperationResult> GetAllNetworkTypeAsync();
         Task<OperationResult> GetByIDNetworkTypeAsync(int id);

         Task<OperationResult> SaveNetworkTypeAsync(NetworkType networkType);
         Task<OperationResult> UpdateNetworkTypeAsync(NetworkType networkType);

         Task<OperationResult> DeleteNetworkTypeAsync(NetworkType networkType);
    }
}
