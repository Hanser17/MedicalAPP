using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.medical.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordsService _medicalRecordsService;

        public MedicalRecordsController(IMedicalRecordsService medicalRecordsService)
        {
            _medicalRecordsService = medicalRecordsService;
        }
        // GET: api/<MedicalRecordsController>
        [HttpGet("GetAllMedicalRecords")]
        public async Task<IActionResult> Get()
        {
            var result = await _medicalRecordsService.GetAllMedicalRecordsAsync();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // GET api/<MedicalRecordsController>/5
        [HttpGet("GetByIdMedicalRecords/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _medicalRecordsService.GetByIDMedicalRecordsAsync(id);
            if (!result.success)
            {
                return NotFound(result.message);
            }
            return Ok(result.Data);
        }

        // POST api/<MedicalRecordsController>
        [HttpPost("SaveMedicalRecords")]
        public async Task<IActionResult> Save([FromBody] MedicalRecords entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _medicalRecordsService.SaveMedicalRecordsAsync(entity);
            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<MedicalRecordsController>/5
        [HttpPut("UpdateMedicalRecords")]
        public async Task<IActionResult> Put([FromBody] MedicalRecords medicalRecords)
        {
            var result = await _medicalRecordsService.UpdateMedicalRecordsAsync(medicalRecords);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<MedicalRecordsController>/5
        [HttpDelete("RemoveMedicalRecords")]
        public async Task<IActionResult> Delete([FromBody] MedicalRecords medicalRecords)
        {
            var result = await _medicalRecordsService.DeleteMedicalRecordsAsync(medicalRecords);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
