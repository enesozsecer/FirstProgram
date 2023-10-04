using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.UserLoginDto;

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
        //[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto dto)
        {
            var response = await _userBs.AuthenticateAsync(dto);
            if (response != null)
                return Ok(response);
            return BadRequest();
        }
    }
}
