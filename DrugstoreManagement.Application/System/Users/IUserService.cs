using DrugstoreManagement.ViewModels.Common;
using DrugstoreManagement.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);//ApiResult<string>

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<ApiResult<PageResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request);

        //Task<ApiResult<UserVm>> GetById(Guid id);

        //Task<ApiResult<bool>> Delete(Guid id);

        //Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}
