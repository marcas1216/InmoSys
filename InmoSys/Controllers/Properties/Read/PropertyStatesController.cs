using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Properties.Aplication.Interface.Read;

namespace InmoSys.Controllers.Properties.Read
{
    [Route("api/propertystates")]
    [ApiController]
    public class PropertyStatesController : ControllerBase
    {
        private readonly IPropertyStateRepository _repository;

        public PropertyStatesController(IPropertyStateRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtiene la lista de todos los estados disponibles para las propiedades.
        /// </summary>
        /// <returns>Lista de estados de propiedades con sus IDs y nombres descriptivos.</returns>
        /// <response code="200">Se retornan los estados de las propiedades.</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }
    }
}
