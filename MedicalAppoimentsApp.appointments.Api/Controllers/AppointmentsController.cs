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
    public class AppointmentsController : ControllerBase

    {
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        // GET: api/<Appointments>
        [HttpGet ("GetAllAppointments")]
        public async Task<IActionResult> Get()
        {
            var result = await _appointmentsService.GetAllAppointmentsAsync();

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<Appointments>/5
        [HttpGet("GetByAppointmentsID")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _appointmentsService.GetAppointmentsByIdAsync(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // POST api/<Appointments>
        [HttpPost ("SaveAppointments")]
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

            var result = await _appointmentsService.SaveAppointmentsAsync(entity);

            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<Appointments>/5
        [HttpPut("UpdateAppointments")]
        public async Task<IActionResult> Put([FromBody] Appointments appointments)
        {
            var result = await _appointmentsService.UpdateAppointmentsAsync(appointments);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // DELETE api/<Appointments>/5
        [HttpDelete("RemoveAppointments")]
        public async Task<IActionResult> Deleted([FromBody] Appointments appointments)
        {
            var result = await _appointmentsService.RemoveAppointmentsAsync(appointments);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
