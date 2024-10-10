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
        [Route("{id}")]
        public IActionResult GetRole([FromRoute]Guid id)
        {
            var role = _roleService.GetRole(id);
            return Ok(role);
        }
    }
}