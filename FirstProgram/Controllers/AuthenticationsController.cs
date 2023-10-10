using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.AuthenticateDto;
using Model.Dtos.CategoryDto;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationBs _authenticationBs;
        public AuthenticationsController(IAuthenticationBs authenticationBs)
        {
            _authenticationBs = authenticationBs;
        }
        [HttpGet("getallauthentications")]
        public async Task<IActionResult> GetAuthentications()
        {
            var response = await _authenticationBs.GetAuthenticationAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _authenticationBs.GetByIdAsync(id);
            return Ok(response);
        }
        //[AllowAnonymous]
        [HttpPost("addnewcauthentication")]
        public async Task<IActionResult> AddNewAuthentication([FromBody] AuthenticatePostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _authenticationBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut("updateauthentication")]
        public async Task<IActionResult> UpdateAuthentication([FromBody] AuthenticatePutDto dto)
        {
            var response = await _authenticationBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete("deleteauthentication")]
        public async Task<IActionResult> DeleteAuthentication(Guid id)
        {
            await _authenticationBs.DeleteAsync(id);
            return Ok();
        }
    }
}
