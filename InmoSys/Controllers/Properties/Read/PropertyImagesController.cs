using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface.Read;

namespace InmoSys.Controllers.Properties.Read
{
    [Route("api/propertyimages")]
    [ApiController]
    public class PropertyImagesController : ControllerBase
    {
        private readonly IPropertyImageRepository _repository;

        public PropertyImagesController(IPropertyImageRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtiene todas las imágenes asociadas a una propiedad específica.
        /// </summary>
        /// <param name="propertyId">ID de la propiedad de la que se desean obtener las imágenes.</param>
        /// <returns>Lista de imágenes de la propiedad, incluyendo URL y metadatos asociados.</returns>
        /// <response code="200">Se retornan las imágenes de la propiedad.</response>       
        [HttpGet("{propertyId}")]
        [Authorize]
        public async Task<IActionResult> GetAllByProperty(int propertyId)
        {
            var result = await _repository.GetAllByPropertyAsync(propertyId);
            return Ok(result);
        }
    }
}
