using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.DepartmentModel;
using FirstProgramUI.Models.RoleModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.RoleDto;
using Model.Dtos.DepartmentDto;

namespace FirstProgramUI.Controllers
{
    public class RolesController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public RolesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        FirstProgramContext db = new FirstProgramContext();
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<RoleGetDto>>(url + "Roles/GetRoles");
            return View(val);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleGetModel addViewModel)
        {
            RoleGetDto postDto = new RoleGetDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,

            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Roles/AddNewRole", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<RolePutDto>(url + "Roles/GetById/" + id);
            RoleGetModel updateViewModels = new RoleGetModel()
            {
                ID = val.ID,
                Name = val.Name,
            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, RoleGetModel updateViewModels)
        {
            RolePutDto putDto = new RolePutDto()
            {
                Name = updateViewModels.Name,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Roles/UpdateRole", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<RoleGetModel>(url + "Roles/GetById/" + id);

            RoleGetModel deleteViewModel = new RoleGetModel()
            {
                ID = val.ID,
                Name = val.Name,
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Roles/DeleteRole/" + id);
            return RedirectToAction("Index");
        }
    }
}
