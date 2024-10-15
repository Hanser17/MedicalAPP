using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iinsurance;

namespace MedicalAppoiments.Persistance.Repositories.insuranceRepository
{
    internal class NetworkTypeRepository : BaseRepository<NetworkType>, INetworkTypeRepository

    {
        public NetworkTypeRepository(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }
    }
}
