namespace Application.DTO
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public Guid UserAccountId { get; set; }
        public List<CartItemDto> Items { get; set; } = new();
        public float TotalPrice { get; set; }
    }

    public class CartItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
