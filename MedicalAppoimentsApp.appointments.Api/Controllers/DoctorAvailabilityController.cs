using MedicalAppoiments.Persistance.Interfaces.Iappointments;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppoimentsApp.appointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : ControllerBase

    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;

        public DoctorAvailabilityController(IDoctorAvailabilityRepository doctorAvailabilityRepository)
        {
            _doctorAvailabilityRepository = doctorAvailabilityRepository;
        }

        // GET: api/<DoctorAvailability>
        [HttpGet("DoctorAvailability")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorAvailabilityRepository.GetAll();

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        // GET api/<DoctorAvailability>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DoctorAvailability>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DoctorAvailability>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoctorAvailability>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
