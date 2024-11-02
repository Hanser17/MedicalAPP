using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.users.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("GetAllDoctor")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorService.GetAllDoctorsAsync();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpGet("GetByDoctorID")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var result = await _doctorService.GetDoctorByIdAsync(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpGet("GetDoctorByAvailability")]
        public async Task<IActionResult> GetDoctorByAvailability(int id)
        {
            var result = await _doctorService.GetDoctorByAvailabilityAsync(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpGet("GetDoctorBySpecialty")]
        public async Task<IActionResult> GetDoctorBySpecialty(int id)
        {
            var result = await _doctorService.GetDoctorBySpecialtyAsync(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpPost("SaveDoctor")]
        public async Task<IActionResult> Save([FromBody] Doctors entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _doctorService.SaveDoctorAsync(entity);
            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("UpdateDoctor")]
        public async Task<IActionResult> Put([FromBody] Doctors doctor)
        {
            var result = await _doctorService.UpdateDoctorAsync(doctor);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("RemoveDoctor")]
        public async Task<IActionResult> Deleted(int id)
        {
            var result = await _doctorService.RemoveDoctorAsync(id);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
