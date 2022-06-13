using DrugstoreManagement.Data.Entities;
using DrugstoreManagement.Utilities.Exceptions;
using DrugstoreManagement.ViewModels.Common;
using DrugstoreManagement.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
            RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<string> Authencate(LoginRequest request) //Task<ApiResult<string>>
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) throw new DrugstoreException("Tài khoản không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                throw new DrugstoreException("Thông tin đăng nhập không đúng");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            //var user = await _userManager.FindByNameAsync(request.UserName);
            //if (user != null)
            //{
            //    return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            //}
            //if (await _userManager.FindByEmailAsync(request.Email) != null)
            //{
            //    return new ApiErrorResult<bool>("Emai đã tồn tại");
            //}

            //user = new AppUser()
            //{
            //    Dob = request.Dob,
            //    Email = request.Email,
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    UserName = request.UserName,
            //    PhoneNumber = request.PhoneNumber
            //};
            //var result = await _userManager.CreateAsync(user, request.Password);
            //if (result.Succeeded)
            //{
            //    return new ApiSuccessResult<bool>();
            //}
            //return new ApiErrorResult<bool>("Đăng ký không thành công");
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
