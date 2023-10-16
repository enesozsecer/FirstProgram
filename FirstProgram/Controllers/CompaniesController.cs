using BusinessLayer.ImplementationsBs;
using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CategoryDto;
using Model.Dtos.CompanyDto;
using Model.Dtos.UserDto;
using Model.Entities;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "6739108f-db13-492c-907d-0e05d5d18769")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyBs _companyBs;
        public CompaniesController(ICompanyBs companyBs)
        {
            _companyBs = companyBs;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCompanies()
        {
            var response = await _companyBs.GetCompaniesAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _companyBs.GetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewCompany([FromBody] CompanyPostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _companyBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyPutDto dto)
        {
            var response = await _companyBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _companyBs.DeleteAsync(id);
            return Ok();
        }
    }
}
