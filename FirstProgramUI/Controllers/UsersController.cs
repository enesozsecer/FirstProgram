using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.CompanyModel;
using FirstProgramUI.Models.RequestModel;
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

        FirstProgramContext db = new FirstProgramContext();
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var AuthsID = HttpContext.Session.GetString("AuthsID");
            //if (AuthsID== "32aa239e-5041-4ebc-a98d-19193778ad0f")
            //{
                var val = await _httpClient.GetFromJsonAsync<List<UserGetDto>>(url + "Users/GetUsers");
                return View(val);
            //}
            //return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var val = new UserGetModel
            {
                Company = db.Companies.ToList(),
                User = db.Users.ToList(),
                Role = db.Authentications.ToList(),
                Department = db.Departments.ToList(),
            };
            return View(val);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserGetModel addViewModel)
        {
            
            UserPostDto postDto = new UserPostDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
                Password = addViewModel.Password,
                Email = addViewModel.Email,
                RoleID = addViewModel.RoleID,
                DepartmentID = addViewModel.DepartmentID,
                CompanyID = addViewModel.CompanyID,
                
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync("https://localhost:7161/api/Users/AddNewUser"
, postDto);
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
            UserGetModel updateViewModels = new UserGetModel()
            {
                Company = db.Companies.ToList(),
                User = db.Users.ToList(),
                Role = db.Authentications.ToList(),
                Department = db.Departments.ToList(),
                ID = val.ID,
                Name = val.Name,
                Password = val.Password,
                Email = val.Email,
                RoleID = val.RoleID,
                DepartmentID = val.DepartmentID,
                CompanyID = val.CompanyID,
                
            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UserGetModel updateViewModels)
        {
            UserPutDto putDto = new UserPutDto()
            {
                Name = updateViewModels.Name,
                Password = updateViewModels.Password,
                Email = updateViewModels.Email,
                RoleID = updateViewModels.RoleID,
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
            var val = await _httpClient.GetFromJsonAsync<UserGetModel>(url + "Users/GetById/" + id);

            UserGetModel deleteViewModel = new UserGetModel()
            {
                ID = val.ID,
                Name = val.Name,
                Password = val.Password,
                Email = val.Email,
                RoleName = val.RoleName,
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
        public IActionResult MatchMethod(Guid id)
        {
            var val = db.Departments
                .Where(x => x.CompanyID == id)
                .ToList();

            return Json(val);
        }

    }
}
