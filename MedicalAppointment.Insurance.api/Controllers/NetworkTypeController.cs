using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Result;
using MedicalAppointment.Application.Interfaces.IinsuranceService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointment.Insurance.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkTypeController : ControllerBase
    {
        private readonly INetworkTypeService _networkTypeService;

        public NetworkTypeController(INetworkTypeService networkTypeService)
        {
            _networkTypeService = networkTypeService;
        } 

        // GET: api/<NetworkTypeController>
        [HttpGet("GetAllNetworkType")]
        public async Task<IActionResult> Get()
        {
            var result = await _networkTypeService.GetAllNetworkTypeAsync();
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // GET api/<NetworkTypeController>/5
        [HttpGet("GetByNetworkTypeID")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _networkTypeService.GetByIDNetworkTypeAsync(id);
            if (!result.success)
            {
                return BadRequest(result.message);
            }
            return Ok(result.Data);
        }

        // POST api/<NetworkTypeController>
        [HttpPost("SaveNetworkType")]
        public async Task<IActionResult> Save([FromBody] NetworkType networkType)
        {
            if (networkType == null)
            {
                return BadRequest(new OperationResult
                {
                    success = false,
                    message = "La entidad es requerida."
                });
            }

            var result = await _networkTypeService.SaveNetworkTypeAsync(networkType);
            if (!result.success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<NetworkTypeController>/5
        [HttpPut("UpdateNetworkType")]
        public async Task<IActionResult> Put([FromBody] NetworkType networkType)
        {
            var result = await _networkTypeService.UpdateNetworkTypeAsync(networkType);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<NetworkTypeController>/5
        [HttpDelete("RemoveNetworkType")]
        public async Task<IActionResult> Deleted([FromBody] NetworkType networkType)
        {
            var result = await _networkTypeService.DeleteNetworkTypeAsync(networkType);
            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
