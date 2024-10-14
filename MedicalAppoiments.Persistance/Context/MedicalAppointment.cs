

using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Entities.users;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppoiments.Persistance.Context
{
    public partial class MedicalAppointmentContext : DbContext
    {
        public MedicalAppointmentContext(DbContextOptions<MedicalAppointmentContext> options) : base(options)
        {
            
        }
        #region appointments entities
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailability { get; set; }
        #endregion

        #region insurance entities
        public DbSet<InsuranceProviders> InsuranceProviders { get; set; }

        public DbSet<NetworkType> NetworkTypes { get; set; }
        #endregion

        #region medical entities

        public DbSet<AvailabilityModes> AvailabilityModes { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public DbSet<Specialties> Specialties { get; set; }

        #endregion

        #region system entities
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Status> Status { get; set; }
        #endregion

        #region users entities
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<users> Users { get; set; }
        #endregion
    }
}
