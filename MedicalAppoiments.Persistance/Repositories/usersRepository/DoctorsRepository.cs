using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
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

                var doctor = await _medicalAppointmentContext.Doctors.ToListAsync();
               operationResult.success = true;
                operationResult.Data = doctor;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos los Doctores";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;

        }

        public async Task<OperationResult> GetEntityBy(int id)
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
                var doctor = await _medicalAppointmentContext.Doctors.FindAsync(id);
                if (doctor == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El Doctor no existe.";
                    return operationResult;
                }

                operationResult.success = true;
                operationResult.Data = doctor;
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
