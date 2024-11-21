using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppointment.Application.Interfaces.IinsuranceService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.Insurance.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceProvidersController : ControllerBase
    {
        private readonly IInsuranceProvidersService _insuranceProvidersService;

        public InsuranceProvidersController (IInsuranceProvidersService insuranceProvidersService)
        {
            _insuranceProvidersService = insuranceProvidersService;
        }



        [HttpGet("GetAllInsuranceProviders")]
        public async Task<IActionResult> Get()
        {
            var result = await _insuranceProvidersService.GetAllInsuranceProvidersAsync();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

      
        [HttpGet("GetByInsuranceProviders")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _insuranceProvidersService.GetByIDInsuranceProvidersAsync(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

       
        [HttpGet("GeGetInsuranceProvidersByNetWorkt")]
        public async Task<IActionResult> GeGetInsuranceProvidersByNetWorkt(int id)
        {
            var result = await _insuranceProvidersService.GetInsuranceProvidersByNetWorkAsync(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }
       
        [HttpPost("SaveInsuranceProviders")]
        public async Task<IActionResult> Save([FromBody] InsuranceProviders entity)
        {
            if (entity == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }
            var result = await _insuranceProvidersService.SaveInsuranceProvidersAsync(entity);
            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
        [HttpPut("UpdateInsuranceProviders")]
        public async Task<IActionResult> Put([FromBody] InsuranceProviders insuranceProviders)
        {
            var result = await _insuranceProvidersService.UpdateInsuranceProvidersAsync(insuranceProviders);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

       
        [HttpDelete("RemoveInsuranceProviders")]
        public async Task<IActionResult> Deleted([FromBody] InsuranceProviders insuranceProviders)
        {
            var result = await _insuranceProvidersService.DeleteInsuranceProvidersAsync(insuranceProviders);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
