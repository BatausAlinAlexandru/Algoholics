using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.Product
{
    namespace Application.Commands.Product
    {
        public class DeleteProductCommand : IRequest<Result>
        {
            [Required]
            public Guid IdProduct { get; set; }

            public DeleteProductCommand(Guid idProduct)
            {
                IdProduct = idProduct;
            }
        }
    }
}
