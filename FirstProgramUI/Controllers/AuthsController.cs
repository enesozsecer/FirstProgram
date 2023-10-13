using BusinessLayer.InterfacesBs;
using Core.Helpers;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using FirstProgramUI.Models.AuthModel;
using FirstProgramUI.Models.CompanyModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model.Dtos.AuthenticateDto;
using Model.Dtos.CompanyDto;
using Model.Dtos.UserDto;
using Model.Dtos.UserLoginDto;
using Model.Entities;
using Polly;
using System.Security.Claims;
//using Model.Dtos.UserLoginDto;

namespace FirstProgramUI.Controllers
{
    public class AuthsController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion
        public AuthsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        FirstProgramContext db = new FirstProgramContext();

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var val = db.Users.FirstOrDefault(x => x.Name == login.UserName && x.Password == login.UserPassword);
            if (val != null)
            {
                //HttpContext.Session.SetString("UserName", login.UserName);
                //return RedirectToAction("Index", "Categories");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.UserName),
                    new Claim(ClaimTypes.Role, val.AuthenticateID.ToString()),
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                HttpContext.Session.SetString("UserName", login.UserName);
                HttpContext.Session.SetString("UserRole", val.AuthenticateID.ToString());
                return RedirectToAction("Index", "Requests");
            }
            return View();



            //LoginDto postDto = new LoginDto()
            //{
            //    UserName = addViewModel.UserName,
            //    UserPassword = addViewModel.UserPassword,
            //};
            //HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Auths/Authorize", postDto);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();
        }
    }
}
