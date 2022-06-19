using DrugstoreManagement.ApiIntegration.Interface;
using DrugstoreManagement.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        public LoginController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _userApiClient.Authenticate(request);
            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
                
            }

            HttpContext.Session.SetString("Token", result.ResultObj);
            var userPrincipal = this.ValidateToken(result.ResultObj);
            var authenProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true,
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,userPrincipal, authenProperties);

            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Login");
        }
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}
