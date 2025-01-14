using Application.DTO;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Product
{
    public class UploadProductImageCommand : IRequest<Result>
    {
        public Guid ProductID { get; set; }
        public IFormFile ImageFile { get; set; }

        public UploadProductImageCommand(Guid productID, IFormFile imageFile)
        {
            ProductID = productID;
            ImageFile = imageFile;
        }
    }
}
