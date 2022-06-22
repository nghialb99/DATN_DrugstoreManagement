using DrugstoreManagement.Data.Entities;
using DrugstoreManagement.ViewModels.Common;
using DrugstoreManagement.ViewModels.System.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Application.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<ApiResult<List<RoleVm>>> GetAllRole()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();

            return new ApiSuccessResult<List<RoleVm>>(roles);
        }
        public async Task<ApiResult<bool>> CreateRole(RoleVm vm)
        {
            var role = await _roleManager.FindByNameAsync(vm.Name);
            if (role != null) return new ApiErrorResult<bool>("Tên quyền đã tồn tại");
            role = new AppRole()
            {
                Name = vm.Name,
                Description = vm.Description
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("");
        }

        //public async Task<ApiResult<bool>> UpdateRole(RoleVm vm)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
