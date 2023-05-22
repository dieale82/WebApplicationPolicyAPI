using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolicyModels;
using PolicyQueries;

namespace WebApplicationPolicyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Apply authorization to the whole controller
    public class PolicyController : ControllerBase
    {
        private readonly ICreatePolicy _createPolicy;
        private readonly IGetPolicy _getPolicy;

        public PolicyController(ICreatePolicy createPolicy, IGetPolicy getPolicy)
        {
            _createPolicy = createPolicy;
            _getPolicy = getPolicy;
        }

        [HttpPost("v1/CreatePolicy")]
        public async Task<IActionResult> CreatePolicy(InsurancePolicy policy)
        {            
            await _createPolicy.Handle(policy);
            return Ok();
        }

        [HttpGet("v1/GetPolicy")]
        public async Task<IActionResult> GetPolicy(string placaVehiculo, string numeroPoliza)
        {
            List<InsurancePolicy> policies = await _getPolicy.Handle(placaVehiculo, numeroPoliza);
            return Ok(policies);
        }
    }
}
