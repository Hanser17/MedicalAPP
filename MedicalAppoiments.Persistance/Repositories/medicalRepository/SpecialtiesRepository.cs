using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Imedical;
using MedicalAppoiments.Persistance.Repositories.systemRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;


namespace MedicalAppoiments.Persistance.Repositories.medicalRepository
{

    public class SpecialtiesRepository : BaseRepository<Specialties>, ISpecialtiesRepository
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<SpecialtiesRepository> _logger;
        public SpecialtiesRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<SpecialtiesRepository> logger)
           : base(medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }

        public async override Task<OperationResult> Save(Specialties entity)
        {
            var operationResult = new OperationResult();

          
            if (string.IsNullOrEmpty(entity.SpecialtyName))
            {
                operationResult.success = false;
                operationResult.message = "Nombre de especialidad no válido.";
                return operationResult;
            }

            var specialtyExists = await _medicalAppointmentContext.Specialties
                .AnyAsync(s => s.SpecialtyName.Equals(entity.SpecialtyName, StringComparison.OrdinalIgnoreCase));

            if (specialtyExists)
            {
                operationResult.success = false;
                operationResult.message = "La especialidad ya está registrada.";
                return operationResult;
            }

            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error guardando la especialidad.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }



        public async override Task<OperationResult> Update(Specialties entity)
        {
            var operationResult = new OperationResult();

            if (entity.SpecialtyID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "SpecialtyID no es válido.";
                return operationResult;
            }

            if (!await _medicalAppointmentContext.Specialties.AnyAsync(s => s.SpecialtyID == entity.SpecialtyID))
            {
                operationResult.success = false;
                operationResult.message = "El SpecialtyID proporcionado no existe.";
                return operationResult;
            }

      
            if (string.IsNullOrEmpty(entity.SpecialtyName))
            {
                operationResult.success = false;
                operationResult.message = "Nombre de especialidad no es válido.";
                return operationResult;
            }

            try
            {
                var specialtiesToUpdate = await _medicalAppointmentContext.Specialties.FindAsync(entity.SpecialtyID);

              
                if (specialtiesToUpdate == null)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró la especialidad.";
                    return operationResult;
                }

                
                specialtiesToUpdate.SpecialtyName = entity.SpecialtyName;
                specialtiesToUpdate.UpdatedAt = DateTime.Now;
                specialtiesToUpdate.IsActive = entity.IsActive;

                await _medicalAppointmentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando la especialidad.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async override Task<OperationResult> Remove(Specialties entity)
        {
            var operationResult = new OperationResult();

          
            if (entity.SpecialtyID <= 0)
            {
                operationResult.success = false;
                operationResult.message = "SpecialtyID no es válido.";
                return operationResult;
            }

          
            if (!await _medicalAppointmentContext.Specialties.AnyAsync(s => s.SpecialtyID == entity.SpecialtyID))
            {
                operationResult.success = false;
                operationResult.message = "El SpecialtyID proporcionado no existe.";
                return operationResult;
            }

           
            try
            {
                var specialtyToRemove = await _medicalAppointmentContext.Specialties.FindAsync(entity.SpecialtyID);

                if (specialtyToRemove == null)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró la especialidad.";
                    return operationResult;
                }

               
                specialtyToRemove.UpdatedAt = DateTime.Now;
                specialtyToRemove.IsActive = false;

                await _medicalAppointmentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error Borrando la especialidad.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async override Task<OperationResult> GetAll()
        {
            var operationResult = new OperationResult();

            try
            {

                var specialties = await _medicalAppointmentContext.Specialties.ToListAsync();
                operationResult.success = true;
                operationResult.Data = specialties;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos las especialidades";
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
                short speciality = Convert.ToInt16(id);

                var specialty = await _medicalAppointmentContext.Specialties.FindAsync(speciality);

                if (specialty == null)
                {
                    operationResult.success = false;
                    operationResult.message = "La especialidad no existe.";
                    return operationResult;
                }

                operationResult.success = true;
                operationResult.Data = specialty;
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error al obtener la especialidad.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

    }
}
