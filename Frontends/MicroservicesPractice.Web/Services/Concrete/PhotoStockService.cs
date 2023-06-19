using MicroservicesPractice.Shared.Dtos;
using MicroservicesPractice.Web.Models.PhotoStocks;
using MicroservicesPractice.Web.Services.Abstract;

namespace MicroservicesPractice.Web.Services.Concrete
{
    public class PhotoStockService : IPhotoStockService
    {
        private readonly HttpClient _httpClient;

        public PhotoStockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> DeletePhoto(string photoUrl)
        {
            var response = await _httpClient.DeleteAsync($"photos?photoUrl={photoUrl}");

            return response.IsSuccessStatusCode;
        }

        public async Task<PhotoViewModel?> UploadPhoto(IFormFile photo)
        {
            if(photo == null || photo.Length <= 0)
            {
                return null;
            }

            var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";

            using var memoryStream = new MemoryStream();
            await photo.CopyToAsync(memoryStream);

            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new ByteArrayContent(memoryStream.ToArray()), "photo", randomFileName);

            var response = await _httpClient.PostAsync("photos", multipartContent);

            if (response == null) return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<PhotoViewModel>>();

            return responseSuccess.Data;
        }
    }
}
