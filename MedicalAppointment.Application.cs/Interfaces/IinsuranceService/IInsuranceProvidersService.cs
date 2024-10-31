using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Application.Interfaces.IinsuranceService
{
    public interface  IInsuranceProvidersService
    {
        Task<OperationResult> GetAllInsuranceProvidersAsync();
        Task<OperationResult> GetByIDInsuranceProvidersAsync(int id);

        Task<OperationResult> SaveInsuranceProvidersAsync(InsuranceProviders insuranceProviders);
        Task<OperationResult> UpdateInsuranceProvidersAsync(InsuranceProviders insuranceProviders);

        Task<OperationResult> DeleteInsuranceProvidersAsync(InsuranceProviders insuranceProviders);
    }
}
