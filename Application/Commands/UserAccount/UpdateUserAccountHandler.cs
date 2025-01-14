using CSharpFunctionalExtensions;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.Commands.UserAccount
{
    internal class UpdateUserAccountHandler : IRequestHandler<UpdateUserAccountCommand, Result>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        public UpdateUserAccountHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }
        public async Task<Result> Handle(UpdateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetUserAccountByIdAsync(request.Id);
            if (userAccount == null)
                return Result.Failure($"User account with id {request.Id} not found");

            userAccount.UserAccountCredentials.UpdateEmail(request.Email);
            userAccount.UserAccountCredentials.UserAccountRole = request.UserAccountRole;
            userAccount.UserAccountInfo.UserAccountGender = request.UserAccountGender;
            userAccount.UserAccountInfo.Alias = request.Alias;


            await _userAccountRepository.UpdateUserAccountAsync(userAccount);

            return Result.Success();
        }
    }
}
