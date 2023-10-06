using BusinessLayer.ImplementationsBs;
using BusinessLayer.InterfacesBs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CategoryDto;
using Model.Dtos.UserLoginDto;
using Model.Entities;

namespace FirstProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBs _categoryBs;
        public CategoriesController(ICategoryBs categoryBs)
        {
            _categoryBs = categoryBs;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _categoryBs.GetByIdAsync(id);
            return Ok(response);
        }
        //[AllowAnonymous]
        [HttpPost("addnewcategory")]
        public async Task<IActionResult> AddNewCategory([FromBody] CategoryPostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _categoryBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryPutDto dto)
        {
            var response = await _categoryBs.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.ID }, response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _categoryBs.DeleteAsync(id);
            return Ok();
        }
    }
}
