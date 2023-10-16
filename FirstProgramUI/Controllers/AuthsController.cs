using FirstProgramUI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.UserLoginDto;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using NuGet.Common;
using Azure.Core;

namespace FirstProgramUI.Controllers
{
    public class AuthsController : Controller
    {
        private IAuthApiService _authApiService;
        private IHttpContextAccessor _httpContextAccessor;
        public AuthsController(IAuthApiService authApiService, IHttpContextAccessor httpContextAccessor)
        {
            _authApiService = authApiService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _authApiService.LoginAsync(loginDto);
            if (user !=null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("token", user.Email);
                var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                userClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
                userClaims.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                var claimPrincipal = new ClaimsPrincipal(userClaims);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);
                return RedirectToAction("Index", "Users");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı!");
            }
            return View(loginDto);
        }































        //#region Defines
        //private readonly HttpClient _httpClient;
        //private string url = "https://localhost:7161/api/";
        //private readonly IUserRepository _repo;
        //private readonly AppSettings _appSettings;
        //#endregion
        //public AuthsController(HttpClient httpClient, IUserRepository repo, IOptions<AppSettings> appSettings)
        //{
        //    _httpClient = httpClient;
        //    _repo = repo;
        //    _appSettings = appSettings.Value;
        //}

        //FirstProgramContext db = new FirstProgramContext();

        //[HttpGet]
        //public async Task<IActionResult> Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<AccessToken> Login(LoginDto login)
        //{
        //    var val = await _repo.GetAsync(x => x.Email == login.UserName && x.Password == login.UserPassword);
        //    if (val == null)
        //    {
        //        return null;
        //    }

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
        //    var tokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //        new Claim(ClaimTypes.Email,val.ID.ToString()),
        //        new Claim(ClaimTypes.Role,val.AuthenticateID.ToString())
        //    }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    AccessToken accessToken = new AccessToken()
        //    {
        //        Token = tokenHandler.WriteToken(token),
        //        Expiration = (DateTime)tokenDescriptor.Expires,
        //        UserName = val.Email,
        //        UserID = val.ID,
        //        AuthenticationID = val.ID,
        //    };
        //    return await Task.Run(() => accessToken);







        //    //var val = db.Users.FirstOrDefault(x => x.Email == login.UserName && x.Password == login.UserPassword);
        //    //if (val != null)
        //    //{
        //    //    var claims = new List<Claim>
        //    //    {
        //    //        new Claim(ClaimTypes.Email, login.UserName),
        //    //        new Claim(ClaimTypes.Role, val.AuthenticateID.ToString()),
        //    //    };
        //    //    var useridentity = new ClaimsIdentity(claims, "a");
        //    //    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //    //    await HttpContext.SignInAsync(principal);
        //    //    HttpContext.Session.SetString("UserName", login.UserName);
        //    //    HttpContext.Session.SetString("UserRole", val.AuthenticateID.ToString());
        //    //    return RedirectToAction("Index", "Requests");
        //    //}
        //    //return View();
        //}
    }
}
