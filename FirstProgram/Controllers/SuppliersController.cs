using BusinessLayer.ImplementationsBs;
using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.ProductDto;
using Model.Dtos.SupplierDto;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierBs _supplierBs;
        public SuppliersController(ISupplierBs supplierBs)
        {
            _supplierBs = supplierBs;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetSuppliers()
        {
            var response = await _supplierBs.GetSuppliersAsync("Category");
            return Ok(response);
        }
        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetSuppliersByCategory([FromRoute] Guid id)
        {
            var response = await _supplierBs.GetCategoryIdAsync(id, "Category");
            return Ok(response);
        }
        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _supplierBs.GetByIdAsync(id, "Category");
            return Ok(response);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewSupplier([FromBody] SupplierPostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _supplierBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierPutDto dto)
        {
            var response = await _supplierBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            await _supplierBs.DeleteAsync(id);
            return Ok();
        }
    }
}
