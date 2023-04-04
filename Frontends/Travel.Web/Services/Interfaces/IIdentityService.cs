using IdentityModel.Client;
using Travel.Shared.Dtos;
using Travel.Web.Models;

namespace Travel.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInInput signIn);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
