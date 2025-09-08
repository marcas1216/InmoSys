using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Owner.Aplication.Interface;

namespace InmoSys.Controllers.Owners.Read
{
    [Route("api/owners")]
    [ApiController]
    public class OwnersReadController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersReadController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        /// <summary>
        /// Obtiene la lista de todos los propietarios registrados.
        /// </summary>
        /// <returns>Lista de propietarios</returns>
        /// <response code="200">Retorna la lista de propietarios</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var owners = await _ownerService.GetAllAsync();
            return Ok(owners);
        }
    }
}
