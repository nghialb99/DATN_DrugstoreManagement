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
        Task<string> Authenticate(LoginRequest request);
        Task<PageResult<UserVm>> GetUsersPagings(GetUserPagingRequest request);
        Task<bool> CreateAcount(RegisterRequest request);
    }
}
