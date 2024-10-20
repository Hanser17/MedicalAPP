using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.users.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository _patientsRepository;

        public PatientsController(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        // GET: api/<Patients>
        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> Get()
        {
            var result = await _patientsRepository.GetAll();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // GET api/<Patients>/5
        [HttpGet("GetByPatientID")]

        public async Task<IActionResult> Get(int id)
        {
            var result = await _patientsRepository.GetEntityBy(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // POST api/<Patients>
        [HttpPost("SavePatient")]

        public async Task<IActionResult> Save([FromBody] Patients entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _patientsRepository.Save(entity);

            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<Patients>/5
        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> Put([FromBody] Patients patients)
        {
            var result = await _patientsRepository.Update(patients);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        // DELETE api/<Patients>/5
        [HttpDelete("RemovePatient")]
        public async Task<IActionResult> Deleted([FromBody] Patients patients)
        {
            var result = await _patientsRepository.Remove(patients);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
