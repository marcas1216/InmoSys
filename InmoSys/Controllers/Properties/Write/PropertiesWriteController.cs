using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface.Write;
using Properties.Entities.Write;
using Properties.Infrastructure.BusinessRepositories.Write;

namespace InmoSys.Controllers.Properties.Write
{
    [Route("api/properties")]
    [ApiController]
    public class PropertiesWriteController : ControllerBase
    {
        private readonly IPropertyWriteRepository _propertyService;

        public PropertiesWriteController(IPropertyWriteRepository propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Crea una nueva propiedad.
        /// </summary>
        /// <param name="request">Objeto con los datos de la propiedad a agregar</param>
        /// <returns>Retorna el ID de la propiedad creada</returns>
        /// <response code="200">Propiedad creada correctamente</response>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddProperty([FromBody] AddProperty request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _propertyService.AddPropertyAsync(request);
            return CreatedAtAction(nameof(AddProperty), new { id = newId }, newId);
        }

        /// <summary>
        /// Actualiza los datos de una propiedad existente.
        /// </summary>
        /// <param name="id">ID de la propiedad a actualizar</param>
        /// <param name="request">Objeto con los datos actualizados de la propiedad</param>
        /// <returns>Mensaje de confirmación si se actualizó correctamente</returns>
        /// <response code="200">Propiedad actualizada exitosamente</response>       
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] UpdateProperty request)
        {
            var result = await _propertyService.UpdatePropertyAsync(id, request);
            if (!result)
                return NotFound(new { message = "Propiedad no encontrada" });

            return Ok(new { message = "Propiedad actualizada exitosamente" });
        }

        /// <summary>
        /// Actualiza el precio de una propiedad específica.
        /// </summary>
        /// <param name="id">ID de la propiedad</param>
        /// <param name="request">Objeto con los nuevos valores de precio</param>
        /// <returns>Mensaje de confirmación de la actualización del precio</returns>
        /// <response code="200">Precio actualizado correctamente</response>
        [HttpPut("{id}/price")]
        [Authorize]
        public async Task<IActionResult> ChangePrice(int id, [FromBody] ChangePrices request)
        {
            await _propertyService.ChangePriceAsync(id, request);
            return Ok(new { Message = $"Precio actualizado correctamente para la propiedad: {id}" });
        }
    }
}
