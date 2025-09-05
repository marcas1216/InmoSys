using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface;

namespace InmoSys.Controllers.Properties.Read
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyStatesController : ControllerBase
    {
        private readonly IPropertyStateRepository _repository;

        public PropertyStatesController(IPropertyStateRepository repository)
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
