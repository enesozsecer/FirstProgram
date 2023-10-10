using Microsoft.AspNetCore.Mvc;
using Model.Dtos.UserLoginDto;
//using Model.Dtos.UserLoginDto;

namespace FirstProgramUI.Controllers
{
    public class AuthsController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "http://localhost:7161/api/";
        #endregion

        #region Constructor
        public AuthsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            //var val = await _httpClient.GetFromJsonAsync<List<LoginDto>>(url + "Auths");
            return View();
        }
    }
}
