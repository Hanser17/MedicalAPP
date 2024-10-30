using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.medical.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtiesService _specialtiesService;

        public SpecialtiesController(ISpecialtiesService specialtiesService)
        {
            _specialtiesService = specialtiesService;
        }
        // GET: api/<SpecialtiesController>
        [HttpGet("GetAllSpecialties")]
        public async Task<IActionResult> Get()
        {
            var result = await _specialtiesService.GetAllSpecialtiesAsync();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // GET api/<SpecialtiesController>/5
        [HttpGet("GetByIdSpecialties/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _specialtiesService.GetByIDSpecialtiesAsync(id);
            if (!result.success)
            {
                return NotFound(result.message);
            }
            return Ok(result.Data);
        }
        // POST api/<SpecialtiesController>
        [HttpPost("SaveSpecialties")]
        public async Task<IActionResult> Save([FromBody] Specialties entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _specialtiesService.SaveSpecialtiesAsync(entity);
            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<SpecialtiesController>/5
        [HttpPut("UpdateSpecialties")]
        public async Task<IActionResult> Put([FromBody] Specialties specialties)
        {
            var result = await _specialtiesService.UpdateSpecialtiesAsync(specialties);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<SpecialtiesController>/5
        [HttpDelete("RemoveSpecialties")]
        public async Task<IActionResult> Delete([FromBody] Specialties specialties)
        {
            var result = await _specialtiesService.DeleteSpecialtiesAsync(specialties);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
