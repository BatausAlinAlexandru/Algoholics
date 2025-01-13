using CSharpFunctionalExtensions;
using Domain.Aggregates.UserAggregate.Entities;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.Commands.UserAccount
{
    public class UpdateUserAccountCredentialsHandler : IRequestHandler<UpdateUserAccountCredentialsCommand, Result>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UpdateUserAccountCredentialsHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<Result> Handle(UpdateUserAccountCredentialsCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetUserAccountByIdAsync(request.Id);

            if (userAccount == null)
                return Result.Failure($"User account with id {request.Id} not found");

            var userAccountCredentials = new UserAccountCredentials(request.Email, request.Password);
            userAccount.UpdateUserAccountCredentials(userAccountCredentials);
            await _userAccountRepository.UpdateUserAccountAsync(userAccount);

            return Result.Success();
        }
    }
}
