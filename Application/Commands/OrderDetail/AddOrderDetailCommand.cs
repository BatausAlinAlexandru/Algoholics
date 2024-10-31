using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Order
{
    public class AddOrderDetailCommand : IRequest<Result>
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public AddOrderDetailCommand(Guid orderId, string productName, int quantity, decimal unitPrice)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
