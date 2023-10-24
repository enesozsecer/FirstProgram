using BusinessLayer.ImplementationsBs;
using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.InvoiceDto;
using Model.Dtos.SupplierDto;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceBs _invoiceBs;
        public InvoicesController(IInvoiceBs invoiceBs)
        {
            _invoiceBs = invoiceBs;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetInvoices()
        {
            var response = await _invoiceBs.GetInvoicesAsync("Supplier");
            return Ok(response);
        }
        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetInvoicesBySupplier([FromRoute] Guid id)
        {
            var response = await _invoiceBs.GetSupplierIdAsync(id, "Supplier");
            return Ok(response);
        }
        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _invoiceBs.GetByIdAsync(id, "Supplier");
            return Ok(response);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewInvoice([FromBody] InvoicePostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _invoiceBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateInvoice([FromBody] InvoicePutDto dto)
        {
            var response = await _invoiceBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            await _invoiceBs.DeleteAsync(id);
            return Ok();
        }
    }
}
