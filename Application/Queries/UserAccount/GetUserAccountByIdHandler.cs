using Application.DTO;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.Queries.UserAccount
{
    public class GetUserAccountByIdHandler : IRequestHandler<GetUserAccountByIdQuery, UserAccountDTO>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public GetUserAccountByIdHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<UserAccountDTO> Handle(GetUserAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var ua = await _userAccountRepository.GetUserAccountByIdAsync(request.UserAccountId);

            var userAccountDTO = new UserAccountDTO
            {
                Id = ua.Id,
                Email = ua.UserAccountCredentials.Email,
                UserAccountRole = ua.UserAccountCredentials.UserAccountRole,
                Alias = ua.UserAccountInfo.Alias,
                UserAccountGender = ua.UserAccountInfo.UserAccountGender,
                DateCreated = ua.UserAccountInfo.DateCreated
            };

            return userAccountDTO;
        }
    }
}
