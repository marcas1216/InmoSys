using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Owner.Aplication.Interface;

namespace InmoSys.Controllers.Owners.Read
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersReadController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersReadController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var owners = await _ownerService.GetAllAsync();
            return Ok(owners);
        }
    }
}
