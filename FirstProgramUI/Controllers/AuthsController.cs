using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.AuthModel;
using FirstProgramUI.Models.CompanyModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.AuthenticateDto;
using Model.Dtos.CompanyDto;
using Model.Dtos.UserLoginDto;
using Model.Entities;
//using Model.Dtos.UserLoginDto;

namespace FirstProgramUI.Controllers
{
    public class AuthsController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public AuthsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        FirstProgramContext db = new FirstProgramContext();
        #endregion
        [HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var val = await _httpClient.GetFromJsonAsync<List<LoginDto>>(url + "Auths");
        //    return View(val);
        //}

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuthGetViewModel addViewModel)
        {
            LoginDto postDto = new LoginDto()
            {
                UserName = addViewModel.UserName,
                UserPassword = addViewModel.UserPassword,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Auths/Authorize", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
