using DrugstoreManagement.Data.Entities;
using DrugstoreManagement.Utilities.Exceptions;
using DrugstoreManagement.ViewModels.Common;
using DrugstoreManagement.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                new Claim(ClaimTypes.GivenName,user.LastName+" "+user.FirstName),
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

        public async Task<PageResult<UserVm>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.LockoutEnabled == request.lockoutEnabled);
            }
            else
            {
                query = query.Where(x => x.UserName.Contains(request.keyword)
                    || x.FirstName.Contains(request.keyword)
                    || x.LastName.Contains(request.keyword)
                    || x.employeeId.ToString().Contains(request.keyword)
                    || x.Email.Contains(request.keyword)
                    || x.PhoneNumber.Contains(request.keyword)
                    || x.LockoutEnabled == request.lockoutEnabled);
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new UserVm()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Dob = x.Dob,
                    employeeId = x.employeeId,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    dateCreated = x.dateCreated,
                    LockoutEnd = x.LockoutEnd,
                    LockoutEnabled = x.LockoutEnabled,

                }).ToListAsync();
            var pagedResult = new PageResult<UserVm>()
            {
                TotalRecords = totalRow,
                pageIndex = request.pageIndex,
                pageSize = request.pageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            //if (user != null)
            //{
            //    return false;
            //    //return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            //}
            //if (await _userManager.FindByEmailAsync(request.Email) != null)
            //{
            //    return false;
            //    //return new ApiErrorResult<bool>("Emai đã tồn tại");
            //}

            user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;

        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
