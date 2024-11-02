
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using MedicalAppoiments.Persistance.Models.usersModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace MedicalAppoiments.Persistance.Repositories.usersRepository
{
    public class DoctorsRepository : BaseRepository<Doctors>, IDoctorsRepository
    {

        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<DoctorsRepository> _logger;

        public DoctorsRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<DoctorsRepository> logger) : base(medicalAppointmentContext) 
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }

        public async override Task<OperationResult> Save(Doctors entity)
        {
            OperationResult operationResult = new OperationResult();


            var SpecialtyExists = await _medicalAppointmentContext.Specialties.AnyAsync(s => s.SpecialtyID == entity.SpecialtyID);
            if (!SpecialtyExists)
            {
                operationResult.success = false;
                operationResult.message = "El SpecialtyID proporcionado no existe en la tabla Roles.";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.LicenseNumber) ||entity.LicenseNumber.Length >= 50)
            {
                operationResult.success = false;
                operationResult.message = "Numero de Licencia no valida, no puede ser mayor a 50 caracteres  ";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.PhoneNumber) || !System.Text.RegularExpressions.Regex.IsMatch(entity.PhoneNumber, @"^\d+$") || entity.PhoneNumber.Length != 10)
            {
                operationResult.success = false;
                operationResult.message = "Número de teléfono requerido, debe contener solo dígitos y tener exactamente 10 dígitos.";
                return operationResult;
            }

            if(entity.YearsOfExperience == null) 
            {
                operationResult.success = false;
                operationResult.message = "Numero de experiencia es requerido";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.Education))
            {
                operationResult.success = false;
                operationResult.message = "Educacion requerida.";
                return operationResult;
            }

            if (entity.LicenseExpirationDate <= DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "Licencia ya esta expirada";
                return operationResult;
            }

    
            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error guardando Datos del Doctor.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;

        }

        public async override Task<OperationResult> Update(Doctors entity)
        {
            OperationResult operationResult = new OperationResult();

            var SpecialtyExists = await _medicalAppointmentContext.Specialties.AnyAsync(s => s.SpecialtyID == entity.SpecialtyID);
            if (!SpecialtyExists)
            {
                operationResult.success = false;
                operationResult.message = "El SpecialtyID proporcionado no existe .";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.LicenseNumber) || entity.LicenseNumber.Length >= 50)
            {
                operationResult.success = false;
                operationResult.message = "Numero de Licencia no valida, no puede ser mayor a 50 caracteres  ";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.PhoneNumber) || !System.Text.RegularExpressions.Regex.IsMatch(entity.PhoneNumber, @"^\d+$") || entity.PhoneNumber.Length != 10)
            {
                operationResult.success = false;
                operationResult.message = "Número de teléfono requerido, debe contener solo dígitos y tener exactamente 10 dígitos.";
                return operationResult;
            }

            if (entity.YearsOfExperience == null)
            {
                operationResult.success = false;
                operationResult.message = "Numero de experiencia es requerido";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.Education))
            {
                operationResult.success = false;
                operationResult.message = "Educacion requerida.";
                return operationResult;
            }

            if (entity.LicenseExpirationDate <= DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "Licencia ya esta expirada";
                return operationResult;
            }
            try
            {
                Doctors doctortoUpdate = await _medicalAppointmentContext.Doctors.FindAsync(entity.DoctorID);
                if (doctortoUpdate == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El Doctor ID no existe";
                    return operationResult;
                }
                if (await base.Exists(doctor => doctor.DoctorID == entity.DoctorID))
                {
                    operationResult.success = false;
                    operationResult.message = "El Doctor ID ta esta asignanado a otro Doctor ";
                    return operationResult;
                }

                
                doctortoUpdate.SpecialtyID = entity.SpecialtyID;
                doctortoUpdate.LicenseNumber = entity.LicenseNumber;
                doctortoUpdate.YearsOfExperience = entity.YearsOfExperience;
                doctortoUpdate.PhoneNumber = entity.PhoneNumber;
                doctortoUpdate.Education = entity.Education;
                doctortoUpdate.Bio = entity.Bio;
                doctortoUpdate.ConsultationFee = entity.ConsultationFee;
                doctortoUpdate.ClinicAddress = entity.ClinicAddress;
                doctortoUpdate.AvailabilityModeId = entity.AvailabilityModeId;
                doctortoUpdate.LicenseExpirationDate = entity.LicenseExpirationDate;
                doctortoUpdate.UpdatedAt = DateTime.Now;
                doctortoUpdate.IsActive = entity.IsActive;


                operationResult = await base.Update(doctortoUpdate);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el registro.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;

        }

        public async override Task<OperationResult> Remove(Doctors entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.DoctorID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El DoctorID proporcionado no es valido";
                return operationResult;
            }
            try
            {
                Doctors DoctortoRemove = await _medicalAppointmentContext.Doctors.FindAsync(entity.DoctorID);
                if (DoctortoRemove == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El Doctor ID no existe";
                    return operationResult;
                }
                DoctortoRemove.IsActive = false;
                DoctortoRemove.UpdatedAt = DateTime.Now;

                operationResult = await base.Remove(DoctortoRemove);
            }
            catch (Exception ex)
            {

                operationResult.success = false;
                operationResult.message = "Error actualizando el registro.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;

        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                operationResult.Data = await (from d in _medicalAppointmentContext.Doctors
                                              join u in _medicalAppointmentContext.Users on d.DoctorID equals u.UserID
                                              join r in _medicalAppointmentContext.Roles on u.RoleID equals r.RoleID
                                              join s in _medicalAppointmentContext.Specialties on d.SpecialtyID equals s.SpecialtyID
                                              where d.IsActive 
                                              select new DoctorsModel
                                              {
                                                  RoleName = r.RoleName,
                                                  DoctorID = d.DoctorID,
                                                  FirstName = u.FirstName,
                                                  LastName = u.LastName,
                                                  ConsultationFee = d.ConsultationFee,
                                                  SpecialtyName = s.SpecialtyName,
                                                  IsActive = d.IsActive
                                              }). ToListAsync();
                if (operationResult.Data == null)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro de doctores.";
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
                operationResult.message = "Error obteniendo todos los Doctores";
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

                operationResult.Data = await (from d in _medicalAppointmentContext.Doctors
                                              join u in _medicalAppointmentContext.Users on d.DoctorID equals u.UserID
                                              join r in _medicalAppointmentContext.Roles on u.RoleID equals r.RoleID
                                              join s in _medicalAppointmentContext.Specialties on d.SpecialtyID equals s.SpecialtyID
                                              where d.IsActive && d.DoctorID == id
                                              select new DoctorsModel
                                              {
                                                  RoleName = r.RoleName,
                                                  DoctorID = d.DoctorID,
                                                  FirstName = u.FirstName,
                                                  LastName = u.LastName,
                                                  ConsultationFee = d.ConsultationFee,
                                                  SpecialtyName = s.SpecialtyName,
                                                  IsActive = d.IsActive
                                              }).FirstOrDefaultAsync();
                if (operationResult.Data == null)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró un doctor con el ID proporcionado.";
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
                operationResult.message = "Error al obtener el doctor.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async Task <OperationResult> GetDoctorBySpecialty(int id)
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
                operationResult.Data = await (from d in _medicalAppointmentContext.Doctors
                                              join u in _medicalAppointmentContext.Users on d.DoctorID equals u.UserID
                                              join r in _medicalAppointmentContext.Roles on u.RoleID equals r.RoleID
                                              join s in _medicalAppointmentContext.Specialties on d.SpecialtyID equals s.SpecialtyID
                                              where d.IsActive && s.SpecialtyID == id
                                              select new DoctorsModel
                                              {
                                                  RoleName = r.RoleName,
                                                  DoctorID = d.DoctorID,
                                                  FirstName = u.FirstName,
                                                  LastName = u.LastName,
                                                  ConsultationFee = d.ConsultationFee,
                                                  SpecialtyName = s.SpecialtyName,
                                                  IsActive = d.IsActive
                                              }).FirstOrDefaultAsync();
                if (operationResult.Data == null)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró un doctor con el ID proporcionado.";
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
                operationResult.message = "Error al obtener el doctor.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }


        public async Task<OperationResult> GetDoctorByAvailability(int id)
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
                operationResult.Data = await (from d in _medicalAppointmentContext.Doctors
                                              join u in _medicalAppointmentContext.Users on d.DoctorID equals u.UserID
                                              join r in _medicalAppointmentContext.Roles on u.RoleID equals r.RoleID
                                              join s in _medicalAppointmentContext.Specialties on d.SpecialtyID equals s.SpecialtyID
                                              join a in _medicalAppointmentContext.AvailabilityModes on d.AvailabilityModeId equals a.SAvailabilityModeID
                                              where d.IsActive && d.AvailabilityModeId == id
                                              select new DoctorsModel
                                              {
                                                  RoleName = r.RoleName,
                                                  DoctorID = d.DoctorID,
                                                  FirstName = u.FirstName,
                                                  LastName = u.LastName,
                                                  ConsultationFee = d.ConsultationFee,
                                                  SpecialtyName = s.SpecialtyName,
                                                  IsActive = d.IsActive
                                              }).FirstOrDefaultAsync();
                if (operationResult.Data == null)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró un doctor con el ID proporcionado.";
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
                operationResult.message = "Error al obtener el doctor.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }
    }
}
