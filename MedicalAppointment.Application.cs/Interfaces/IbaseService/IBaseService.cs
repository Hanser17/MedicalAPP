
using Azure;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppointment.Application.Interfaces.IbaseService
{
    public interface IBaseService<TSaveDto, TUpdateDto>
    {
        Task<OperationResult> SaveAsync(TSaveDto dto);
        Task<OperationResult> UpdateAsync(TUpdateDto dto);
    }
}
