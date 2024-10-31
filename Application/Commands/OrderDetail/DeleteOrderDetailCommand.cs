using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.OrderDetail
{
    public class DeleteOrderDetailCommand : IRequest<Result>
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
        public DeleteOrderDetailCommand(Guid orderId, string productName, int quantity, decimal unitPrice)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
