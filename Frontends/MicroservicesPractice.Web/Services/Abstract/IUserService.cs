using MicroservicesPractice.Web.Models;

namespace MicroservicesPractice.Web.Services.Abstract
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();    
    }
}
