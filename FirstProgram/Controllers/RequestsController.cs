using BusinessLayer.ImplementationsBs;
using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestBs _requestBs;
        public RequestsController(IRequestBs requestBs)
        {
            _requestBs = requestBs;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response=await _requestBs.GetByIdAsync(id);
            return Ok(response);
        }
    }
}
