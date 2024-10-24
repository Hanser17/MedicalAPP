using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Imedical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace MedicalAppoiments.Persistance.Repositories.medicalRepository
{

    public class MedicalRecordsRepository : BaseRepository<MedicalRecords>, IMedicalRecordsRepository
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<MedicalRecordsRepository> _logger;
        public MedicalRecordsRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<MedicalRecordsRepository> logger)
           : base(medicalAppointmentContext)
        {
            medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }
        public async override Task<OperationResult> Save(MedicalRecords entity)
        {
            var operationResult = new OperationResult();

            if (entity.PatientID == null)
            {
                operationResult.success = false;
                operationResult.message = "El Patient ID no valido";
                return operationResult;
            }
            if (entity.DoctorID == null)
            {
                operationResult.success = false;
                operationResult.message = "El Doctor ID no valido";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Diagnosis))
            {
                operationResult.success = false;
                operationResult.message = "Diagnostico No valido";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Treatment))
            {
                operationResult.success = false;
                operationResult.message = "Tratamineto requerido";
                return operationResult;
            }
            if (entity.DateOfVisit > DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "Fecha de visita no puede ser en el futuro.";
                return operationResult;
            }
            try
            {
                operationResult = await base.Save(entity);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error guardando Los Mecical records ";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }



        public async override Task<OperationResult> Update(MedicalRecords entity)
        {
            var operationResult = new OperationResult();

            if (entity.PatientID == null)
            {
                operationResult.success = false;
                operationResult.message = "El Patient ID no valido";
                return operationResult;
            }
            if (entity.DoctorID == null)
            {
                operationResult.success = false;
                operationResult.message = "El Doctor ID no valido";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Diagnosis))
            {
                operationResult.success = false;
                operationResult.message = "Diagnostico No valido";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Treatment))
            {
                operationResult.success = false;
                operationResult.message = "Tratamineto requerido";
                return operationResult;
            }
            if (entity.DateOfVisit > DateTime.Now)
            {
                operationResult.success = false;
                operationResult.message = "Fecha de visita no puede ser en el futuro.";
                return operationResult;
            }
            try
            {

                MedicalRecords medicalrecorsToUpdate = await _medicalAppointmentContext.MedicalRecords.FindAsync(entity.RecordID);

                medicalrecorsToUpdate.PatientID = entity.PatientID;
                medicalrecorsToUpdate.DoctorID = entity.DoctorID;
                medicalrecorsToUpdate.Diagnosis = entity.Diagnosis;
                medicalrecorsToUpdate.Treatment = entity.Treatment;
                medicalrecorsToUpdate.DateOfVisit = entity.DateOfVisit;
                medicalrecorsToUpdate.UpdatedAt = DateTime.Now;


                operationResult = await base.Update(medicalrecorsToUpdate);

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error Actualizando los Mecical records ";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async Task<OperationResult> GetAll()
        {

            var operationResult = new OperationResult();

            try
            {
                var medicalrecords = await _medicalAppointmentContext.MedicalRecords.ToListAsync();
                operationResult.success = true;
                operationResult.Data = medicalrecords;

            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener los Medical Records.";
                _logger.LogError(operationResult.message, ex);

            }
            return operationResult;
        }

        public async Task<OperationResult> GetEntityBy(int id)
        {
            var operationResult = new OperationResult();

            if (id <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere un ID válido para realizar esta operación.";
                return operationResult;
            }

            try
            {
                var medicalrecords = await _medicalAppointmentContext.MedicalRecords.FindAsync(id);
                if (medicalrecords == null)
                {
                    operationResult.success = false;
                    operationResult.message = "La Notificacion no existe.";
                    return operationResult;
                }

                operationResult.success = true;
                operationResult.Data = medicalrecords;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener la notificacion .";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

    }

}
