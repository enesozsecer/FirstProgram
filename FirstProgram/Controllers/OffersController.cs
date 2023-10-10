using BusinessLayer.InterfacesBs;
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
        [HttpGet("getalloffers")]
        public async Task<IActionResult> GetOffers()
        {
            var response = await _offerBs.GetOffersAsync("Product");
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _offerBs.GetByIdAsync(id, "Product");
            return Ok(response);
        }
        //[AllowAnonymous]
        [HttpPost("addnewoffer")]
        public async Task<IActionResult> AddNewOffer([FromBody] OfferPostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _offerBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut("updateoffer")]
        public async Task<IActionResult> UpdateOffer([FromBody] OfferPutDto dto)
        {
            var response = await _offerBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete("deleteoffer")]
        public async Task<IActionResult> DeleteOffer(Guid id)
        {
            await _offerBs.DeleteAsync(id);
            return Ok();
        }
    }
}
