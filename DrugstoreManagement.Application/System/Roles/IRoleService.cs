using DrugstoreManagement.ViewModels.Common;
using DrugstoreManagement.ViewModels.System.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Application.System.Roles
{
    public interface IRoleService
    {
        Task<ApiResult<List<RoleVm>>> GetAllRole();
        Task<ApiResult<bool>> CreateRole(RoleVm vm);
        //Task<ApiResult<bool>> UpdateRole(RoleVm vm);
    }
}
