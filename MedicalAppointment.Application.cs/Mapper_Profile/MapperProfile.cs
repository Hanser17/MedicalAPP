

using AutoMapper;
using Azure.Identity;
using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppoiments.Persistance.Models.appointmentsModel;
using MedicalAppoiments.Persistance.Models.DoctorAvailivilityModel;

namespace MedicalAppointment.Application.Mapper_Profile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AppointmentsModel, AppointmentUpdateDTO>();
            CreateMap<AppointmentUpdateDTO, Appointments>();
            CreateMap< AppointmentSaveDTO, Appointments> ();

            CreateMap<DoctorAvailibilitySaveDTO, DoctorAvailability>();
            CreateMap<DoctorAvailability, DoctorAvailibilityUpdateDTO>();
            CreateMap<DoctorAvailibilityUpdateDTO, DoctorAvailability>();

        }
    }
}
