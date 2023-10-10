﻿using BusinessLayer.ImplementationsBs;
using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.ProductDto;
using Model.Dtos.RequestDto;

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
        [HttpGet("getallrequests")]
        public async Task<IActionResult> GetRequests()
        {
            var response = await _requestBs.GetRequestsAsync("Category", "User", "Status");
            return Ok(response);
        }
        [HttpGet("getbystatus")]
        public async Task<IActionResult> GetRequestsByStatus([FromRoute] Guid id)
        {
            var response = await _requestBs.GetStatusIdAsync(id, "Category", "User", "Status");
            return Ok(response);
        }
        [HttpGet("getbyuser")]
        public async Task<IActionResult> GetRequestsByUser([FromRoute] Guid id)
        {
            var response = await _requestBs.GetUserIdAsync(id, "Category", "User", "Status");
            return Ok(response);
        }
        [HttpGet("getbycategory")]
        public async Task<IActionResult> GetRequestsByCategory([FromRoute] Guid id)
        {
            var response = await _requestBs.GetCategoryIdAsync(id, "Category", "User", "Status");
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _requestBs.GetByIdAsync(id, "Category", "User", "Status");
            return Ok(response);
        }
        [HttpPost("addnewrequest")]
        public async Task<IActionResult> AddNewRequest([FromBody] RequestPostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _requestBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut("updaterequest")]
        public async Task<IActionResult> UpdateRequest([FromBody] RequestPutDto dto)
        {
            var response = await _requestBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete("deleterequest")]
        public async Task<IActionResult> DeleteRequest(Guid id)
        {
            await _requestBs.DeleteAsync(id);
            return Ok();
        }
    }
}
