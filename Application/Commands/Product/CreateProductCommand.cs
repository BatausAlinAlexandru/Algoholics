using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Product
{
    public class CreateProductCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Discount { get; set; }
        public string PathFoto { get; set; }
        public CreateProductCommand() { }

        public CreateProductCommand(string name, float price, string description, int stock, int discount, string pathFoto)
        {
            Name = name;
            Price = price;
            Description = description;
            Stock = stock;
            Discount = discount;
            PathFoto = pathFoto;
        }
    }
}
