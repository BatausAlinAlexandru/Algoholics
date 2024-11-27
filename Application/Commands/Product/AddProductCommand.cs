using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Product
{
    internal class AddProductCommand
    {
        [Required] public string ProductName { get; set; }
        [Required] public float ProductPrice { get; set; }
        [Required] public string ProductDescription { get; set; }
    }
}
