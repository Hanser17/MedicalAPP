using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Repositories;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppoiments.Persistance.Interfaces.Iinsurance
{
    public interface IInsuranceProvidersRepository : IBaseRepository<InsuranceProviders>
    {
        Task<OperationResult> GetInsuranceProvidersByNetWork(int id);

    }
}
