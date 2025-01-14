using Application.DTO;
using MediatR;

namespace Application.Queries.FilverValue
{
    public class GetFilterValueByFilteGroupIdQuery : IRequest<List<FilterValueDTO>>
    {
        public Guid IdFilterGroup { get; set; }
        public GetFilterValueByFilteGroupIdQuery()
        {

        }
    }
}
