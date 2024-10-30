using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using MedicalAppointment.Application.Interfaces.IsystemService;
using Microsoft.Extensions.Logging;


namespace MedicalAppointment.Application.Service.system.Service
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepositoty _statusService;
        private readonly ILogger<StatusService> _logger;

        public StatusService(IStatusRepositoty statusRepository, ILogger<StatusService> logger)
        {
            _statusService = statusRepository;
            _logger = logger;
        }

        public async Task<OperationResult> GetAllStatus()
        {
            return await _statusService.GetAll();
        }

        public async Task<OperationResult> GetStatusByID(int id)
        {
            return await _statusService.GetEntityBy(id);
        }

        public async Task<OperationResult> RemoveStatusAsync(Status status)
        {
            return await _statusService.Remove(status);
        }

        public async Task<OperationResult> SaveStatusAsync(Status status)
        {
            return await _statusService.Save(status);
        }

        public async Task<OperationResult> UpdateStatusAsync(Status status)
        {
            return await _statusService.Update(status);
        }
    }
}
