using MediatR;
using CSharpFunctionalExtensions;
using Domain.Aggregates.UserAggregate.Repositories;


namespace Application.Commands.UserAccount
{
    public class ModifyUserAccountEmailHandler : IRequestHandler<ModifyUserAccountEmailCommand, Result>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public ModifyUserAccountEmailHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<Result> Handle(ModifyUserAccountEmailCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetUserAccountByIdAsync(request.Id);
            if (userAccount == null)
                return Result.Failure("User account not found");

            userAccount.UserAccountCredentials.UpdateEmail(request.Email);

            await _userAccountRepository.SaveUserAccountAsync();
            return Result.Success();
        }
    }
}
