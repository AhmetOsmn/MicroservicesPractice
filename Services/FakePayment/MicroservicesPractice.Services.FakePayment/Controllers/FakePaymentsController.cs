using MicroservicesPractice.Services.FakePayment.Models;
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
        public IActionResult ReceivePayment(PaymentDto paymentDto)
        {
            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }
    }
}
