using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        public async Task<string> SaveFileAsync(string folder, string fileName, IFormFile file)
        {
            // Creează calea completă pentru folder
            var folderPath = Path.Combine("wwwroot", folder);

            // Verifică și creează directorul dacă nu există
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Creează calea completă pentru fișier
            var filePath = Path.Combine(folderPath, fileName);



            // Salvează fișierul
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Returnează calea relativă pentru stocare în baza de date
            return $"/{folder}/{fileName}";
        }
        public async Task<bool> DeleteFileAsync(string folder, string fileName)
        {
            // Creează calea completă pentru fișier
            var filePath = Path.Combine("wwwroot", folder, fileName);

            // Verifică dacă fișierul există
            if (File.Exists(filePath))
            {
                // Șterge fișierul
                File.Delete(filePath);
                return true;
            }

            // Returnează false dacă fișierul nu există
            return false;
        }
    }
}
