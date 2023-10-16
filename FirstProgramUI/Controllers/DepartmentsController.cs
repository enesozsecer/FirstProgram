using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.DepartmentModel;
using FirstProgramUI.Models.ProductModel;
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
        FirstProgramContext db = new FirstProgramContext();
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
            var val = new DepartmentGetModel
            {
                Company = db.Companies.ToList(),
                Department = db.Departments.ToList(),
            };
            return View(val);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentGetModel addViewModel)
        {
            DepartmentPostDto postDto = new DepartmentPostDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
                CompanyID= addViewModel.CompanyID,
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
            DepartmentGetModel updateViewModels = new DepartmentGetModel()
            {
                User = db.Users.ToList(),
                Company = db.Companies.ToList(),
                Department = db.Departments.ToList(),
                ID = val.ID,
                Name = val.Name,
                CompanyID = val.CompanyID,

            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, DepartmentGetModel updateViewModels)
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
            var val = await _httpClient.GetFromJsonAsync<DepartmentGetModel>(url + "Departments/GetById/" + id);

            DepartmentGetModel deleteViewModel = new DepartmentGetModel()
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
