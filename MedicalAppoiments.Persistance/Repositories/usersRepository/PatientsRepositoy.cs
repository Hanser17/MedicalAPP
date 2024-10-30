
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
    public class PatientsRepositoy : BaseRepository<Patients>, IPatientsRepository
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<PatientsRepositoy> _logger;

        public PatientsRepositoy(MedicalAppointmentContext medicalAppointmentContext, ILogger<PatientsRepositoy> logger) : base(medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }

        public async override Task<OperationResult> Save(Patients entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.DateOfBirth == null || entity.DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
            {
                operationResult.success = false;
                operationResult.message = "DateOfBirth requerido y debe ser una fecha válida en el pasado.";
                return operationResult;
            }

            if (entity.Gender != 'M' && entity.Gender != 'F')
            {
                operationResult.success = false;
                operationResult.message = "Genero no Valido";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.PhoneNumber) || !System.Text.RegularExpressions.Regex.IsMatch(entity.PhoneNumber, @"^\d+$") || entity.PhoneNumber.Length != 10)
            {
                operationResult.success = false;
                operationResult.message = "Número de teléfono requerido, debe contener solo dígitos y tener exactamente 10 dígitos.";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.Address) || entity.Address.Length > 250)
            {
                operationResult.success = false;
                operationResult.message = "Address no valida .";
                return operationResult;

            }

            if (string.IsNullOrEmpty(entity.EmergencyContactName) || entity.EmergencyContactName.Length > 250)
            {
                operationResult.success = false;
                operationResult.message = "Nombre de concacto de emergencia no valido  .";
                return operationResult;

            }
            if (string.IsNullOrEmpty(entity.EmergencyContactPhone) || !System.Text.RegularExpressions.Regex.IsMatch(entity.EmergencyContactPhone, @"^\d+$") || entity.EmergencyContactPhone.Length != 10)
            {
                operationResult.success = false;
                operationResult.message = "Número de teléfono requerido, debe contener solo dígitos y tener exactamente 10 dígitos.";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.BloodType) || entity.BloodType.Length != 2)
            {
                operationResult.success = false;
                operationResult.message = "Tipo de Sangre requerido ";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Allergies))
            {
                operationResult.success = false;
                operationResult.message = "Especifica si es usted es alergico de lo contrario escriba 'No' ";
                return operationResult;
            }
            if (entity.InsuranceProviderID == 0)
            {
                operationResult.success = false;
                operationResult.message = "Insurance ID es requertido ";
                return operationResult;
            }
            var InsuranceExist = await _medicalAppointmentContext.InsuranceProviders.AnyAsync(i => i.InsuranceProviderID == entity.InsuranceProviderID);
            if (!InsuranceExist && entity.InsuranceProviderID != 7777)
            {
                operationResult.success = false;
                operationResult.message = "Este proveedor de seguros no existe, en caso de que no este asegurado y desea pagar Out of pocket indique '7777' en esta campo ";
                return operationResult;
            }
            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error guardando Datos del paciente.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;

        }

        public async override Task<OperationResult> Update(Patients entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.DateOfBirth == null || entity.DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
            {
                operationResult.success = false;
                operationResult.message = "DateOfBirth requerido y debe ser una fecha válida en el pasado.";
                return operationResult;
            }

            if (entity.Gender != 'M' && entity.Gender != 'F')
            {
                operationResult.success = false;
                operationResult.message = "Genero no Valido";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.PhoneNumber) || !System.Text.RegularExpressions.Regex.IsMatch(entity.PhoneNumber, @"^\d+$") || entity.PhoneNumber.Length != 10)
            {
                operationResult.success = false;
                operationResult.message = "Número de teléfono requerido, debe contener solo dígitos y tener exactamente 10 dígitos.";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.Address) || entity.Address.Length > 250)
            {
                operationResult.success = false;
                operationResult.message = "Address no valida .";
                return operationResult;

            }

            if (string.IsNullOrEmpty(entity.EmergencyContactName) || entity.EmergencyContactName.Length > 250)
            {
                operationResult.success = false;
                operationResult.message = "Nombre de concacto de emergencia no valido  .";
                return operationResult;

            }
            if (string.IsNullOrEmpty(entity.EmergencyContactPhone) || !System.Text.RegularExpressions.Regex.IsMatch(entity.EmergencyContactPhone, @"^\d+$") || entity.EmergencyContactPhone.Length != 10)
            {
                operationResult.success = false;
                operationResult.message = "Número de teléfono requerido, debe contener solo dígitos y tener exactamente 10 dígitos.";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.BloodType) || entity.BloodType.Length != 2)
            {
                operationResult.success = false;
                operationResult.message = "Tipo de Sangre requerido ";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Allergies))
            {
                operationResult.success = false;
                operationResult.message = "Especifica si es usted es alergico de lo contrario escriba 'No' ";
                return operationResult;
            }
            if (entity.InsuranceProviderID == 0)
            {
                operationResult.success = false;
                operationResult.message = "Insurance ID es requertido ";
                return operationResult;
            }
            var InsuranceExist = await _medicalAppointmentContext.InsuranceProviders.AnyAsync(i => i.InsuranceProviderID == entity.InsuranceProviderID);
            if (!InsuranceExist && entity.InsuranceProviderID != 7777)
            {
                operationResult.success = false;
                operationResult.message = "Este proveedor de seguros no existe, en caso de que no este asegurado y desea pagar Out of pocket indique '7777' en esta campo ";
                return operationResult;
            }


            try
            {
                Patients patienttoUpdate = await _medicalAppointmentContext.Patients.FindAsync(entity.PatientID);
                if (patienttoUpdate == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El Patient ID no existe";
                    return operationResult;
                }
                if (await base.Exists(patient => patient.PatientID == entity.PatientID))
                {
                    operationResult.success = false;
                    operationResult.message = "El Patient ID ta esta asignanado a otro paciente ";
                    return operationResult;
                }

                patienttoUpdate.PatientID = entity.PatientID;
                patienttoUpdate.DateOfBirth = entity.DateOfBirth;
                patienttoUpdate.Gender = entity.Gender;
                patienttoUpdate.IsActive = entity.IsActive;
                patienttoUpdate.PhoneNumber = entity.PhoneNumber;
                patienttoUpdate.EmergencyContactName = entity.EmergencyContactName;
                patienttoUpdate.EmergencyContactPhone = entity.EmergencyContactPhone;
                patienttoUpdate.BloodType = entity.BloodType;
                patienttoUpdate.Allergies = entity.Allergies;
                patienttoUpdate.InsuranceProviderID = entity.InsuranceProviderID;
                patienttoUpdate.UpdatedAt = DateTime.Now;
                patienttoUpdate.IsActive = entity.IsActive;


                operationResult = await base.Update(patienttoUpdate);

            }catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el registro.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;
        }

        public async override Task<OperationResult> Remove(Patients entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity.PatientID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "El Patient ID proporcionado no es valido";
                return operationResult;
            }
            try
            {
                Patients PatienttoRemove = await _medicalAppointmentContext.Patients.FindAsync(entity.PatientID);
                if (PatienttoRemove == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El patient ID no existe";
                    return operationResult;
                }
                PatienttoRemove.IsActive = entity.IsActive;
                PatienttoRemove.UpdatedAt = DateTime.Now;

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
                operationResult.Data = await (from u in _medicalAppointmentContext.Users
                                              join r in _medicalAppointmentContext.Roles on u.RoleID equals r.RoleID
                                              join p in _medicalAppointmentContext.Patients on u.UserID equals p.UserID
                                              join i in _medicalAppointmentContext.InsuranceProviders on p.InsuranceProviderID equals i.InsuranceProviderID
                                              where r.RoleID == 3 && p.IsActive == true
                                              select new PatientsModel
                                              {
                                                RoleName = r.RoleName,
                                                PatientID = p.PatientID,
                                                FirstName = u.FirstName,
                                                LastName = u.LastName,
                                                DateOfBirth = p.DateOfBirth,
                                                IsActive = p.IsActive,
                                                InsuranceName = i.Name
                                            }).ToListAsync(); 


                    operationResult.success = true;
    
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos los Patients";
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
                operationResult.Data = await (from u in _medicalAppointmentContext.Users
                                              join r in _medicalAppointmentContext.Roles on u.RoleID equals r.RoleID
                                              join p in _medicalAppointmentContext.Patients on u.UserID equals p.UserID
                                              join i in _medicalAppointmentContext.InsuranceProviders on p.InsuranceProviderID equals i.InsuranceProviderID
                                              where r.RoleID == 3 && p.IsActive == true && p.PatientID == id
                                              select new PatientsModel
                                              {
                                                  RoleName = r.RoleName,
                                                  PatientID = p.PatientID,
                                                  FirstName = u.FirstName,
                                                  LastName = u.LastName,
                                                  DateOfBirth = p.DateOfBirth,
                                                  IsActive = p.IsActive,
                                                  InsuranceName = i.Name
                                              }).ToListAsync();


                operationResult.success = true;
                
               
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener el patient.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

    }

}
