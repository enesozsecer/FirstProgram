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
        //[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Merhaba([FromBody] CategoryPostDto dto)
        {
            dto.ID = Guid.NewGuid();
            var response = await _categoryBs.InsertAsync(dto);
            if (response != null)
                return Ok(response);
            return BadRequest();
        }
    }
}
