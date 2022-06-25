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
            if (vm.Name == null) return new ApiErrorResult<bool>("Tên quyền không được để trống");
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
            return new ApiErrorResult<bool>("Thêm mới quyền thất bại");
        }

        public async Task<ApiResult<bool>> UpdateRole(RoleVm vm)
        {
            var role = await _roleManager.FindByIdAsync(vm.Id.ToString());
            if (role.NormalizedName == "ADMIN") return new ApiErrorResult<bool>("Quyền ADMIN không thể sửa");
            if (role != null) return new ApiErrorResult<bool>("Tên quyền đã tồn tại");
            role = new AppRole()
            {
                Name = vm.Name,
                Description = vm.Description
            };
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật quyền thất bại");
        }

        public async Task<ApiResult<bool>> DeleteRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null) return new ApiErrorResult<bool>("Tên quyền không tồn tại");
            if (role.NormalizedName == "ADMIN") return new ApiErrorResult<bool>("Quyền ADMIN không thể xóa");
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Xóa quyền thất bại");
        }
    }
}
