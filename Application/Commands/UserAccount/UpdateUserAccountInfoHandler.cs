using CSharpFunctionalExtensions;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.Commands.UserAccount
{
    internal class UpdateUserAccountInfoHandler : IRequestHandler<UpdateUserAccountInfoCommand, Result>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UpdateUserAccountInfoHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<Result> Handle(UpdateUserAccountInfoCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetUserAccountByIdAsync(request.UserAccountId);

            if (userAccount == null)
                return Result.Failure($"User account with id {request.UserAccountId} not found");

            var userAccountInfo = userAccount.UserAccountInfo;

            userAccountInfo.UserAccountGender = request.UserAccountGender;
            userAccountInfo.Alias = request.Alias;
            userAccountInfo.Avatar = request.Avatar;

            userAccount.UpdateUserAccountInfo(userAccountInfo);
            await _userAccountRepository.UpdateUserAccountAsync(userAccount);

            return Result.Success();
        }
    }
}
