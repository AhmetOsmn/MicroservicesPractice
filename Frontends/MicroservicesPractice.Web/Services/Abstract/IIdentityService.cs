using IdentityModel.Client;
using MicroservicesPractice.Shared.Dtos;
using MicroservicesPractice.Web.Models;

namespace MicroservicesPractice.Web.Services.Abstract
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInInput signInInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
