using DrugstoreManagement.ApiIntegration.Interface;
using DrugstoreManagement.Utilities;
using DrugstoreManagement.ViewModels.Common;
using DrugstoreManagement.ViewModels.System.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ApiIntegration
{
    public class RoleApiClient : IRoleApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RoleApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ApiResult<bool>> CreateRole(RoleVm request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var httpContext = _httpContextAccessor.HttpContext;
            GuardAgainst.Null(httpContext);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", httpContext.Session.GetString("Token"));
            var response = await client.PostAsync("/api/roles", httpContent);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
                GuardAgainst.Null(result);
                return result;
            }
            else
            {
                return new ApiErrorResult<bool>(response.ReasonPhrase);
            }
        }

        public async Task<ApiResult<bool>> DeleteRole(Guid id)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var httpContext = _httpContextAccessor.HttpContext;
            GuardAgainst.Null(httpContext);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", httpContext.Session.GetString("Token"));
            var response = await client.DeleteAsync($"/api/roles/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
                GuardAgainst.Null(result);
                return result;
            }
            else
            {
                return new ApiErrorResult<bool>(response.ReasonPhrase);
            }
        }

        public async Task<ApiResult<List<RoleVm>>> GetAllRole()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var httpContext = _httpContextAccessor.HttpContext;
            GuardAgainst.Null(httpContext);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", httpContext.Session.GetString("Token"));
            var response = await client.GetAsync("/api/roles");

            if (!response.IsSuccessStatusCode)
            {
                return new ApiErrorResult<List<RoleVm>>(response.ReasonPhrase);
            }
            var body = await response.Content.ReadAsStringAsync();
            var roles = JsonConvert.DeserializeObject<ApiSuccessResult<List<RoleVm>>>(body);
            GuardAgainst.Null(roles);
            return roles;
        }

        public async Task<ApiResult<bool>> UpdateRole(RoleVm request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var httpContext = _httpContextAccessor.HttpContext;
            GuardAgainst.Null(httpContext);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", httpContext.Session.GetString("Token"));
            var response = await client.PutAsync($"/api/roles", httpContent);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
                GuardAgainst.Null(result);
                return result;
            }
            else
            {
                return new ApiErrorResult<bool>(response.ReasonPhrase);
            }
        }
    }
}
