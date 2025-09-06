
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
    }
}
