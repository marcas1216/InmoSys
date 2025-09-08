using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface.Read;

namespace InmoSys.Controllers.Properties.Read
{
    [Route("api/propertytypes")]
    [ApiController]
    public class PropertyTypesController : ControllerBase
    {
        private readonly IPropertyTypeRepository _repository;

        public PropertyTypesController(IPropertyTypeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtiene la lista de todos los tipos de propiedades disponibles.
        /// </summary>
        /// <returns>Lista de tipos de propiedades con sus IDs y nombres descriptivos.</returns>
        /// <response code="200">Se retornan los tipos de propiedades.</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }
    }
}
