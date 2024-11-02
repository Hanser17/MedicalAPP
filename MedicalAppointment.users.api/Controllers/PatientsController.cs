using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.users.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> Get()
        {
            var result = await _patientService.GetAllPatients();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpGet("GetByPatientID")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _patientService.GetPatientById(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpGet("GetPatientsByInsuranceProvider")]
        public async Task<IActionResult> GetPatientsByInsuranceProvider(int id)
        {
            var result = await _patientService.GetPatientsByInsuranceProviderAsync(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        [HttpPost("SavePatient")]
        public async Task<IActionResult> Save([FromBody] Patients entity)
        {
            

            var result = await _patientService.SavePatientAsync(entity);
            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> Put([FromBody] Patients patients)
        {
            var result = await _patientService.UpdatePatientAsync(patients);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("RemovePatient")]
        public async Task<IActionResult> Deleted(int PatientID)
        {
            var result = await _patientService.RemovePatientAsync(PatientID);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
