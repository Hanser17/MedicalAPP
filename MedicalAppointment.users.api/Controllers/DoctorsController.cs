using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using MedicalAppoiments.Persistance.Repositories.usersRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.users.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepository _doctorRepository;
        public DoctorsController(IDoctorsRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        // GET: api/<Doctors>
        [HttpGet("GetAllDoctor")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorRepository.GetAll();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // GET api/<Doctors>/5
        [HttpGet("GetByDoctorID")]

        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorRepository.GetEntityBy(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // POST api/<Doctors>
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

            var result = await _doctorRepository.Save(entity);

            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<Doctors>/5
        [HttpPut("UpdateDoctor")]
        public async Task<IActionResult> Put([FromBody] Doctors doctor)
        {
            var result = await _doctorRepository.Update(doctor);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        // DELETE api/<Doctors>/5
        [HttpDelete("RemoveDoctor")]
        public async Task<IActionResult> Deleted([FromBody] Doctors doctor)
        {
            var result = await _doctorRepository.Remove(doctor);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
