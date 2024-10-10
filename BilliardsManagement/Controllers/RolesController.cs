using BilliardsManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilliardsManagement.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleService.GetRoles();
            return Ok(roles);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRole([FromRoute]Guid id)
        {
            var roles = _roleService.GetRole(id);
            if (roles == null)
            {
                return NotFound("Đồ ngu đồ ăn hại");
            }
            return Ok(roles);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRole([FromRoute] Guid id)
        {
            _roleService.DeleteRole(id);
            return NoContent();
        }
    }
}