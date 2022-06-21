using DrugstoreManagement.Data.EF;
using DrugstoreManagement.Data.Entities;
using DrugstoreManagement.Utilities;
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
        private readonly DrugstoreDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
            RoleManager<AppRole> roleManager, IConfiguration config, DrugstoreDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }
        public async Task<ApiResult<string>> Authencate(LoginRequest request) //Task<ApiResult<string>>
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null) return new ApiErrorResult<string>("Thông tin đăng nhập không đúng");
            if (!user.LockoutEnabled) return new ApiErrorResult<string>("Tài khoản đã bị khóa");
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Thông tin đăng nhập không đúng");
            }
            //update LockoutEnd
            user.LockoutEnd = DateTime.Now;
            await _userManager.UpdateAsync(user);

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
            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<UserVm>> GetUserById(Guid id)
        {
            var users = await _userManager.FindByIdAsync(id.ToString());
            if (users == null)
            {
                return new ApiErrorResult<UserVm>("Tài khoản không tồn tại");
            }
            var role = await _userManager.GetRolesAsync(users);
            //1.Select join
            var query = from u in _context.AppUsers
                        join e in _context.Employees on u.EmployeeId equals e.employeeCode into ue
                        from user in ue.DefaultIfEmpty()
                        where u.Id == id
                        select new { u, user };

            var data = await query.Select(x => new UserVm()
            {
                Id = x.u.Id,
                FullName = x.u.FirstName + " " + x.u.LastName,
                Dob = x.user.birthDate,
                Gender = x.user.gender,
                IdCard = x.user.idCard,
                Address = x.user.address,
                EmployeeCode = x.user.employeeCode,
                DateCreated = x.u.DateCreated,
                UserName = x.u.UserName,
                UserRoles = role.FirstOrDefault(),
                Email = x.u.Email,
                PhoneNumber = x.u.PhoneNumber,
                LockoutEnd = x.u.LockoutEnd,
                LockoutEnabled = x.u.LockoutEnabled,
                ImageFilePath = x.u.ImageFilePath,

            }).SingleOrDefaultAsync();
            GuardAgainst.Null(data);
            return new ApiSuccessResult<UserVm>(data);
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request)
        {
            //1. Select join
            var query = from u in _context.AppUsers
                        join e in _context.Employees on u.EmployeeId equals e.employeeCode into ue

                        from user in ue.DefaultIfEmpty()

                        select new { u, user };
            //query = query.Where(x => x.u.LockoutEnabled == request.lockoutEnabled);
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.u.UserName.Contains(request.keyword)
                    || x.u.FirstName.Contains(request.keyword)
                    || x.u.LastName.Contains(request.keyword)
                    || x.u.EmployeeId.Contains(request.keyword)
                    || x.u.Email.Contains(request.keyword)
                    || x.u.PhoneNumber.Contains(request.keyword)
                    || x.user.idCard.Contains(request.keyword)
                    || x.user.gender.Contains(request.keyword)
                    || x.user.address.Contains(request.keyword));
            }

            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select( x => new UserVm()
                {
                    Id = x.u.Id,
                    FullName = x.u.FirstName + " " + x.u.LastName,
                    Dob = x.user.birthDate,
                    Gender = x.user.gender,
                    IdCard = x.user.idCard,
                    Address = x.user.address,
                    EmployeeCode = x.user.employeeCode,
                    DateCreated = x.u.DateCreated,
                    UserName = x.u.UserName,
                    Email = x.u.Email,
                    PhoneNumber = x.u.PhoneNumber,
                    LockoutEnd = x.u.LockoutEnd,
                    LockoutEnabled = x.u.LockoutEnabled,
                    ImageFilePath = x.u.ImageFilePath,

                }).ToListAsync();
            var pagedResult = new PagedResult<UserVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserVm>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("emai đã tồn tại");
            }

            user = new AppUser()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                EmployeeId = request.EmployeeId,
                DateCreated = DateTime.Now,
                ImageFilePath = @"assets\Resouse\icons8-male-user-100.png",

            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>(true);
            }
            return new ApiErrorResult<bool>("Thêm mới không thành công");

        }

        public async Task<ApiResult<bool>> Update(UserUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Id != request.Id && x.Email == request.Email))
            {
                return new ApiErrorResult<bool>("Email đã được đăng kí cho tài khoản khác");
            }
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            //user.Dob = request.Dob;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>(true);
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        public async Task<ApiResult<bool>> LockUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            if (user.LockoutEnabled == false)
            {
                return new ApiErrorResult<bool>("Tài khoản này đã bị khóa");
            }
            user.LockoutEnabled = false;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>(true);
            }
            return new ApiErrorResult<bool>("Khóa Người dùng không thành công");
        }
        public async Task<ApiResult<bool>> UnLockUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            if (user.LockoutEnabled == true)
            {
                return new ApiErrorResult<bool>("Tài khoản này vẫn đang hoạt động");
            }
            user.LockoutEnabled = true;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>(true);
            }
            return new ApiErrorResult<bool>("Khóa Người dùng không thành công");
        }

        private async Task<string> GetRoleNameByUser(AppUser user)
        {
            return (await _userManager.GetRolesAsync(user)).First();

        }
    }
}
