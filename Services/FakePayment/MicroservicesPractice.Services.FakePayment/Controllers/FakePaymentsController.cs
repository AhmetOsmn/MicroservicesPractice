using MicroservicesPractice.Shared.ControllerBases;
using MicroservicesPractice.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesPractice.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomBaseController
    {
        [HttpPost]
        public IActionResult ReceivePayment()
        {
            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }
    }
}
