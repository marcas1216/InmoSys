using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface;

namespace InmoSys.Controllers.Properties.Read
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImagesController : ControllerBase
    {
        private readonly IPropertyImageRepository _repository;

        public PropertyImagesController(IPropertyImageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{propertyId}")]
        [Authorize]
        public async Task<IActionResult> GetAllByProperty(int propertyId)
        {
            var result = await _repository.GetAllByPropertyAsync(propertyId);
            return Ok(result);
        }
    }
}
