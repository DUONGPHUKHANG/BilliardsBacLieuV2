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
        //lấy tất cả các role
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleService.GetRoles();
            return Ok(roles);
        }
        //lấy role
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
        // tạo mới Role
        [HttpPost]
        public IActionResult CreateRole([FromBody] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("tên Role không được để trống");
            }

            var newRole = _roleService.CreateRole(name);
            return CreatedAtAction(nameof(GetRole), new { id = newRole.Id }, newRole);
        }
        //xóa Role
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRole([FromRoute] Guid id)
        {
            _roleService.DeleteRole(id);
            return NoContent();
        }
        
    }
}