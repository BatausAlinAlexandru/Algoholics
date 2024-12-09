using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Order
{
    public class CancelOrderCommand : IRequest<Result>
    {
        [Required]
        public Guid OrderId { get; set; }
        public CancelOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}