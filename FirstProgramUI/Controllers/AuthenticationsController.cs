using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.AuthenticationModel;
using FirstProgramUI.Models.DepartmentModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.AuthenticateDto;
using Model.Dtos.DepartmentDto;

namespace FirstProgramUI.Controllers
{
    public class AuthenticationsController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public AuthenticationsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        FirstProgramContext db = new FirstProgramContext();
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<AuthenticateGetDto>>(url + "Authentications/GetAuthentications");
            return View(val);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuthenticateGetModel addViewModel)
        {
            AuthenticateGetDto postDto = new AuthenticateGetDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,

            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Authentications/AddNewAuthentication", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<AuthenticatePutDto>(url + "Authentications/GetById/" + id);
            AuthenticateGetModel updateViewModels = new AuthenticateGetModel()
            {
                ID = val.ID,
                Name = val.Name,
            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, AuthenticateGetModel updateViewModels)
        {
            AuthenticatePutDto putDto = new AuthenticatePutDto()
            {
                Name = updateViewModels.Name,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Authentications/UpdateAuthentication", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<AuthenticateGetModel>(url + "Authentications/GetById/" + id);

            AuthenticateGetModel deleteViewModel = new AuthenticateGetModel()
            {
                ID = val.ID,
                Name = val.Name,
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Authentications/DeleteAuthentication/" + id);
            return RedirectToAction("Index");
        }
    }
}
