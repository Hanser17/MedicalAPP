using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Imedical;
using MedicalAppoiments.Persistance.Repositories.medicalRepository;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Application.Service.medical.Service
{
    public class MedicalRecordsService : IMedicalRecordsService
        
    {
        private readonly IMedicalRecordsRepository _medicalRecordsRepository;
        private readonly ILogger<MedicalRecordsService> _logger;
        
        public MedicalRecordsService(IMedicalRecordsRepository medicalRecordsRepository, ILogger<MedicalRecordsService> logger)
        {
            _medicalRecordsRepository = medicalRecordsRepository;
            _logger = logger;
        }

        public async Task<OperationResult> DeleteMedicalRecordsAsync(MedicalRecords medicalRecords)
        {
            return await _medicalRecordsRepository.Remove(medicalRecords);
        }

        public async Task<OperationResult> GetAllMedicalRecordsAsync()
        {
            return await _medicalRecordsRepository.GetAll();
        }

        public async Task<OperationResult> GetByIDMedicalRecordsAsync(int id)
        {
            return await _medicalRecordsRepository.GetEntityBy(id);
        }

        public async Task<OperationResult> SaveMedicalRecordsAsync(MedicalRecords medicalRecords)
        {
            return await _medicalRecordsRepository.Save(medicalRecords);
        }

        public async  Task<OperationResult> UpdateMedicalRecordsAsync(MedicalRecords medicalRecords)
        {
            return await _medicalRecordsRepository.Update(medicalRecords);
        }
    }
}
