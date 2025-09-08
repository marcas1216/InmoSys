
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface.Read;
using Properties.Entities.Read;

namespace InmoSys.Controllers.Properties.Read
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesReadController : ControllerBase
    {
        private readonly IPropertyReadRepository _propertyService;

        public PropertiesReadController(IPropertyReadRepository propertyService)
        {
            _propertyService = propertyService;
        }
              
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<LoadProperty>>> GetProperties()
        {
            var result = await _propertyService.GetPropertiesAsync();

            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }

        [HttpGet("ByOwner/{ownerId}")]
        [Authorize]
        public async Task<ActionResult<List<LoadProperty>>> GetPropertiesByOwner(int ownerId)
        {
            var result = await _propertyService.GetPropertiesByOwnerAsync(ownerId);

            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }

        [HttpGet("ByState/{propertyStateId}")]
        [Authorize]
        public async Task<ActionResult<List<LoadProperty>>> GetPropertiesByState(int propertyStateId)
        {
            var result = await _propertyService.GetPropertiesByStateAsync(propertyStateId);

            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }

        [HttpGet("ByType/{propertyTypeId}")]
        [Authorize]
        public async Task<ActionResult<List<LoadProperty>>> GetPropertiesByType(int propertyTypeId)
        {
            var result = await _propertyService.GetPropertiesByTypeAsync(propertyTypeId);

            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }
    }
}
