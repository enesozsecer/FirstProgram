using BusinessLayer.ImplementationsBs;
using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.ProductDto;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _userBs.GetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost("addnewuser")]
        public async Task<IActionResult> AddNewUser([FromBody] User dto)
        {
            var response = await _userBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
    }
}
