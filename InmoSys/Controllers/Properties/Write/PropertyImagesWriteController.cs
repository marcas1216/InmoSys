using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface.Write;
using Properties.Entities.Write;

namespace InmoSys.Controllers.Properties.Write
{
    [Route("api/propertyimages")]
    [ApiController]
    public class PropertyImagesWriteController : ControllerBase
    {
        private readonly IPropertyImageWriteRepository _repository;

        public PropertyImagesWriteController(IPropertyImageWriteRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Agrega una nueva imagen a una propiedad.
        /// </summary>
        /// <param name="request">Objeto con los datos de la imagen que se desea agregar</param>
        /// <returns>Retorna el ID de la imagen creada y un mensaje de confirmación</returns>
        /// <response code="200">Imagen agregada correctamente</response>
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
