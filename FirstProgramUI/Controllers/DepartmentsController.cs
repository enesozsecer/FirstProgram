using FirstProgramUI.Models.DepartmentModel;
using FirstProgramUI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.DepartmentDto;
using Model.Dtos.UserDto;

namespace FirstProgramUI.Controllers
{
    public class DepartmentsController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public DepartmentsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<DepartmentGetDto>>(url + "Departments/GetDepartments");
            return View(val);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentGetViewModel addViewModel)
        {
            DepartmentGetDto postDto = new DepartmentGetDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
                CompanyName= addViewModel.CompanyName,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Departments/AddNewDepartment", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<DepartmentPutDto>(url + "Departments/GetById/" + id);
            DepartmentUpdateViewModel updateViewModels = new DepartmentUpdateViewModel()
            {
                ID = val.ID,
                Name = val.Name,
                CompanyID = val.CompanyID,

            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, DepartmentUpdateViewModel updateViewModels)
        {
            DepartmentPutDto putDto = new DepartmentPutDto()
            {
                Name = updateViewModels.Name,
                CompanyID= updateViewModels.CompanyID,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Departments/UpdateDepartment", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<DepartmentGetViewModel>(url + "Departments/GetById/" + id);

            DepartmentGetViewModel deleteViewModel = new DepartmentGetViewModel()
            {
                ID = val.ID,
                Name = val.Name,
                CompanyName = val.CompanyName,
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Departments/DeleteDepartment/" + id);
            return RedirectToAction("Index");
        }
    }
}
