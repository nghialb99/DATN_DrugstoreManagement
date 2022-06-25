using DrugstoreManagement.ViewModels.Common;
using DrugstoreManagement.ViewModels.System.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ApiIntegration.Interface
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVm>>> GetAllRole();
        Task<ApiResult<bool>> CreateRole(RoleVm request);
        Task<ApiResult<bool>> UpdateRole(RoleVm request);
        Task<ApiResult<bool>> DeleteRole(Guid id);
    }
}
