using MicroservicesPractice.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesPractice.Shared.ControllerBases
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
