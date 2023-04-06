using Travel.Web.Models;
using Travel.Web.Services.Interfaces;

namespace Travel.Web.Services
{
	public class RegisterService : IRegisterService
	{
		private readonly HttpClient _httpClient;

		public RegisterService(HttpClient httpClient)
		{
			this._httpClient = httpClient;
		}

		public async Task<bool> SignUp(SignUpInput signUpInput)
		{

			var response = await _httpClient.PostAsJsonAsync<SignUpInput>("/api/user/signup", signUpInput);

			return response.IsSuccessStatusCode;
		}
	}
}
