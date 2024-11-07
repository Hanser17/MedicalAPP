using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iinsurance;
using MedicalAppointment.Application.Interfaces.IinsuranceService;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Service.insurance.Service
{
    public class InsuranceProvidersService : IInsuranceProvidersService
    {
        private readonly IInsuranceProvidersRepository _insuranceProvidersRepository;
        private readonly ILogger<InsuranceProvidersService> _logger;

        public InsuranceProvidersService (IInsuranceProvidersRepository insuranceProvidersRepository, ILogger<InsuranceProvidersService> logger)
        {
            _insuranceProvidersRepository = insuranceProvidersRepository;
            _logger = logger;
        }

        public async Task<OperationResult> DeleteInsuranceProvidersAsync(InsuranceProviders insuranceProviders)
        {
            return await _insuranceProvidersRepository.Remove(insuranceProviders);
        }

        public async Task<OperationResult> GetAllInsuranceProvidersAsync()
        {
            return await _insuranceProvidersRepository.GetAll();
        }

        public async Task<OperationResult> GetByIDInsuranceProvidersAsync(int id)
        {
            return await _insuranceProvidersRepository.GetEntityBy(id);
        }

        public async Task<OperationResult> SaveInsuranceProvidersAsync(InsuranceProviders insuranceProviders)
        {
            return await _insuranceProvidersRepository.Save(insuranceProviders);
        }

        public async Task<OperationResult> UpdateInsuranceProvidersAsync(InsuranceProviders insuranceProviders)
        {
            return await _insuranceProvidersRepository.Update(insuranceProviders);
        }

        public async Task<OperationResult> GetInsuranceProvidersByNetWorkAsync(int id)
        {
            return await _insuranceProvidersRepository.GetInsuranceProvidersByNetWork(id);
        }
    }
}
