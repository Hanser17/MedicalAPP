using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Imedical;


namespace MedicalAppoiments.Persistance.Repositories.medicalRepository
{

    public class MedicalRecordsRepository : BaseRepository<MedicalRecords>, IMedicalRecordsRepository
    {
        public MedicalRecordsRepository(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }
    }

}
