using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using MedicalAppoiments.Persistance.Repositories.usersRepository;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Service.users.service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientsRepository _patientsRepository;
        private readonly ILogger<PatientService> _logger;

        public PatientService(IPatientsRepository patientRepository, ILogger<PatientService> logger)
        {
            _patientsRepository = patientRepository;
            _logger = logger;
        }

        public async Task<OperationResult> GetAllPatients()
        {
            return await _patientsRepository.GetAll();
        }

        public async Task<OperationResult> GetPatientById(int id)
        {
            return await _patientsRepository.GetEntityBy(id);
        }

        public async Task<OperationResult> GetPatientsByInsuranceProviderAsync(int id)
        {
            return await _patientsRepository.GetPatientsByInsuranceProvider(id);
        }

        public async Task<OperationResult> SavePatientAsync(Patients patient)
        {
            return await _patientsRepository.Save(patient);
        }

        public async Task<OperationResult> UpdatePatientAsync(Patients patient)
        {
            return await _patientsRepository.Update(patient);
        }
        public async Task<OperationResult> RemovePatientAsync(int PatientID)
        {
            var patient = new Patients { PatientID = PatientID };
            return await _patientsRepository.Remove(patient);
        }
    }
}

