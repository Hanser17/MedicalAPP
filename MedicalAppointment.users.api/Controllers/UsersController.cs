
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.users.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllUsers();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpGet("GetByUserID")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetUserById(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpPost("SaveUser")]
        public async Task<IActionResult> Save([FromBody] Users entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _userService.SaveUser(entity);
            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Put([FromBody] Users users)
        {
            var result = await _userService.UpdateUser(users);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("RemoveUser")]
        public async Task<IActionResult> Deleted(int id)
        {
            var result = await _userService.RemoveUser(id);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}