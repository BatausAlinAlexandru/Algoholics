using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Application.Commands.Product
{
    public abstract class ModifyProductCommand : IRequest<Result>
    {
        public Guid ProductId { get; set; }

        protected ModifyProductCommand() { }
        protected ModifyProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }

    public class ModifyProductNameCommand : ModifyProductCommand
    {
        public string Name { get; set; }

        public ModifyProductNameCommand() { }

        public ModifyProductNameCommand(Guid productId, string name) : base(productId)
        {
            Name = name;
        }
    }

    public class ModifyProductStockCommand : ModifyProductCommand
    {
        public int Stock { get; set; }
        public ModifyProductStockCommand() { }

        public ModifyProductStockCommand(Guid productId, int stock) : base(productId)
        {
            Stock = stock;
        }
    }

    public class ModifyProductPriceCommand : ModifyProductCommand
    {
        public float Price { get; set; }

        public ModifyProductPriceCommand() { }
        public ModifyProductPriceCommand(Guid productId, float price) : base(productId)
        {
            Price = price;
        }
    }

    public class ModifyProductDescriptionCommand : ModifyProductCommand
    {
        public string Description { get; set; }

        public ModifyProductDescriptionCommand() { }
        public ModifyProductDescriptionCommand(Guid productId, string description) : base(productId)
        {
            Description = description;
        }
    }

    public class ModifyProductDiscountCommand : ModifyProductCommand
    {
        public int Discount { get; set; }

        public ModifyProductDiscountCommand() { }

        public ModifyProductDiscountCommand(Guid productId, int discount) : base(productId)
        {
            Discount = discount;
        }
    }
}
