using Application.DTO;
using MediatR;

namespace Application.Queries.UserAccount
{
    public class GetUserAccountByIdQuery : IRequest<UserAccountDTO>
    {
        public Guid UserAccountId { get; set; }


        public GetUserAccountByIdQuery(Guid userAccountId)
        {
            UserAccountId = userAccountId;
        }
    }
}
