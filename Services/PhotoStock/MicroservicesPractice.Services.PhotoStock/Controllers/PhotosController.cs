using MicroservicesPractice.Services.PhotoStock.Dtos;
using MicroservicesPractice.Shared.ControllerBases;
using MicroservicesPractice.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesPractice.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo == null || photo.Length <= 0)
            {
                return CreateActionResultInstance(Response<PhotoDto>.Fail("Photo is empty", 400));
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);

            using FileStream stream = new(path, FileMode.Create);
            await photo.CopyToAsync(stream, cancellationToken);

            var returnPath = $"photos/{photo.FileName}";

            PhotoDto photoDto = new() { Url = returnPath };

            return CreateActionResultInstance(Response<PhotoDto>.Success(photoDto, 200));
        }

        [HttpGet]
        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);

            if (!System.IO.File.Exists(path))
            {
                return CreateActionResultInstance(Response<NoContent>.Fail("Photo not found", 404));
            }

            System.IO.File.Delete(path);

            return CreateActionResultInstance(Response<NoContent>.Success(204));
        }
    }
}
