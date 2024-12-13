using System.ComponentModel.DataAnnotations;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.Product
{
    internal class AddProductCommand : IRequest<Result>
    {
        [Required] public string ProductName { get; set; }
        [Required] public float ProductPrice { get; set; }
        [Required] public string ProductDescription { get; set; }
        [Required] public int ProductStoc { get; set; }
        [Required] public int ProductDiscount { set; get; }
        [Required] public string ProductPhotoPath { set; get; }
        public AddProductCommand(string productName, float productPrice, string productDescription, int Stoc, int Discount, string PhotoPath)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductDescription = productDescription;
            ProductStoc = Stoc;
            ProductDiscount = Discount;
            ProductPhotoPath=PhotoPath;
        }
    }
}
