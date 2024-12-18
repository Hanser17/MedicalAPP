﻿

using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppoiments.Persistance.Models.appointmentsModel;
using MedicalAppointment.Application.Interfaces.IbaseService;

namespace MedicalAppointment.Application.Interfaces.IappointmentsService
{
    public interface IAppointmentsService 
    {
        Task<OperationResult> GetAllAppointmentsAsync();
        Task<OperationResult> GetAppointmentsByIdAsync(int id);
        Task<OperationResult> GetAppointmentsByPatientIDAsync(int id);
        Task<OperationResult> GetAppointmentsByDoctorIDAsync(int id);
        Task<OperationResult> GetAppointmentsByStatusIDAsync(int id);
        Task<OperationResult> SaveAppointmentsAsync(Appointments appointments);
        Task<OperationResult> UpdateAppointmentsAsync(Appointments appointments);
        Task<OperationResult> RemoveAppointmentsAsync(int AppointmentID);
    }
}
