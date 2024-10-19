using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using MedicalAppoiments.Persistance.Repositories.systemRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.system.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsRepository _notificationsRepository;

        public NotificationsController(INotificationsRepository notificationsRepository)
        {
            _notificationsRepository = notificationsRepository;
        }

        // GET: api/<NotificationsController>
        [HttpGet("GetAllNotifications")]
        public async Task<IActionResult> Get()
        {
            var result = await _notificationsRepository.GetAll();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // GET api/<NotificationsController>/5
        [HttpGet("GetByIdNotifications")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _notificationsRepository.GetEntityBy(id);
            if (!result.success)
            {
                return NotFound(result.message);
            }
            return Ok(result.Data);
        }

        // POST api/<NotificationsController>
        [HttpPost("SaveRoles")]
        public async Task<IActionResult> Save([FromBody] Notifications entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _notificationsRepository.Save(entity);

            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<NotificationsController>/5
        [HttpPut("UpdateRoles")]
        public async Task<IActionResult> Put([FromBody] Notifications roles)
        {
            var result = await _notificationsRepository.Update(roles);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        // DELETE api/<NotificationsController>/5
        [HttpDelete("RemoveRole")]
        public async Task<IActionResult> Deleted([FromBody] Notifications roles)
        {
            var result = await _notificationsRepository.Remove(roles);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
