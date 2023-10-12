using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CategoryDto;
using Model.Dtos.StatusDto;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly IStatusBs _statusBs;
        public StatusesController(IStatusBs statusBs)
        {
            _statusBs = statusBs;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetStatuses()
        {
            var response = await _statusBs.GetStatusAsync();
            return Ok(response);
        }
        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _statusBs.GetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewStatus([FromBody] StatusPostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _statusBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] StatusPutDto dto)
        {
            var response = await _statusBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> DeleteStatus(Guid id)
        {
            await _statusBs.DeleteAsync(id);
            return Ok();
        }
    }
}
