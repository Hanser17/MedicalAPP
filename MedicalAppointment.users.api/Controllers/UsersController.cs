
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.users.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;
        public UsersController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: api/<Users>
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> Get()
        {
            var result = await _userRepository.GetAll();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // GET api/<Users>/5
        [HttpGet("GetByUserID")]

        public async Task<IActionResult> Get(int id)
        {
            var result = await _userRepository.GetEntityBy(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // POST api/<Users>
        [HttpPost ("SaveUser")]
        
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

                var result = await _userRepository.Save(entity);

                if (!result.success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }


        // PUT api/<Users>/5
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Put([FromBody] Users users)
        {
            var result = await _userRepository.Update(users);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        // DELETE api/<Users>/5
        [HttpDelete("RemoveUser")]
        public async Task<IActionResult> Deleted([FromBody] Users users)
        {
            var result = await _userRepository.Remove(users);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
