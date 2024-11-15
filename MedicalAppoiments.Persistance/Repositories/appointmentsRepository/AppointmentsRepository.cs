using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iappointments;
using MedicalAppoiments.Persistance.Models.appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Numerics;

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


            if (entity.PatientID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID del paciente no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }

            Patients patientExists = await _medicalAppointmentContext.Patients.FindAsync(entity.PatientID);
            if (patientExists == null)
            {
                operationResult.success = false;
                operationResult.message = "el paciente no existe ";
                return operationResult;
            }

            if (entity.DoctorID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID del Doctor no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }
            Doctors doctorsExist = await _medicalAppointmentContext.Doctors.FindAsync(entity.DoctorID);
            if (doctorsExist == null)
            {
                operationResult.success = false;
                operationResult.message = "el doctor no existe ";
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
            Status statusExist = await _medicalAppointmentContext.Status.FindAsync(entity.StatusID);
            if (doctorsExist == null)
            {
                operationResult.success = false;
                operationResult.message = "el estado no existe ";
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
            if (entity.PatientID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID del paciente no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }
            Patients patientExists = await _medicalAppointmentContext.Patients.FindAsync(entity.PatientID);
            if (patientExists == null)
            {
                operationResult.success = false;
                operationResult.message = "el paciente no existe ";
                return operationResult;
            }

            if (entity.DoctorID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El ID del Doctor no puede ser nulo ni menor o igual a cero.";
                return operationResult;
            }
            Doctors doctorsExist = await _medicalAppointmentContext.Doctors.FindAsync(entity.DoctorID);
            if (doctorsExist == null)
            {
                operationResult.success = false;
                operationResult.message = "el doctor no existe ";
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
                    return operationResult;
                }

                appointmenttoUpdate.PatientID = entity.PatientID;
                appointmenttoUpdate.DoctorID = entity.DoctorID;
                appointmenttoUpdate.AppointmentDate = entity.AppointmentDate;
                appointmenttoUpdate.StatusID = entity.StatusID;
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
                appointmentToRemove.StatusID = 2 ;
                appointmentToRemove.UpdatedAt = DateTime.Now;


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

        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {

                operationResult.Data = await (from a in _medicalAppointmentContext.Appointments
                                              join d in _medicalAppointmentContext.Doctors on a.DoctorID equals d.DoctorID
                                              join ud in _medicalAppointmentContext.Users on d.DoctorID equals ud.UserID
                                              join p in _medicalAppointmentContext.Patients on a.PatientID equals p.PatientID
                                              join up in _medicalAppointmentContext.Users on p.PatientID equals up.UserID
                                              join s in _medicalAppointmentContext.Status on a.StatusID equals s.StatusID
                                              orderby a.CreatedAt descending
                                             
                                              select new AppointmentsModel

                                              {
                                                  AppointmentID = a.AppointmentID,
                                                  DoctorID = d.DoctorID,
                                                  DoctorFirstName = ud.FirstName,
                                                  DoctorLastName = ud.LastName,
                                                  PatientID = p.PatientID,
                                                  PatientFirstName = up.FirstName,
                                                  PatientLastName = up.LastName,
                                                  StatusID = s.StatusID,
                                                  StatusName = s.StatusName,
                                                  AppointmentDate = a.AppointmentDate,
                                                  CreatedAt = a.CreatedAt,
                                                  UpdatedAt = a.UpdatedAt
                                              }).ToListAsync();
                if (operationResult.Data.Count == 0)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro de citas ";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la citas";
                _logger.LogError(operationResult.message, ex);
            }
            return operationResult;

        } 

        public async override Task<OperationResult> GetEntityBy(int id)
        {
            OperationResult operationResult = new OperationResult();

            if (id <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere un ID válido para realizar esta operación.";
                return operationResult;
            }

            try
            {
              
                operationResult.Data = await (from a in _medicalAppointmentContext.Appointments
                                        join d in _medicalAppointmentContext.Doctors on a.DoctorID equals d.DoctorID
                                        join ud in _medicalAppointmentContext.Users on d.DoctorID equals ud.UserID
                                        join p in _medicalAppointmentContext.Patients on a.PatientID equals p.PatientID
                                        join up in _medicalAppointmentContext.Users on p.PatientID equals up.UserID
                                        join s in _medicalAppointmentContext.Status on a.StatusID equals s.StatusID
                                        where a.AppointmentID == id
                                        select new AppointmentsModel

                                        {
                                            AppointmentID = a.AppointmentID,
                                            DoctorID = d.DoctorID,
                                            DoctorFirstName = ud.FirstName,
                                            DoctorLastName = ud.LastName,
                                            PatientID = p.PatientID,
                                            PatientFirstName = up.FirstName,
                                            PatientLastName = up.LastName,
                                            StatusID = s.StatusID,
                                            StatusName = s.StatusName,
                                            AppointmentDate = a.AppointmentDate,
                                            CreatedAt = a.CreatedAt,
                                            UpdatedAt = a.UpdatedAt
                                        }).FirstOrDefaultAsync();
                if (operationResult.Data == null)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro de cita con el ID proporcionado.";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la citas";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async Task<OperationResult> GetAppointmentsByPatientID(int id)
        {
            OperationResult operationResult = new OperationResult();

            if (id <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere un ID válido para realizar esta operación.";
                return operationResult;
            }

            try
            {
               
                operationResult.Data = await  (from a in _medicalAppointmentContext.Appointments
                                        join d in _medicalAppointmentContext.Doctors on a.DoctorID equals d.DoctorID
                                        join ud in _medicalAppointmentContext.Users on d.DoctorID equals ud.UserID
                                        join p in _medicalAppointmentContext.Patients on a.PatientID equals p.PatientID
                                        join up in _medicalAppointmentContext.Users on p.PatientID equals up.UserID
                                        join s in _medicalAppointmentContext.Status on a.StatusID equals s.StatusID
                                        where a.PatientID == id
                                        select new AppointmentsModel

                                        {
                                            AppointmentID = a.AppointmentID,
                                            DoctorID = d.DoctorID,
                                            DoctorFirstName = ud.FirstName,
                                            DoctorLastName = ud.LastName,
                                            PatientID = p.PatientID,
                                            PatientFirstName = up.FirstName,
                                            StatusID = s.StatusID,
                                            PatientLastName = up.LastName,
                                            StatusName = s.StatusName,
                                            AppointmentDate = a.AppointmentDate,
                                            CreatedAt = a.CreatedAt,
                                            UpdatedAt = a.UpdatedAt
                                        }).ToListAsync();
                if (operationResult.Data.Count == 0)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro de cita con el ID proporcionado.";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la citas";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async Task<OperationResult> GetAppointmentsByDoctorID(int id)
        {
            OperationResult operationResult = new OperationResult();

            if (id <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere un ID válido para realizar esta operación.";
                return operationResult;
            }

            try
            {
                
                operationResult.Data  = await (from a in _medicalAppointmentContext.Appointments
                                        join d in _medicalAppointmentContext.Doctors on a.DoctorID equals d.DoctorID
                                        join ud in _medicalAppointmentContext.Users on d.DoctorID equals ud.UserID
                                        join p in _medicalAppointmentContext.Patients on a.PatientID equals p.PatientID
                                        join up in _medicalAppointmentContext.Users on p.PatientID equals up.UserID
                                        join s in _medicalAppointmentContext.Status on a.StatusID equals s.StatusID
                                        where a.DoctorID == id
                                        select new AppointmentsModel

                                        {
                                            AppointmentID = a.AppointmentID,
                                            DoctorID = d.DoctorID,
                                            DoctorFirstName = ud.FirstName,
                                            DoctorLastName = ud.LastName,
                                            PatientID = p.PatientID,
                                            PatientFirstName = up.FirstName,
                                            PatientLastName = up.LastName,
                                            StatusID = s.StatusID,
                                            StatusName = s.StatusName,
                                            AppointmentDate = a.AppointmentDate,
                                            CreatedAt = a.CreatedAt,
                                            UpdatedAt = a.UpdatedAt
                                        }).ToListAsync();
                if (operationResult.Data.Count == 0)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro de cita con el ID proporcionado.";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la citas";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async Task<OperationResult> GetAppointmentsByStatusID(int id)
        {
            OperationResult operationResult = new OperationResult();

            if (id <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere un ID válido para realizar esta operación.";
                return operationResult;
            }

            try
            {
               
                operationResult.Data = await (from a in _medicalAppointmentContext.Appointments
                                        join d in _medicalAppointmentContext.Doctors on a.DoctorID equals d.DoctorID
                                        join ud in _medicalAppointmentContext.Users on d.DoctorID equals ud.UserID
                                        join p in _medicalAppointmentContext.Patients on a.PatientID equals p.PatientID
                                        join up in _medicalAppointmentContext.Users on p.PatientID equals up.UserID
                                        join s in _medicalAppointmentContext.Status on a.StatusID equals s.StatusID
                                        where a.StatusID == id
                                        select new AppointmentsModel

                                        {
                                            AppointmentID = a.AppointmentID,
                                            DoctorID = d.DoctorID,
                                            DoctorFirstName = ud.FirstName,
                                            DoctorLastName = ud.LastName,
                                            PatientID = p.PatientID,
                                            PatientFirstName = up.FirstName,
                                            PatientLastName = up.LastName,
                                            StatusID = s.StatusID,
                                            StatusName = s.StatusName,
                                            AppointmentDate = a.AppointmentDate,
                                            CreatedAt = a.CreatedAt,
                                            UpdatedAt = a.UpdatedAt
                                        }).ToListAsync();
                if (operationResult.Data.Count == 0)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro de cita con el ID proporcionado.";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la citas";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }
    }
}

