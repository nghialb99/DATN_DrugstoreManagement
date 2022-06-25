using DrugstoreManagement.Application.System.Roles;
using DrugstoreManagement.ViewModels.System.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugsoreManagement.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var roles = await _roleService.GetAllRole();
            return Ok(roles);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleVm request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roleService.CreateRole(request);

            return Ok(result);
        }
        

        //PUT: https://localhost/api/roles/id
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleVm request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roleService.UpdateRole(request);

            return Ok(result);
        }

        //DELETE: https://localhost/api/roles/delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roleService.DeleteRole(id);

            return Ok(result);
        }
    }
}
