using Travel.Web.Models;

namespace Travel.Web.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserViewModel> GetUser();
	}
}
