using MicroservicesPractice.Shared.Services.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace MicroservicesPractice.Shared.Services.Concrete
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
