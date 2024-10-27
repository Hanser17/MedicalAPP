using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppointment.Application.Interfaces.IsystemService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace MedicalAppointment.system.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsService _notificationsService;

        public NotificationsController(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        [HttpGet("GetAllNotifications")]
        public async Task<IActionResult> Get()
        {
            var result = await _notificationsService.GetAllNotificationsAsync();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpGet("GetByIdNotifications/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _notificationsService.GetNotificationByIdAsync(id);
            if (!result.success)
            {
                return NotFound(result.message);
            }
            return Ok(result.Data);
        }

        [HttpPost("SaveNotifications")]
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

            var result = await _notificationsService.SaveNotificationAsync(entity);
            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("UpdateNotifications")]
        public async Task<IActionResult> Put([FromBody] Notifications notification)
        {
            var result = await _notificationsService.UpdateNotificationAsync(notification);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("RemoveNotifications")]
        public async Task<IActionResult> Delete([FromBody] Notifications notification)
        {
            var result = await _notificationsService.RemoveNotificationAsync(notification);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

       
    }
}

