using Microsoft.AspNetCore.Http;

namespace Application.Services.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(string folder, string fileName, IFormFile file);
    }
}
