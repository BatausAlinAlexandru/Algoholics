using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Interfaces
{
    public interface IImageService
    {
        Task<(Result Result, string Message, string RelativePath)> SaveImageAsync(IFormFile imageFile, string folderName);
    }
}
