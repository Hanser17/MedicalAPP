

using AutoMapper;
using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppoiments.Persistance.Models.appointmentsModel;
using MedicalAppoiments.Persistance.Models.DoctorAvailivilityModel;
using MedicalAppoiments.Persistance.Models.insuranseModel;
using MedicalAppoiments.Persistance.Models.MedicalModel.Availability;
using MedicalAppoiments.Persistance.Models.MedicalModel.MedicalRecorsd;
using MedicalAppoiments.Persistance.Models.MedicalModel.Specialties;
using MedicalAppoiments.Persistance.Models.NetWorkTypeModel;
using MedicalAppoiments.Persistance.Models.SystemModel.Notifications;
using MedicalAppoiments.Persistance.Models.SystemModel.Roles;
using MedicalAppoiments.Persistance.Models.SystemModel.Status;
using MedicalAppoiments.Persistance.Models.usersModel;

namespace MedicalAppointment.Application.Mapper_Profile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region appointment
            CreateMap<AppointmentsModel, AppointmentUpdateDTO>();
            CreateMap<AppointmentUpdateDTO, Appointments>();
            CreateMap< AppointmentSaveDTO, Appointments> ();
            #endregion

            #region DoctorAvailibility

            CreateMap<DoctorAvailibilitySaveDTO, DoctorAvailability>();
            CreateMap<DoctorAvailability, DoctorAvailibilityUpdateDTO>();
            CreateMap<DoctorAvailibilityUpdateDTO, DoctorAvailability>();
            #endregion

            # region users
            CreateMap<UserModel, UserUpdateDTO>();
            CreateMap<UserUpdateDTO, Users>();
            CreateMap<UserSaveDTO, Users>();

            #endregion

            #region Doctors
            CreateMap <DoctorsModel, DoctorUpdateDTO>();
            CreateMap <DoctorUpdateDTO, Doctors>();
            CreateMap <DoctorsSaveDTO, Doctors>();

            #endregion

            #region Patient
            CreateMap <PatientsModel,  PatientUpdateDTO>();
            CreateMap <PatientUpdateDTO, Patients>();
            CreateMap <PatientSaveDTO, Patients>();
            #endregion

            #region InsuranceProviders
             CreateMap <InsuranceProvidersModel, InsuranceProvidersUpdateDTO > ();
             CreateMap<InsuranceProvidersUpdateDTO, InsuranceProviders>();
             CreateMap<InsuranceProvidersSaveDTO, InsuranceProviders>();
            #endregion

            #region NetworkType
            CreateMap<NetworkTypeAllDTO, NetworkTypeUpdateDTO>();
            CreateMap<NetworkTypeUpdateDTO, NetworkType>();
            CreateMap<NetWorkTypeSaveDTO, NetworkType>();
            #endregion


            #region Notification
            CreateMap<Notifications, NotificationUpdateDTO>();
            CreateMap<NotificationUpdateDTO, Notifications>();
            CreateMap<NotificationSaveDTO, Notifications>();
            #endregion


            #region Roles
            CreateMap<RolesModelDTO, RolesUpdateDTO>();
            CreateMap<RolesUpdateDTO, Roles>();
            CreateMap<RolesSaveDto, Roles>();
            #endregion


            #region Status
            CreateMap<StatusModelDTO, StatusUpdateDTO>();
            CreateMap<StatusUpdateDTO, Status>();
            CreateMap<StatusSaveDTO, Status>();
            #endregion


            #region Availability
            CreateMap<AvailabilityBaseDTO, AvailabilityUdapteDTO>();
            CreateMap<AvailabilityUdapteDTO, AvailabilityModes>();
            CreateMap<AvailabilitySaveDTO, AvailabilityModes>();
            #endregion


            #region MedicalRecorsd
            CreateMap<MedicalRecorsdBaseDTO, MedicalRecorsdUdapteDTO>();
            CreateMap<MedicalRecorsdUdapteDTO, MedicalRecords>();
            CreateMap<MedicalRecorsdSaveDTO, MedicalRecords>();
            #endregion

            #region Specialties
            CreateMap<SpecialtiesBaseDTO, SpecialtiesUdapteDTO>();
            CreateMap<SpecialtiesUdapteDTO, Specialties>();
            CreateMap<SpecialtiesSaveDTO, Specialties>();
            #endregion


        }
    }
}


