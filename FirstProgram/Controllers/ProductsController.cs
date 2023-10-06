using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Mvc;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductBs _productBs;
        public ProductsController(IProductBs productBs)
        {
            _productBs = productBs;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response= await _productBs.GetByIdAsync(id);
            return Ok(response);
        }
    }
}
