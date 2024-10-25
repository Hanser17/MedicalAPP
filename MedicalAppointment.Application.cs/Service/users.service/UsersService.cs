using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Service.users.service
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ILogger<UsersService> _logger;

        public UsersService(IUsersRepository usersRepository, ILogger<UsersService> logger)
        {
            _usersRepository = usersRepository;
            _logger = logger;
        }

        public async Task<OperationResult> SaveUser(Users user)
        {
            // Add any additional business logic here if needed
            return await _usersRepository.Save(user);
        }

        public async Task<OperationResult> UpdateUser(Users user)
        {
            // Add any additional business logic here if needed
            return await _usersRepository.Update(user);
        }

        public async Task<OperationResult> RemoveUser(int userId)
        {
            var user = new Users { UserID = userId }; // Assuming UserID is the only needed info to remove
            return await _usersRepository.Remove(user);
        }

        public async Task<OperationResult> GetAllUsers()
        {
            return await _usersRepository.GetAll();
        }

        public async Task<OperationResult> GetUserById(int userId)
        {
            return await _usersRepository.GetEntityBy(userId);
        }
    }
}
