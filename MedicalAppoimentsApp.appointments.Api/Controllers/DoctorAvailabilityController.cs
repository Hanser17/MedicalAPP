using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iappointments;
using MedicalAppointment.Application.Interfaces.IappointmentsService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppoimentsApp.appointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : ControllerBase

    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityService;

        public DoctorAvailabilityController(IDoctorAvailabilityService doctorAvailabilityService)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }

        // GET: api/<DoctorAvailability>
        [HttpGet("DoctorAvailability")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorAvailabilityService.GetAllDoctorAvailabilityAsync();

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        // GET api/<DoctorAvailability>/5
        [HttpGet("GetByDoctorID")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorAvailabilityService.GetDoctorAvailabilityByIdAsync(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpGet(" DoctorAvailabilityByDoctorID")]
        public async Task<IActionResult> DoctorAvailabilityByDoctorID(int id)
        {
            var result = await _doctorAvailabilityService.DoctorAvailabilityByDoctorIDAsync(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }
       

        // POST api/<DoctorAvailability>
        [HttpPost("SaveDoctor")]
        public async Task<IActionResult> Save([FromBody] DoctorAvailability entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _doctorAvailabilityService.SaveDoctorAvailabilityAsync(entity);
            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<DoctorAvailability>/5
        [HttpPut("UpdateDoctor")]
        public async Task<IActionResult> Put([FromBody] DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabilityService.RemoveDoctorAvailabilityAsync(doctorAvailability);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<DoctorAvailability>/5
        [HttpDelete("RemoveDoctor")]
        public async Task<IActionResult> Deleted([FromBody] DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabilityService.UpdateDoctorAvailabilityAsync(doctorAvailability);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
