

using AutoMapper;
using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppoiments.Persistance.Models.appointmentsModel;
using MedicalAppoiments.Persistance.Models.DoctorAvailivilityModel;
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

        }
    }
}
