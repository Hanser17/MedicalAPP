using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iinsurance;


namespace MedicalAppoiments.Persistance.Repositories.insuranceRepository
{
    public class InsuranceProvidersRepository : BaseRepository<InsuranceProviders>, IInsuranceProvidersRepository
    {
        public InsuranceProvidersRepository(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }
    }
}
