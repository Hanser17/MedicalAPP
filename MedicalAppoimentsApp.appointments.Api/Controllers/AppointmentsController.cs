using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iappointments;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppoimentsApp.appointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase

    {
        private readonly IAppointmentsRepository _appointmentsRepository;

        public AppointmentsController(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        // GET: api/<Appointments>
        [HttpGet ("Appointments")]
        public async Task<IActionResult> Get()
        {
            var result = await _appointmentsRepository.GetAll();

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<Appointments>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Appointments>
        [HttpPost ("Appointments")]
        public async Task<IActionResult> Save([FromBody] Appointments entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _appointmentsRepository.Save(entity);

            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<Appointments>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Appointments>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
