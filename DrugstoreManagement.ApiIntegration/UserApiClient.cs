﻿using DrugstoreManagement.ApiIntegration.Interface;
using DrugstoreManagement.Utilities;
using DrugstoreManagement.ViewModels.Common;
using DrugstoreManagement.ViewModels.System.Users;
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
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, 
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync("/api/users/authenticate", httpContent);
            var token = new ApiResult<string>();
            if (response.IsSuccessStatusCode)
            {
                token = JsonConvert.DeserializeObject<ApiSuccessResult<string>>(await response.Content.ReadAsStringAsync());
                GuardAgainst.Null<ApiResult<string>>(token);
                return token;
            }
            else
            {
                return new ApiErrorResult<string>("404");
            }
        }

        public async Task<ApiResult<bool>> CreateAcount(RegisterRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
            var response = await client.PostAsync("/api/users/createAcount", httpContent);
            var result = new ApiResult<bool>();
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
                GuardAgainst.Null<ApiResult<bool>>(result);
                return result;
            }
            else
            {
                result = JsonConvert.DeserializeObject<ApiErrorResult<bool>>(await response.Content.ReadAsStringAsync());
                GuardAgainst.Null<ApiResult<bool>>(result);
                return result;
            }
        }

        public async Task<ApiResult<UserVm>> GetUserById(Guid id, string token)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/Users/{id}");
            var result = new ApiResult<UserVm>();
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<ApiSuccessResult<UserVm>>(await response.Content.ReadAsStringAsync());
                GuardAgainst.Null<ApiResult<UserVm>>(result);
                return result;
            }
            else
            {
                result = JsonConvert.DeserializeObject<ApiErrorResult<UserVm>>(await response.Content.ReadAsStringAsync());
                GuardAgainst.Null<ApiResult<UserVm>>(result);
                return result;
            }
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
            var response = await client.GetAsync($"/api/Users/paging?pageIndex=" +
                $"{request.pageIndex}&pageSize={request.pageSize}&lockoutEnabled={request.lockoutEnabled}" +
                $"&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<UserVm>>>(body);
            GuardAgainst.Null<ApiResult<PagedResult<UserVm>>>(users);
            return users;
        }

        public async Task<ApiResult<bool>> UpdateUser(UserUpdateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
            var response = await client.PutAsync($"/api/users/{request.Id}", httpContent);
            var result = new ApiResult<bool>();
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
                GuardAgainst.Null<ApiResult<bool>>(result);
                return result;
            }
            else
            {
                result = JsonConvert.DeserializeObject<ApiErrorResult<bool>>(await response.Content.ReadAsStringAsync());
                GuardAgainst.Null<ApiResult<bool>>(result);
                return result;
            }
        }
    }
}
