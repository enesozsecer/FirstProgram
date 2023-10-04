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
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            await _productBs.FindByIdAsync(id);
            return Ok("iyiyim");
        }
    }
}
