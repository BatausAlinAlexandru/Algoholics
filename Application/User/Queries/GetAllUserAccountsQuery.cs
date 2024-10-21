using Application.User.DTO;
using MediatR;

namespace Application.User.Queries
{
    public class GetAllUserAccountsQuery : IRequest<List<UserAccountDTO>>
    {

    }
}
