using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.UserLoginDto;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthBs _authBs;
        public AuthsController(IAuthBs authBs)
        {
            _authBs = authBs;
        }
        //[AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Authorize([FromBody] LoginDto dto)
        {

            var response = await _authBs.AuthenticateAsync(dto);
            if (response != null)
                return Ok(response);
            return BadRequest();
        }
    }
}
