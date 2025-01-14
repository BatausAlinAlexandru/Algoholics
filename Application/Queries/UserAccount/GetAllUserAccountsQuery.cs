using Application.DTO;
using MediatR;

namespace Application.Queies.UserAccount
{
    public class GetAllUserAccountsQuery : IRequest<List<UserAccountDTO>>
    {
        public GetAllUserAccountsQuery()
        {
            // Constructor logic here
        }
    }
}
