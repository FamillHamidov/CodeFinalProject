using Travel.Web.Models;

namespace Travel.Web.Services.Interfaces
{
	public interface IRegisterService
	{
		Task<bool> SignUp(SignUpInput signUpInput);
	}
}
