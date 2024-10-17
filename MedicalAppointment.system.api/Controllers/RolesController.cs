using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iappointments;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using MedicalAppoiments.Persistance.Repositories.appointmentsRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.system.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        // GET: api/<RolesController>
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult> Get()
        {
            var result = await _rolesRepository.GetAll();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);

        }
            // GET api/<RolesController>/5
            [HttpGet("GetByIdRoles")]
            public async Task<ActionResult> Get(int id)
        {
            var result = await _rolesRepository.GetEntityBy(id);
            if (!result.success)
            {
                return NotFound(result.message);
            }
            return Ok(result.Data);
        }

        // POST api/<RolesController>
        [HttpPost ("SaveRoles")]
        public async Task<IActionResult> Save([FromBody] Roles entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _rolesRepository.Save(entity);

            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<RolesController>/5
        [HttpPut("UpdateRoles")]
        public async Task<IActionResult> Put( [FromBody] Roles roles)
        {
            var result = await _rolesRepository.Update(roles);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        // DELETE api/<RolesController>/5
        [HttpDelete("RemoveRole")]
        public async Task<IActionResult> Deleted([FromBody] Roles roles)
        {
            var result = await _rolesRepository.Remove(roles);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }



    }
}
