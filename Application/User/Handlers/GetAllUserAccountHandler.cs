using Application.User.DTO;
using Application.User.Queries;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.User.Handlers
{
    public class GetAllUserAccountHandler : IRequestHandler<GetAllUserAccountsQuery, List<UserAccountDTO>>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public GetAllUserAccountHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<List<UserAccountDTO>> Handle(GetAllUserAccountsQuery request, CancellationToken cancellationToken)
        {
            var userAccounts = await _userAccountRepository.GetUserAccountsAsync();
            return userAccounts.Select(userAccount => new UserAccountDTO
            {
                Email = userAccount.UserAccountCredentials.Email,
                Password = userAccount.UserAccountCredentials.Password,
                UserAccountRole = userAccount.UserAccountRole
            }).ToList();
        }
    }
}
