using MicroservicesPractice.Web.Models.PhotoStocks;

namespace MicroservicesPractice.Web.Services.Abstract
{
    public interface IPhotoStockService
    {
        Task<PhotoViewModel> UploadPhoto(IFormFile photo);
        Task<bool> DeletePhoto(string photoUrl);
    }
}
