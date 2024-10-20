using Domain.Aggregates.UserAggregate.Repositories;
using Domain.Aggregates.UserAggregate.Entities;
using MediatR;
using CSharpFunctionalExtensions;
using Application.User.Commands;

namespace Application.User.Handlers
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
            var success = await _userAccountRepository.AddUserAccountAsync(new UserAccountCredentials(request.Email, request.Password));
            return success ? Result.Success() : Result.Failure("Failed to add user account");
        }
    }
}
