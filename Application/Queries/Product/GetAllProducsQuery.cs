using Application.DTO;
using MediatR;

namespace Application.Queies.Product
{
    public class GetAllProducsQuery : IRequest<List<ProductDTO>>
    {
    }
}
