using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;
using CSharpFunctionalExtensions;
using Application.User.Commands.UserAccount;

namespace Application.User.Handlers.UserAccountHandler
{
    public class AddUserAccountHandler : IRequestHandler<AddUserAccountCommand, Result>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public AddUserAccountHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<Result> Handle(AddUserAccountCommand request, CancellationToken cancellationToken)
        {
            var success = await _userAccountRepository.AddUserAccountAsync(new Domain.Aggregates.UserAggregate.Entities.UserAccountCredentials(request.Email, request.Password));
            return success ? Result.Success() : Result.Failure("Failed to add user account");
        }
    }
}
