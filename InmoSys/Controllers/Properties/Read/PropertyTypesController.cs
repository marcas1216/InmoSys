using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface;

namespace InmoSys.Controllers.Properties.Read
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTypesController : ControllerBase
    {
        private readonly IPropertyTypeRepository _repository;

        public PropertyTypesController(IPropertyTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }
    }
}
