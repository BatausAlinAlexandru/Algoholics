namespace Application.DTO
{
    public class WishListDTO
    {
        public Guid IdWishList { get; set; }
        public List<Guid> ProductId { get; set; }
    }
}
