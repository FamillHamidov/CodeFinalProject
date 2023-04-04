﻿using Travel.Web.Models;
using Travel.Web.Services.Interfaces;

namespace Travel.Web.Services
{
	public class UserService : IUserService
	{
		private readonly HttpClient _httpClient;

		public UserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<UserViewModel> GetUser()
		{
			return await _httpClient.GetFromJsonAsync<UserViewModel>("/api/user/getuser");
		}
	}
}
