using BusinessLayer.ImplementationsBs;
using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.ProductDto;
using Model.Dtos.UserDto;
using Model.Dtos.UserLoginDto;
using Model.Entities;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBs _userBs;
        public UsersController(IUserBs userBs)
        {
            _userBs = userBs;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userBs.GetUsersAsync("Authenticate", "Department", "Company");
            return Ok(response);
        }

        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _userBs.GetByIdAsync(id, "Authenticate", "Department", "Company");
            return Ok(response);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewUser([FromBody] UserPostDto dto)
        {

            dto.ID = Guid.NewGuid();
            var response = await _userBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] UserPutDto dto)
        {
            var response = await _userBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userBs.DeleteAsync(id);
            return Ok();
        }
    }
}
