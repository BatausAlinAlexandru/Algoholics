using Application.DTO;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.Queies.UserAccount
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

            var userAccounts = await _userAccountRepository.GetUserAccountsAsyncV2();
            return userAccounts.Select(ua => new UserAccountDTO
            {
                Id = ua.Id,
                Email = ua.UserAccountCredentials.Email,
                Password = ua.UserAccountCredentials.Password,
                UserAccountRole = ua.UserAccountCredentials.UserAccountRole,
            }).ToList();

        }
    }
}
