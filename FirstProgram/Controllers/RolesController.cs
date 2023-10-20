using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.RoleDto;
using Model.Dtos.CategoryDto;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleBs _roleBs;
        public RolesController(IRoleBs roleBs)
        {
            _roleBs = roleBs;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetRoles()
        {
            var response = await _roleBs.GetRoleAsync();
            if (response != null)
                return Ok(response);
            return BadRequest();
        }
        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _roleBs.GetByIdAsync(id);
            if (response != null)
                return Ok(response);
            return BadRequest();
        }
        //[AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewRole([FromBody] RolePostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _roleBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateRole([FromBody] RolePutDto dto)
        {
            var response = await _roleBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            await _roleBs.DeleteAsync(id);
            return Ok();
        }
    }
}
