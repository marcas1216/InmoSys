using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface.Write;
using Properties.Entities.Write;

namespace InmoSys.Controllers.Properties.Write
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesWriteController : ControllerBase
    {
        private readonly IPropertyWriteRepository _propertyService;

        public PropertiesWriteController(IPropertyWriteRepository propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddProperty([FromBody] AddProperty request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _propertyService.AddPropertyAsync(request);
            return CreatedAtAction(nameof(AddProperty), new { id = newId }, newId);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] UpdateProperty request)
        {
            var result = await _propertyService.UpdatePropertyAsync(id, request);
            if (!result)
                return NotFound(new { message = "Propiedad no encontrada" });

            return Ok(new { message = "Propiedad actualizada exitosamente" });
        }
    }
}
