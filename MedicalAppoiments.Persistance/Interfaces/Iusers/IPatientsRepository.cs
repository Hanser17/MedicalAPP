using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Repositories;
using MedicalAppoiments.Domain.Result;

namespace MedicalAppoiments.Persistance.Interfaces.Iusers
{
    public interface IPatientsRepository : IBaseRepository<Patients>
    {
         Task<OperationResult> GetPatientsByInsuranceProvider(int  id);
      
    }
}
