
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using MedicalAppointment.Application.Interfaces.IsystemService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.system.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }
        // GET: api/<RolesController>
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> Get()
        {
            var result = await _rolesService.GetAllRoles();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);

        }
            // GET api/<RolesController>/5
            [HttpGet("GetByIdRoles")]
            public async Task<IActionResult> Get(int id)
        {
            var result = await _rolesService.GetRolesByID(id);
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

            var result = await _rolesService.SaveRolesAsync(entity);

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
            var result = await _rolesService.UpdateRolesAsync(roles);

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
            var result = await _rolesService.RemoveRolesAsync(roles);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }



    }
}
