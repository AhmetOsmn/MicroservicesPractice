using MicroservicesPractice.Web.Models.FakePayments;

namespace MicroservicesPractice.Web.Services.Abstract
{
    public interface IPaymentService
    {
        Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
    }
}
