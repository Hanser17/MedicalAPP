using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Imedical;


namespace MedicalAppoiments.Persistance.Repositories.medicalRepository
{

    public class SpecialtiesRepository : BaseRepository<Specialties>, ISpecialtiesRepository
    {
        public SpecialtiesRepository(MedicalAppointmentContext medicalAppointmentContext) : base(medicalAppointmentContext) { }
    }
}
