using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iappointments;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Repositories.appointmentsRepository
{
    public class AppointmentsRepository : BaseRepository<Appointments>, IAppointmentsRepository
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<AppointmentsRepository> _logger;

        public AppointmentsRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<AppointmentsRepository> logger)
            : base(medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }

        public async override Task<OperationResult> Save(Appointments entity)
        {
            OperationResult operationResult = new OperationResult();

          ////  if (entity == null)
           // {
              //  operationResult.success = false;
              //  operationResult.message = "La entidad es requerida.";
              //  return operationResult;
           // }

           // if (entity.AppointmentID <= 0)
           // {
            //    operationResult.success = false;
            //    operationResult.message = "El AppointmentID no puede ser nulo ni menor o igual a cero.";
            //    return operationResult;
           // }

            if (entity.PatientID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID del paciente no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }

            if (entity.DoctorID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID del Doctor no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }

            if (entity.AppointmentDate < DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "La fecha de la cita no puede ser en el pasado.";
                return operationResult;
            }

            if (entity.StatusID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID del Status no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }

            if (await base.Exists(appointment => appointment.AppointmentID == entity.AppointmentID
                                                  && appointment.AppointmentDate == entity.AppointmentDate))
            {
                operationResult.success = false;
                operationResult.message = "La cita ya está registrada.";
                return operationResult;
            }

            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error guardando la cita.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async override Task<OperationResult> Update(Appointments entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.success = false;
                operationResult.message = "La entidad es requerida.";
                return operationResult;
            }

            if (entity.AppointmentID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El AppointmentID no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }

            if (entity.PatientID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID del paciente no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }

            if (entity.DoctorID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID del Doctor no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }

            if (entity.AppointmentDate < DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "La fecha de la cita no puede ser en el pasado.";
                return operationResult;
            }

            if (entity.StatusID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID del Status no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }

            try
            {
                Appointments appointmenttoUpdate = await _medicalAppointmentContext.Appointments.FindAsync(entity.AppointmentID);

                
                if (appointmenttoUpdate == null)
                {
                    operationResult.success = false;
                    operationResult.message = "La cita no existe, no se puede actualizar.";
                    return operationResult; // Salir si no existe
                }

                    appointmenttoUpdate.AppointmentID =entity.AppointmentID;
                    appointmenttoUpdate.PatientID = entity.PatientID;
                    appointmenttoUpdate.DoctorID = entity.DoctorID;
                    appointmenttoUpdate.AppointmentDate = entity.AppointmentDate;
                    appointmenttoUpdate.StatusID = entity.StatusID;
                    appointmenttoUpdate.CreatedAt = entity.CreatedAt;
                    appointmenttoUpdate.UpdatedAt = entity.UpdatedAt;

                operationResult = await base.Update(appointmenttoUpdate);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el asiento.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;

        }

        public async override Task<OperationResult> Remove(Appointments entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.success = false;
                operationResult.message = "La entidad es requerida.";
                return operationResult;
            }

            if (entity.AppointmentID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere el ID de la cita para realizar esta operación.";
                return operationResult;
            }
            try
            {
                Appointments appointmentToRemove = await _medicalAppointmentContext.Appointments.FindAsync(entity.AppointmentID);
                appointmentToRemove.StatusID = entity.StatusID;
                appointmentToRemove.UpdatedAt = entity.UpdatedAt;
                

                await base.Update(appointmentToRemove);

            }
            catch (Exception ex)
            {

                operationResult.success = false;
                operationResult.message = "Error desactivando el asiento.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;
        }

    }
}

