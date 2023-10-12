using BusinessLayer.ImplementationsBs;
using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.DepartmentDto;
using Model.Dtos.ProductDto;

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
        [Route("[action]")]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productBs.GetProductsAsync("Category");
            return Ok(response);
        }

        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _productBs.GetByIdAsync(id, "Category");
            return Ok(response);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductPostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _productBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductPutDto dto)
        {
            var response = await _productBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productBs.DeleteAsync(id);
            return Ok();
        }
    }
}
