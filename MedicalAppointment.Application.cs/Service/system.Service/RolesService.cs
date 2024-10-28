

using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using MedicalAppointment.Application.Interfaces.IsystemService;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Service.system.Service
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesService;
        private readonly ILogger<RolesService> _logger;

        public RolesService(IRolesRepository rolesRepository, ILogger<RolesService> logger)
        {
            _rolesService = rolesRepository;
            _logger = logger;
        }

        public async Task<OperationResult> GetAllRoles()
        {
            return await _rolesService.GetAll();
        }

        public async Task<OperationResult> GetRolesByID(int id)
        {
            return await _rolesService.GetEntityBy(id);
        }

        public async Task<OperationResult> RemoveRolesAsync(Roles roles)
        {
            return await _rolesService.Remove(roles);
        }

        public async Task<OperationResult> SaveRolesAsync(Roles roles)
        {
            return await _rolesService.Save(roles);
        }

        public async Task<OperationResult> UpdateRolesAsync(Roles roles)
        {
            return await _rolesService.Update(roles);
        }
    }
}
