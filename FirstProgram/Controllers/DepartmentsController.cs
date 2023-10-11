using BusinessLayer.ImplementationsBs;
using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CompanyDto;
using Model.Dtos.DepartmentDto;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentBs _departmentBs;
        public DepartmentsController(IDepartmentBs departmentBs)
        {
            _departmentBs = departmentBs;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetDepartments()
        {
            var response = await _departmentBs.GetDepartmentsAsync("Company");
            return Ok(response);
        }

        [HttpGet]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _departmentBs.GetByIdAsync(id, "Company");
            return Ok(response);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewDepartment([FromBody] DepartmentPostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _departmentBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentPutDto dto)
        {
            var response = await _departmentBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete]
        [Route("[action]/{id:Guid}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            await _departmentBs.DeleteAsync(id);
            return Ok();
        }
    }
}
