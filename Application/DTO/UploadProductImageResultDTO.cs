using CSharpFunctionalExtensions;

namespace Application.DTO
{
    public class UploadProductImageResultDTO
    {
        public Result Success { get; set; }
        public string Message { get; set; }
        public string ImagePath { get; set; }
    }
}
