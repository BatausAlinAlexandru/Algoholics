using CSharpFunctionalExtensions;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.Commands.UserAccount
{
    internal class UpdateUserAccountPaymentInfoHandler : IRequestHandler<UpdateUserAccountPaymentInfoCommand, Result>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UpdateUserAccountPaymentInfoHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<Result> Handle(UpdateUserAccountPaymentInfoCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetUserAccountByIdAsync(request.IdUserAccount);
            if (userAccount == null)
                return Result.Failure($"User account with ID {request.IdUserAccount} was not found");

            userAccount.UserAccountInfo.UserAccountPaymentCardInfo.UpdatePaymentInfo(request.NewCardNumber, request.NewCardHolderName, request.NewExpirationCardMonth, 
               request.NewExpirationCardYear, request.NewCVV);

            await _userAccountRepository.SaveUserAccountAsync();


            return Result.Success();
        }
    }
}
