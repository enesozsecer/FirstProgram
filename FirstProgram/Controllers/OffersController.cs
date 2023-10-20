using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CategoryDto;
using Model.Dtos.OfferDto;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferBs _offerBs;
        public OffersController(IOfferBs offerBs)
        {
            _offerBs = offerBs;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetOffers()
        {
            var response = await _offerBs.GetOffersAsync("Product", "Status");
            return Ok(response);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetOffersBySupplier(string name)
        {
            var response = await _offerBs.GetNameAsync(name, "Product", "Status");
            return Ok(response);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetOffersByProduct(Guid Id)
        {
            var response = await _offerBs.GetAsyncByProduct(Id, "Product", "Status");
            return Ok(response);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetOffersByStatus(Guid Id)
        {
            var response = await _offerBs.GetAsyncByStatus(Id, "Product", "Status");
            return Ok(response);
        }
        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _offerBs.GetByIdAsync(id, "Product", "Status");
            return Ok(response);
        }
        //[AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewOffer([FromBody] OfferPostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _offerBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateOffer([FromBody] OfferPutDto dto)
        {
            var response = await _offerBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> DeleteOffer(Guid id)
        {
            await _offerBs.DeleteAsync(id);
            return Ok();
        }
    }
}
