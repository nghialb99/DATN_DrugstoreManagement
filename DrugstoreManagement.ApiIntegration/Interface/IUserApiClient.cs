using DrugstoreManagement.ViewModels.Common;
using DrugstoreManagement.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ApiIntegration.Interface
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<UserVm>> GetUserById(Guid id, string token);
        Task<ApiResult<bool>> CreateAcount(RegisterRequest request);
        Task<ApiResult<bool>> UpdateUser(UserUpdateRequest request);
    }
}
