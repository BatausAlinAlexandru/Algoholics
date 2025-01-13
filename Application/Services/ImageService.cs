using Application.Services.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class ImageService : IImageService
    {
        public Task<(Result Result, string Message, string RelativePath)> SaveImageAsync(IFormFile imageFile, string folderName)
        {

            throw new NotImplementedException();
        }
    }
}
