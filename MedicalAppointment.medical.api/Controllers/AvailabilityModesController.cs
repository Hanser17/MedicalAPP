using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.medical.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityModesController : ControllerBase
    {
        private readonly IAvailabilityModesService _availabilityModesService;

        public AvailabilityModesController ( IAvailabilityModesService availabilityModesService)
        {
            _availabilityModesService = availabilityModesService;
        }
        // GET: api/<AvailabilityModesController>
        [HttpGet("GetAllAvailabilityModes")]
        public async Task<IActionResult> Get()
        {
            var result = await _availabilityModesService.GetAllAvailabilityModesAsync();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // GET api/<AvailabilityModesController>/5
        [HttpGet("GetByIdAllAvailabilityModes/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _availabilityModesService.GetByIDAvailabilityModesAsync(id);
            if (!result.success)
            {
                return NotFound(result.message);
            }
            return Ok(result.Data);
        }

        // POST api/<AvailabilityModesController>
        [HttpPost("SaveAvailabilityModes")]
        public async Task<IActionResult> Save([FromBody] AvailabilityModes entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _availabilityModesService.SaveAvailabilityModesAsync(entity);
            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<AvailabilityModesController>/5
        [HttpPut("UpdateAvailabilityModes")]
        public async Task<IActionResult> Put([FromBody] AvailabilityModes availabilityModes)
        {
            var result = await _availabilityModesService.UpdateAvailabilityModesAsync(availabilityModes);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<AvailabilityModesController>/5
        [HttpDelete("RemoveAvailabilityModes")]
        public async Task<IActionResult> Delete([FromBody] AvailabilityModes availabilityModes)
        {
            var result = await _availabilityModesService.DeleteAvailabilityModesAsync(availabilityModes);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
