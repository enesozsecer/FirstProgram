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
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            await _productBs.GetByIdAsync(id);
            return Ok("iyiyim");
        }
    }
}
