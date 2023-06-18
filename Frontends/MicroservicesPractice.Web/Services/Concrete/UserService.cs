using MicroservicesPractice.Web.Models;
using MicroservicesPractice.Web.Services.Abstract;

namespace MicroservicesPractice.Web.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserViewModel?> GetUser()
        {
            return await _client.GetFromJsonAsync<UserViewModel>("/api/user/getuser");
        }
    }
}
