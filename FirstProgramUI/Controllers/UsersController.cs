using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.CompanyModel;
using FirstProgramUI.Models.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CompanyDto;
using Model.Dtos.UserDto;
using Model.Entities;

namespace FirstProgramUI.Controllers
{
    public class UsersController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<UserGetDto>>(url + "Users/GetUsers");
            return View(val);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserGetViewModel addViewModel)
        {
            UserGetDto postDto = new UserGetDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
                Password = addViewModel.Password,
                Email = addViewModel.Email,
                AuthenticateName=addViewModel.AuthenticateName,
                DepartmentName=addViewModel.DepartmentName,
                CompanyName=addViewModel.CompanyName
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Users/AddNewUser", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<UserPutDto>(url + "Users/GetById/" + id);
            UserUpdateViewModel updateViewModels = new UserUpdateViewModel()
            {
                ID = val.ID,
                Name = val.Name,
                Password = val.Password,
                Email = val.Email,
                AuthenticateID = val.AuthenticateID,
                DepartmentID = val.DepartmentID,
                CompanyID = val.CompanyID,
                
            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UserUpdateViewModel updateViewModels)
        {
            UserPutDto putDto = new UserPutDto()
            {
                Name = updateViewModels.Name,
                Password = updateViewModels.Password,
                Email = updateViewModels.Email,
                AuthenticateID = updateViewModels.AuthenticateID,
                DepartmentID = updateViewModels.DepartmentID,
                CompanyID = updateViewModels.CompanyID,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Users/UpdateUser", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<UserGetViewModel>(url + "Users/GetById/" + id);

            UserGetViewModel deleteViewModel = new UserGetViewModel()
            {
                ID = val.ID,
                Name = val.Name,
                Password = val.Password,
                Email = val.Email,
                AuthenticateName = val.AuthenticateName,
                DepartmentName = val.DepartmentName,
                CompanyName = val.CompanyName
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Users/DeleteUser/" + id);
            return RedirectToAction("Index");
        }

    }
}
