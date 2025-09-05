using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface;
using Properties.Aplication.Interface.Write;
using Properties.Entities.Write;

namespace InmoSys.Controllers.Properties.Write
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImagesWriteController : ControllerBase
    {
        private readonly IPropertyImageWriteRepository _repository;

        public PropertyImagesWriteController(IPropertyImageWriteRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddPropertyImages request)
        {
            if (request == null)
                return BadRequest("Datos inválidos.");

            var newId = await _repository.AddAsync(request);
            return Ok(new { Id = newId, Message = "Imagen agregada correctamente." });
        }
    }
}
