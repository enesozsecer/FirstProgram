using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.CategoryModel;
using FirstProgramUI.Models.ProductModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CategoryDto;
using Model.Dtos.ProductDto;

namespace FirstProgramUI.Controllers
{
    [Authorize(Roles = "6739108f-db13-492c-907d-0e05d5d18769")]
    public class CategoriesController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public CategoriesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        FirstProgramContext db = new FirstProgramContext();
        #endregion
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<CategoryGetDto>>(url + "Categories/GetCategories");
            return View(val);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryGetModel addViewModel)
        {
            CategoryGetDto postDto = new CategoryGetDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Categories/AddNewCategory", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<CategoryPutDto>(url + "Categories/GetById/" + id);
            CategoryGetModel updateViewModels = new CategoryGetModel()
            {
                ID = val.ID,
                Name = val.Name,
            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, CategoryGetModel updateViewModels)
        {
            CategoryPutDto putDto = new CategoryPutDto()
            {
                Name = updateViewModels.Name,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Categories/UpdateCategory", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<CategoryGetModel>(url + "Categories/GetById/" + id);

            CategoryGetModel deleteViewModel = new CategoryGetModel()
            {
                ID = val.ID,
                Name = val.Name,
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Categories/DeleteCategory/" + id);
            return RedirectToAction("Index");
        }
    }
}
