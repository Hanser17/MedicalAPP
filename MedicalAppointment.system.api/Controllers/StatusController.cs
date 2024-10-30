using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using MedicalAppointment.Application.Interfaces.IsystemService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.system.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        // GET: api/<StatusController>
        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> Get()
        {
            var result = await _statusService.GetAllStatus();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

            // GET api/<StatusController>/5
            [HttpGet("GetByIdStatus")]

            public async Task<IActionResult> Get(int id)
            {
                var result = await _statusService.GetStatusByID(id);
                if (!result.success)
                {
                    return BadRequest(result.message);
                }
                return Ok(result.Data);
            }

            // POST api/<StatusController>
            [HttpPost ("SaveStatus")]
            public async Task<IActionResult> Save([FromBody] Status entity)
            {
                if (entity == null)
                {
                    return BadRequest(new OperationResult
                    {
                        success = false,
                        message = "La entidad es requerida."
                    });
                }

                var result = await _statusService.SaveStatusAsync(entity);

                if (!result.success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }

            // PUT api/<StatusController>/5
            [HttpPut("UpdateStatus")]
            public async Task<IActionResult> Put(  [FromBody] Status status)
            {
                var result = await _statusService.UpdateStatusAsync(status);

                if (!result.success)
                {
                    return BadRequest(result);
                }
                return Ok(result);

            }

            // DELETE api/<StatusController>/5
            [HttpDelete("RemoveStatus")]
            public async Task<IActionResult> Deleted([FromBody] Status status)
            {
                var result = await _statusService.RemoveStatusAsync(status);

                if (!result.success)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }

        }
    } 


