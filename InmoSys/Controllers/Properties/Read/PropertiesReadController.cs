
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface.Read;
using Properties.Entities.Read;

namespace InmoSys.Controllers.Properties.Read
{
    [Route("api/properties")]
    [ApiController]
    public class PropertiesReadController : ControllerBase
    {
        private readonly IPropertyReadRepository _propertyService;

        public PropertiesReadController(IPropertyReadRepository propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Obtiene la lista de todas las propiedades.
        /// </summary>
        /// <returns>Lista de propiedades</returns>
        [HttpGet]
        [Authorize]        
        public async Task<ActionResult<List<LoadProperty>>> GetProperties()
        {
            var result = await _propertyService.GetPropertiesAsync();

            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }


        /// <summary>
        /// Obtiene la lista de propiedades filtradas por propietario.
        /// </summary>
        /// <param name="ownerId">ID del propietario</param>
        /// <returns>Lista de propiedades del propietario</returns>
        [HttpGet("owner/{ownerId}")]
        [Authorize]
        public async Task<ActionResult<List<LoadProperty>>> GetPropertiesByOwner(int ownerId)
        {
            var result = await _propertyService.GetPropertiesByOwnerAsync(ownerId);

            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }

        /// <summary>
        /// Obtiene la lista de propiedades filtradas por estado.
        /// </summary>
        /// <param name="propertyStateId">ID del estado de la propiedad</param>
        /// <returns>Lista de propiedades según el estado</returns>
        [HttpGet("state/{propertyStateId}")]
        [Authorize]
        public async Task<ActionResult<List<LoadProperty>>> GetPropertiesByState(int propertyStateId)
        {
            var result = await _propertyService.GetPropertiesByStateAsync(propertyStateId);

            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }

        /// <summary>
        /// Obtiene la lista de propiedades filtradas por tipo.
        /// </summary>
        /// <param name="propertyTypeId">ID del tipo de propiedad</param>
        /// <returns>Lista de propiedades según el tipo</returns>
        [HttpGet("type/{propertyTypeId}")]
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
